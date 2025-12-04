using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fa25Group14FinalProject.Controllers
{
    // Restrict all methods to authorized users
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrdersController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Helper: Get the current logged-in user ID
        private String GetUserID()
        {
            return _userManager.GetUserId(User);
        }

        // Helper: Fetches the customer's current Shopping Cart (unplaced Order)
        private Order GetCartForCheckout()
        {
            String userID = GetUserID();
            return _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.CustomerID == userID && o.OrderStatus == OrderStatus.InCart);
        }

        // Helper: Calculates shipping fee dynamically (using AdminSettings if available, or defaults)
        private decimal CalculateShippingFee(int bookCount)
        {
            if (bookCount == 0) return 0.00m;

            // (Shipping price is $3.50 for the first book, and $1.50 for each additional book. [cite: 246])
            decimal firstBookFee = 3.50m;
            decimal additionalBookFee = 1.50m;

            return firstBookFee + (bookCount - 1) * additionalBookFee;
        }

        // --- ORDER HISTORY (INDEX) AND DETAILS ---

        public async Task<IActionResult> Index()
        {
            var orders = _context.Orders
               .Include(o => o.Customer)
               .Include(o => o.OrderDetails)
               .Include(o => o.Card)
               .AsQueryable();

            if (User.IsInRole("Customer"))
            {
                String currentUserID = GetUserID();
                orders = orders.Where(o => o.CustomerID == currentUserID);
            }

            return View(await orders.OrderByDescending(o => o.OrderDate).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(od => od.Book)
                .Include(o => o.Customer)
                .Include(o => o.Card)
                .Include(o => o.Coupon)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null) return NotFound();

            if (User.IsInRole("Customer") && order.CustomerID != GetUserID()) return Forbid();

            return View(order);
        }

        // --- EDIT (USED AS ORDER SUMMARY + GATEWAY TO CART) ---

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null) return NotFound();

            // Customers can only see their own orders
            if (User.IsInRole("Customer") && order.CustomerID != GetUserID())
            {
                return Forbid();
            }

            return View(order);
        }

        // POST: Orders/Edit/5
        // NOTE: Right now we are not actually changing any scalar properties on the order
        // (the form only posts the hidden OrderID), so this simply validates access and
        // returns to the Index.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            if (User.IsInRole("Customer") && order.CustomerID != GetUserID())
            {
                return Forbid();
            }

            // No changes to save at this time – just go back to the order list.
            return RedirectToAction(nameof(Index));
        }

        // --- SHOPPING CART / CHECKOUT FLOW ---

        // GET: Orders/Checkout (The final summary page before placing the order)
        [Authorize(Roles = "Customer")]
        public IActionResult Checkout()
        {
            Order cart = GetCartForCheckout();

            // Customers should not be able to check out if they have an empty shopping cart. [cite: 248]
            if (cart == null || !cart.OrderDetails.Any())
            {
                TempData["ErrorMessage"] = "You cannot check out with an empty cart.";
                return RedirectToAction("Index", "OrderDetails"); // Redirect to cart view
            }

            // Recalculate shipping and subtotal dynamically
            cart.ShippingFee = CalculateShippingFee(cart.OrderDetails.Sum(od => od.Quantity));

            // Pass payment options to the view
            ViewBag.AllCards = GetCustomerCards();

            return View(cart);
        }
        //perri added last string
        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(int SelectedCardID, string CouponCode, string submitAction)
        {
            // Helpers required in this scope
            string currentUserID = GetUserID();
            Order cart = GetCartForCheckout();

            // Re-validate for empty cart
            if (cart == null || !cart.OrderDetails.Any())
            {
                TempData["ErrorMessage"] = "Cannot place order: your cart is empty.";
                return RedirectToAction("Index", "OrderDetails");
            }

            // --- Validate that the selected card belongs to this customer ---
            Card selectedCard = await _context.Cards
                .FirstOrDefaultAsync(c => c.CardID == SelectedCardID && c.CustomerID == currentUserID);

            if (selectedCard == null)
            {
                ModelState.AddModelError("SelectedCardID", "Please select a valid payment card.");
            }

            // --- 1. COUPON VALIDATION AND SINGLE-USE CHECK ---
            Coupon appliedCoupon = null;
            decimal originalSubtotal = cart.Subtotal; // Subtotal before coupon
            decimal subtotal = originalSubtotal;

            if (!string.IsNullOrWhiteSpace(CouponCode))
            {
                // Find active coupon
                appliedCoupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == CouponCode && c.Status == true);

                if (appliedCoupon == null)
                {
                    ModelState.AddModelError("CouponCode", "The coupon code is not valid or disabled.");
                }
                else
                {
                    // Has this customer used this coupon before? (Requirement 189)
                    bool alreadyUsed = await _context.Orders
                        .AnyAsync(o => o.CouponID == appliedCoupon.CouponID
                                        && o.CustomerID == currentUserID
                                        && o.OrderStatus != OrderStatus.InCart);

                    if (alreadyUsed)
                    {
                        ModelState.AddModelError("CouponCode", "You have already used this coupon.");
                    }
                }
            }
            else
            {
                // If the CouponCode is blank, ensure no ModelState error is associated with it.
                if (ModelState.ContainsKey("CouponCode"))
                {
                    ModelState.Remove("CouponCode");
                }
            }

            // If validation fails, reload the checkout view with errors
            if (!ModelState.IsValid)
            {
                ViewBag.AllCards = GetCustomerCards(SelectedCardID);
                int totalBooksForShipping = cart.OrderDetails.Sum(od => od.Quantity);
                cart.ShippingFee = CalculateShippingFee(totalBooksForShipping);
                return View("Checkout", cart);
            }

            // --- 2. FINAL CALCULATIONS & DISCOUNT APPLICATION ---

            // Calculate base shipping fee
            int totalBooks = cart.OrderDetails.Sum(od => od.Quantity);
            decimal finalShipping = CalculateShippingFee(totalBooks);

            // Reset discount amount
            cart.DiscountAmount = 0m;

            // Apply coupon discount effects (Req. 184, 185)
            if (appliedCoupon != null)
            {
                if (appliedCoupon.CouponType == CouponType.FreeShipping)
                {
                    // Check threshold condition
                    if (appliedCoupon.FreeThreshold == 0 || originalSubtotal >= appliedCoupon.FreeThreshold)
                    {
                        finalShipping = 0.00m; // Free Shipping Applied
                    }
                }
                else if (appliedCoupon.CouponType == CouponType.PercentOff && appliedCoupon.DiscountPercent.HasValue)
                {
                    // Compute a dollar discount off the original subtotal
                    decimal discount = originalSubtotal * (appliedCoupon.DiscountPercent.Value / 100.0m);
                    cart.DiscountAmount = discount;
                    subtotal = originalSubtotal - discount;
                }
            }
            // perri added
            // --- 2b. If user clicked "Apply Coupon", just refresh Checkout with updated totals ---
            if (submitAction == "apply")
            {
                // Update the shipping fee on the cart for display
                cart.ShippingFee = finalShipping;

                // At this point cart.DiscountAmount has already been set (if a percent-off coupon was applied)
                // and OrderTotal is computed from Subtotal, DiscountAmount, and ShippingFee.

                // Rebuild dropdown with the previously selected card
                ViewBag.AllCards = GetCustomerCards(SelectedCardID);

                // Redisplay the Checkout page instead of placing the order
                return View("Checkout", cart);
            }

            // --- 3. ORDER FINALIZATION & TRANSACTION ---

            // Finalize Order Properties
            cart.OrderDate = DateTime.Now;
            cart.OrderStatus = OrderStatus.Ordered; // Order is placed/shipped (Req. 263)
            cart.CardID = selectedCard.CardID;
            cart.CouponID = appliedCoupon?.CouponID;
            cart.ShippingFee = finalShipping;

            // Decrease Inventory Quantity (Req. 271)
            foreach (var od in cart.OrderDetails)
            {
                Book book = await _context.Books.FindAsync(od.BookID);
                if (book != null)
                {
                    book.InventoryQuantity -= od.Quantity;
                    _context.Update(book);
                }
            }

            // Finalize and Save Order
            _context.Update(cart);
            await _context.SaveChangesAsync();

            // --- 4. EMAIL CONFIRMATION (with recommendations) ---

            // Load customer and a representative book for recommendations
            var customer = await _context.Users.FirstOrDefaultAsync(u => u.Id == cart.CustomerID);
            var purchasedBook = cart.OrderDetails.FirstOrDefault()?.Book;


            // Build email body
            if (customer != null)
            {
                var bodyBuilder = new System.Text.StringBuilder();

                bodyBuilder.AppendLine($"Hi {customer.FirstName},");
                bodyBuilder.AppendLine();
                bodyBuilder.AppendLine("Thank you for your order from Bevo's Books!");
                bodyBuilder.AppendLine($"Your order number is #{cart.OrderID}.");
                bodyBuilder.AppendLine();
                bodyBuilder.AppendLine("Order Details:");
                bodyBuilder.AppendLine("------------------------------");

                foreach (var od in cart.OrderDetails)
                {
                    // Make sure we include title and author in the email
                    bodyBuilder.AppendLine(
                        $"{od.ProductName} by {od.Book?.Authors} — Qty: {od.Quantity}, Price: {od.Price:C}");
                }

                bodyBuilder.AppendLine("------------------------------");
                bodyBuilder.AppendLine($"Subtotal: {subtotal:C}");
                bodyBuilder.AppendLine($"Shipping: {finalShipping:C}");
                bodyBuilder.AppendLine($"Discount: {cart.DiscountAmount:C}");
                bodyBuilder.AppendLine($"Total: {(subtotal + finalShipping):C}");
                bodyBuilder.AppendLine();

                // Recommendations (Required to appear in confirmation email)
                if (purchasedBook != null)
                {
                    var recommendations = await GetRecommendationsForOrder(cart.CustomerID, purchasedBook);

                    if (recommendations != null && recommendations.Any())
                    {
                        bodyBuilder.AppendLine("You might also enjoy:");
                        foreach (var rec in recommendations)
                        {
                            bodyBuilder.AppendLine($" - {rec.Title} by {rec.Authors} (Genre: {rec.Genre?.GenreName})");
                        }
                        bodyBuilder.AppendLine();
                    }
                }

                bodyBuilder.AppendLine("Thanks again for shopping with us!");
                bodyBuilder.AppendLine("Team 14 – Bevo's Books");

                string subject = "Team 14: Order Confirmation";
                await EmailUtils.SendEmailAsync(customer.Email, subject, bodyBuilder.ToString());
            }

            // --- 5. CONFIRMATION & REDIRECTION ---

            TempData["SuccessMessage"] = $"Order #{cart.OrderID} successfully placed!";
            return RedirectToAction("Confirmed", new { id = cart.OrderID });
        }


        // GET: Orders/Confirmed/5 (Order Confirmation Page)
        public async Task<IActionResult> Confirmed(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(od => od.Book).ThenInclude(b => b.Genre) // Include Genre for recommendation logic
                .Include(o => o.OrderDetails).ThenInclude(od => od.Book).ThenInclude(b => b.Reviews) // Include Reviews for rating
                .Include(o => o.Card)
                .Include(o => o.Coupon)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null || order.CustomerID != GetUserID()) return Forbid();

            // Use the first book in the order for recommendations (Req. 125)
            var purchasedBook = order.OrderDetails.FirstOrDefault()?.Book;

            if (purchasedBook != null)
            {
                // Call the new recommendation method
                ViewBag.Recommendations = await GetRecommendationsForOrder(order.CustomerID, purchasedBook);
            }

            return View(order);
        }


        // --- HELPER METHODS ---

        // Helper to determine whether the authorsField contains the targetAuthor.
        // Handles lists like "A, B & C", extra spaces, case, and simple normalization.
        private bool AuthorMatches(string authorsField, string targetAuthor)
        {
            if (string.IsNullOrWhiteSpace(authorsField) || string.IsNullOrWhiteSpace(targetAuthor))
                return false;

            string Normalize(string s) => s?.Normalize(NormalizationForm.FormKC).Trim().ToLowerInvariant() ?? "";

            var normalizedTarget = Normalize(targetAuthor);

            // Common separators and the word " and "
            var separators = new[] { ",", ";", "&", "/", " and " };

            // Replace separators with a single comma then split
            string unified = authorsField;
            foreach (var sep in separators)
            {
                unified = unified.Replace(sep, ",");
            }

            var parts = unified
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => Normalize(p));

            return parts.Contains(normalizedTarget);
        }

        private async Task<List<Book>> GetRecommendationsForOrder(string customerID, Book purchasedBook)
        {
            var recommendations = new List<Book>();
            int maxRecommendations = 3;

            if (purchasedBook == null)
                return recommendations;

            int targetGenreID = purchasedBook.GenreID;
            string targetAuthor = purchasedBook.Authors?.Trim() ?? "";

            // Get IDs of all books already purchased
            var purchasedBookIDs = await _context.Orders
                .Where(o => o.CustomerID == customerID && o.OrderStatus != OrderStatus.InCart)
                .SelectMany(o => o.OrderDetails)
                .Select(od => od.BookID)
                .Distinct()
                .ToListAsync();

            // Base query: exclude purchased books & purchasedBook itself
            var availableBooks = await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Reviews)
                .Where(b => !purchasedBookIDs.Contains(b.BookID) && b.BookID != purchasedBook.BookID)
                .ToListAsync();

            var recommendedIds = new HashSet<int>();
            var usedAuthors = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // --- 1) Same Author, Same Genre ---
            var sameAuthorSameGenre = availableBooks
                .Where(b => b.GenreID == targetGenreID && AuthorMatches(b.Authors ?? "", targetAuthor))
                .OrderByDescending(b => b.Rating ?? 0)
                .ToList();

            if (sameAuthorSameGenre.Any())
            {
                var authorRec = sameAuthorSameGenre.First();
                recommendations.Add(authorRec);
                recommendedIds.Add(authorRec.BookID);
                usedAuthors.Add((authorRec.Authors ?? "").Trim());
            }

            // Determine how many highly-rated picks needed
            int booksNeeded = maxRecommendations - recommendations.Count;
            int targetHighlyRatedCount = (recommendations.Count == 0) ? 3 : 2;

            // --- 2) Highly-Rated Same Genre (distinct authors) ---
            var highlyRated = availableBooks
                .Where(b => b.GenreID == targetGenreID && (b.Rating ?? 0) >= 4.0 && !recommendedIds.Contains(b.BookID))
                .OrderByDescending(b => b.Rating ?? 0)
                .ToList();

            foreach (var book in highlyRated)
            {
                if (recommendations.Count >= maxRecommendations) break;

                var authorKey = (book.Authors ?? "").Trim();
                if (!usedAuthors.Contains(authorKey))
                {
                    recommendations.Add(book);
                    recommendedIds.Add(book.BookID);
                    usedAuthors.Add(authorKey);
                }

                // Stop after picking the target number of highly-rated books
                if (recommendations.Count >= (recommendations.Count == 1 ? 1 + targetHighlyRatedCount : targetHighlyRatedCount))
                    break;
            }

            // --- 3) Fill with low/no rating same genre if still needed ---
            booksNeeded = maxRecommendations - recommendations.Count;
            if (booksNeeded > 0)
            {
                var lowRated = availableBooks
                    .Where(b => b.GenreID == targetGenreID && !recommendedIds.Contains(b.BookID))
                    .OrderBy(b => b.Rating ?? 0)
                    .ToList();

                foreach (var book in lowRated)
                {
                    if (recommendations.Count >= maxRecommendations) break;
                    recommendations.Add(book);
                    recommendedIds.Add(book.BookID);
                    usedAuthors.Add((book.Authors ?? "").Trim());
                }
            }

            // --- 4) Fill with highest-rated overall if still short ---
            booksNeeded = maxRecommendations - recommendations.Count;
            if (booksNeeded > 0)
            {
                var overall = availableBooks
                    .Where(b => !recommendedIds.Contains(b.BookID))
                    .OrderByDescending(b => b.Rating ?? 0)
                    .ToList();

                foreach (var book in overall)
                {
                    if (recommendations.Count >= maxRecommendations) break;
                    recommendations.Add(book);
                    recommendedIds.Add(book.BookID);
                    usedAuthors.Add((book.Authors ?? "").Trim());
                }
            }

            return recommendations.Take(maxRecommendations).ToList();
        }



        // Helper method to retrieve customer's credit cards
        private SelectList GetCustomerCards(int? selectedCardID = null)
        {
            String currentUserID = GetUserID();
            List<Card> cards = _context.Cards
                .Where(c => c.CustomerID == currentUserID)
                .OrderBy(c => c.CardType)
                .ToList();

            // Text should show the card type and last 4 digits (e.g., Visa - ************1234)
            List<SelectListItem> cardList = cards.Select(c => new SelectListItem
            {
                Value = c.CardID.ToString(),
                Text = $"{c.CardType} - ************{c.LastFour}"
            }).ToList();

            if (selectedCardID.HasValue)
            {
                return new SelectList(cardList, "Value", "Text", selectedCardID.Value);
            }
            return new SelectList(cardList, "Value", "Text");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
