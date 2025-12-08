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
using static System.Net.Mime.MediaTypeNames;

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

        // Helper: Calculates shipping fee dynamically
        private decimal CalculateShippingFee(int bookCount)
        {
            if (bookCount == 0) return 0.00m;

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

            // Customers can see a list of the orders they've placed, most recent first [cite: 137-138].
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

            // Customers should not be able to check out if they have an empty shopping cart[cite: 169].
            if (cart == null || !cart.OrderDetails.Any())
            {
                TempData["ErrorMessage"] = "You cannot check out with an empty cart.";
                return RedirectToAction("Index", "OrderDetails");
            }

            cart.ShippingFee = CalculateShippingFee(cart.OrderDetails.Sum(od => od.Quantity));
            ViewBag.AllCards = GetCustomerCards();

            return View(cart);
        }

        // POST: Orders/PlaceOrder (Place Order)
        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(int SelectedCardID, string CouponCode, string submitAction)
        {
            string currentUserID = GetUserID();
            Order cart = GetCartForCheckout();

            // 0. Re-validate for empty cart
            if (cart == null || cart.OrderDetails == null || !cart.OrderDetails.Any())
            {
                TempData["ErrorMessage"] = "Cannot place order: your cart is empty.";
                return RedirectToAction("Index", "OrderDetails");
            }

            // 1. Validate selected card belongs to this customer
            Card selectedCard = await _context.Cards
                .FirstOrDefaultAsync(c => c.CardID == SelectedCardID && c.CustomerID == currentUserID);

            if (selectedCard == null)
            {
                ModelState.AddModelError("SelectedCardID", "Please select a valid payment card.");
            }

            // 2. Look up coupon (if provided) and enforce single-use-per-customer
            Coupon appliedCoupon = null;

            if (!string.IsNullOrWhiteSpace(CouponCode))
            {
                appliedCoupon = await _context.Coupons
                    .FirstOrDefaultAsync(c => c.CouponCode == CouponCode && c.Status == true);

                if (appliedCoupon == null)
                {
                    // If the coupon code is invalid, disabled, or not applicable to the order, the customer should receive a message[cite: 177].
                    ModelState.AddModelError("CouponCode", "The coupon code is not valid or disabled.");
                }
                else
                {
                    // A given coupon may only be used once by an individual customer[cite: 278].
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
                // Clear any lingering error messages if the user clears the coupon code field
                if (ModelState.ContainsKey("CouponCode"))
                {
                    ModelState.Remove("CouponCode");
                }
            }

            // If validation failed, redisplay Checkout with errors
            if (!ModelState.IsValid)
            {
                ViewBag.AllCards = GetCustomerCards(SelectedCardID);

                int booksForShipping = cart.OrderDetails.Sum(od => od.Quantity);
                cart.ShippingFee = CalculateShippingFee(booksForShipping);

                return View("Checkout", cart);
            }

            // 3. SINGLE SOURCE OF TRUTH: compute subtotal, shipping, discount, final total

            decimal originalSubtotal = cart.Subtotal;                      // books only
            int totalBooks = cart.OrderDetails.Sum(od => od.Quantity);
            decimal shippingFee = CalculateShippingFee(totalBooks);        // base shipping
            decimal discountAmount = 0m;                                   // dollars off subtotal (RAW, not rounded)
            decimal rawDiscount = 0m;

            if (appliedCoupon != null)
            {
                if (appliedCoupon.CouponType == CouponType.FreeShipping)
                {
                    // Free shipping if threshold is 0 (all orders) or subtotal meets threshold
                    if (appliedCoupon.FreeThreshold == 0
                        || originalSubtotal >= appliedCoupon.FreeThreshold)
                    {
                        shippingFee = 0m;
                    }
                }
                else if (appliedCoupon.CouponType == CouponType.PercentOff
                         && appliedCoupon.DiscountPercent.HasValue)
                {
                    // Percent off BOOK SUBTOTAL only.
                    rawDiscount = originalSubtotal * (appliedCoupon.DiscountPercent.Value / 100.0m);
                    discountAmount = rawDiscount;
                }
            }

            // Persist these on the cart
            cart.ShippingFee = shippingFee;
            cart.DiscountAmount = discountAmount;

            // FINAL TOTAL uses RAW discount, then rounds the total (so 29.555 -> 29.56)
            decimal finalTotal = originalSubtotal - discountAmount + shippingFee;
            finalTotal = Math.Round(finalTotal, 2, MidpointRounding.AwayFromZero);

            // 3b. If user clicked "Apply Coupon", just show updated totals – DO NOT place order
            if (submitAction == "apply")
            {
                ViewBag.AllCards = GetCustomerCards(SelectedCardID);
                ViewBag.TotalSavings = (originalSubtotal + CalculateShippingFee(totalBooks)) - finalTotal; // Show savings based on original shipping
                ViewBag.AppliedCouponCode = appliedCoupon?.CouponCode;

                return View("Checkout", cart); // OrderStatus still InCart
            }

            // 4. Finalize and SAVE the order (Place Order)

            cart.OrderDate = DateTime.Now;
            cart.OrderStatus = OrderStatus.Ordered;
            cart.CardID = selectedCard.CardID;
            cart.CouponID = appliedCoupon?.CouponID;

            // Decrease inventory and increase TimesPurchased
            foreach (var od in cart.OrderDetails)
            {
                Book book = await _context.Books.FindAsync(od.BookID);
                if (book != null)
                {
                    book.InventoryQuantity -= od.Quantity;
                    book.TimesPurchased += od.Quantity;
                    _context.Update(book);
                }
            }

            _context.Update(cart);
            await _context.SaveChangesAsync();

            // 5. Build confirmation email and send

            var customer = await _context.Users.FirstOrDefaultAsync(u => u.Id == cart.CustomerID);
            var purchasedBook = cart.OrderDetails.FirstOrDefault()?.Book; // Book for recommendation logic

            if (customer != null)
            {
                var bodyBuilder = new StringBuilder();

                bodyBuilder.AppendLine($"Hi {customer.FirstName},");
                bodyBuilder.AppendLine();
                bodyBuilder.AppendLine("Thank you for your order from Bevo's Books!");
                bodyBuilder.AppendLine($"Your order number is #{cart.OrderID}.");
                bodyBuilder.AppendLine();
                bodyBuilder.AppendLine("Order Details:");
                bodyBuilder.AppendLine("------------------------------");

                foreach (var od in cart.OrderDetails)
                {
                    bodyBuilder.AppendLine(
                        $"{od.ProductName} by {od.Book?.Authors} — Qty: {od.Quantity}, Price: {od.Price:C}");
                }

                bodyBuilder.AppendLine("------------------------------");
                bodyBuilder.AppendLine($"Subtotal: {originalSubtotal:C}");
                bodyBuilder.AppendLine($"Shipping: {shippingFee:C}");
                bodyBuilder.AppendLine($"Discount: {discountAmount:C}");
                bodyBuilder.AppendLine($"Total: {finalTotal:C}");
                bodyBuilder.AppendLine();

                // Recommendations in email [cite: 105-106]
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
                 bodyBuilder.AppendLine("Team 14 – Bevo's Books [cite: 136]");

                 string subject = "Team 14: Order Confirmation [cite: 136]";
                // The system will send email messages to the customer [cite: 128-129].
                await EmailUtils.SendEmailAsync(customer.Email, subject, bodyBuilder.ToString());
            }

            TempData["OrderSuccessMessage"] = $"Order #{cart.OrderID} successfully placed!";
            return RedirectToAction("Confirmed", new { id = cart.OrderID });
        }


        // GET: Orders/Confirmed/5 (Order Confirmation Page)
        public async Task<IActionResult> Confirmed(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(od => od.Book).ThenInclude(b => b.Genre)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Book).ThenInclude(b => b.Reviews)
                .Include(o => o.Card)
                .Include(o => o.Coupon)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null || order.CustomerID != GetUserID()) return Forbid();

            // If there are multiple books, only give recommendations for one of the books[cite: 126].
            var purchasedBook = order.OrderDetails.FirstOrDefault()?.Book;

            if (purchasedBook != null)
            {
                // The message should show up on a dedicated order-confirmed page [cite: 103-104].
                ViewBag.Recommendations = await GetRecommendationsForOrder(order.CustomerID, purchasedBook);
            }

            return View(order);
        }

        // --- HELPER METHODS ---

        // AuthorMatches is no longer needed if we use direct string comparison for Rule 1.
        // If the requirement means matching only one author in a comma-separated list,
        // this method should be re-implemented, but for exact string matching, it's unnecessary.

        private async Task<List<Book>> GetRecommendationsForOrder(string customerID, Book purchasedBook)
        {
            var recommendations = new List<Book>();
            int maxRecommendations = 3;

            if (purchasedBook == null)
                return recommendations;

            int targetGenreID = purchasedBook.GenreID;
            string targetAuthor = purchasedBook.Authors?.Trim() ?? "";

            // --- Rule 0: Exclusion (Trumps all others) ---
            // System should not recommend books that the customer has already purchased[cite: 109].
            var purchasedBookIDs = await _context.Orders
                .Where(o => o.CustomerID == customerID && o.OrderStatus != OrderStatus.InCart)
                .SelectMany(o => o.OrderDetails)
                .Select(od => od.BookID)
                .Distinct()
                .ToListAsync();

            var availableBooks = await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Reviews)
                // Exclude purchased books, and exclude the book just purchased (using BookID != purchasedBook.BookID)
                .Where(b => !purchasedBookIDs.Contains(b.BookID) && b.BookID != purchasedBook.BookID)
                .ToListAsync();

            var recommendedIds = new HashSet<int>();
            var usedAuthors = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // --- Rule 1: Same Author, Same Genre ---
            // If the author has another book of the same genre... this should always be in the recommendation [cite: 111-112].
            var sameAuthorSameGenre = availableBooks
                .Where(b => b.GenreID == targetGenreID
                    // FIX: Direct comparison of the Authors string for exact match
                    && b.Authors.Trim().Equals(targetAuthor, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(b => b.Rating ?? 0) // Choose the book with the highest rating[cite: 113].
                .ToList();

            if (sameAuthorSameGenre.Any())
            {
                var authorRec = sameAuthorSameGenre.First();
                recommendations.Add(authorRec);
                recommendedIds.Add(authorRec.BookID);
                usedAuthors.Add((authorRec.Authors ?? "").Trim());
            }

            int booksNeeded = maxRecommendations - recommendations.Count;
            // If Rule 1 yielded nothing, we need 3 books from subsequent categories; otherwise, we need 2 [cite: 116-117].
            int targetHighlyRatedCount = (recommendations.Count == 0) ? 3 : 2;

            // --- Rule 2: Highly-Rated Same Genre (distinct authors) ---
            if (recommendations.Count < maxRecommendations)
            {
                var highlyRated = availableBooks
                    // Filter: Same Genre, Rating >= 4.0 [cite: 119-121], not already recommended
                    .Where(b => b.GenreID == targetGenreID && (b.Rating ?? 0) >= 4.0 && !recommendedIds.Contains(b.BookID))
                    .OrderByDescending(b => b.Rating ?? 0) // Top two will be fine[cite: 122].
                    .ToList();

                foreach (var book in highlyRated)
                {
                    if (recommendations.Count >= maxRecommendations) break;

                    var authorKey = (book.Authors ?? "").Trim();
                    // Must have two different authors (distinct authors check) [cite: 118-119].
                    if (!usedAuthors.Contains(authorKey))
                    {
                        recommendations.Add(book);
                        recommendedIds.Add(book.BookID);
                        usedAuthors.Add(authorKey);
                    }

                    // Stop once we hit the maximum number of highly-rated books needed
                    if (recommendations.Count == targetHighlyRatedCount)
                        break;
                }
            }

            // --- Rule 3: Low/No Rating Same Genre (to fill blank spots) ---
            booksNeeded = maxRecommendations - recommendations.Count;
            if (booksNeeded > 0)
            {
                // Filter: Same Genre, Not highly rated (< 4.0 or null rating), Not already recommended
                var lowRated = availableBooks
                    .Where(b => b.GenreID == targetGenreID
                            && (b.Rating ?? 0) < 4.0
                            && !recommendedIds.Contains(b.BookID))
                    .OrderBy(b => b.Rating ?? 0) // Order by low rating (lowest first, or null)
                    .ToList();

                foreach (var book in lowRated)
                {
                    if (recommendations.Count >= maxRecommendations) break;
                    // We don't enforce distinct authors here, just fill spots[cite: 123].
                    recommendations.Add(book);
                    recommendedIds.Add(book.BookID);
                }
            }

            // --- Rule 4: Highest Rated Overall (If still short) ---
            booksNeeded = maxRecommendations - recommendations.Count;
            if (booksNeeded > 0)
            {
                // Pick the highest rated books overall to fill in remaining spots [cite: 124-125].
                var overall = availableBooks
                    .Where(b => !recommendedIds.Contains(b.BookID))
                    .OrderByDescending(b => b.Rating ?? 0)
                    .ToList();

                foreach (var book in overall)
                {
                    if (recommendations.Count >= maxRecommendations) break;
                    recommendations.Add(book);
                    recommendedIds.Add(book.BookID);
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

            List<SelectListItem> cardList = cards.Select(c => new SelectListItem
            {
                Value = c.CardID.ToString(),
                // Only the last 4 digits of the credit card should show [cite: 95]
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