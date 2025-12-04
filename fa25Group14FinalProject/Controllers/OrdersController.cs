using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Text;

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
        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(int SelectedCardID, string CouponCode)
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
                // FIX: If the CouponCode is blank, ensure no ModelState error is associated with it.
                // This allows the form to submit successfully without a coupon, or fail
                // only on other errors (like no card selected).
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

            // --- 4. CONFIRMATION & REDIRECTION ---

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

            // 1. Get IDs of all books the customer has already purchased (Req. 109)
            var purchasedBookIDs = await _context.Orders
                .Where(o => o.CustomerID == customerID && o.OrderStatus != OrderStatus.InCart)
                .SelectMany(o => o.OrderDetails)
                .Select(od => od.BookID)
                .Distinct()
                .ToListAsync();

            // Protect against null purchasedBook
            if (purchasedBook == null)
                return recommendations;

            int targetGenreID = purchasedBook.GenreID;
            string targetAuthor = purchasedBook.Authors?.Trim() ?? "";

            // Build base query: exclude purchased books and include needed navigations
            IQueryable<Book> availableQuery = _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Reviews)
                .Where(b => !purchasedBookIDs.Contains(b.BookID) && b.BookID != purchasedBook.BookID);

            // Materialize once (we will do several in-memory operations afterwards)
            var availableBooks = await availableQuery.ToListAsync();

            // Convenience: helper sets for lookups
            var recommendedIds = new HashSet<int>();
            var usedAuthors = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // --- 1) Author's other book in same genre (must come first if exists) ---
            // Find all candidate books by same author in same genre (exclude purchased and the purchasedBook itself).
            var sameAuthorSameGenreCandidates = availableBooks
                .Where(b => b.GenreID == targetGenreID && AuthorMatches(b.Authors ?? "", targetAuthor))
                .OrderByDescending(b => b.Rating ?? 0) // highest rating among author books
                .ToList();

            // If there is at least one, pick the top-rated one (requirement says choose highest rating)
            if (sameAuthorSameGenreCandidates.Any())
            {
                var authorRec = sameAuthorSameGenreCandidates.First();
                recommendations.Add(authorRec);
                recommendedIds.Add(authorRec.BookID);
                usedAuthors.Add((authorRec.Authors ?? "").Trim());
            }

            // Determine how many slots remain
            int booksNeeded = maxRecommendations - recommendations.Count;

            // --- 2) If author had no same-genre book, we should choose three books from the next category instead of two ---
            // The spec line "If there are no other books by this author in this genre, choose three books from the category below instead of two"
            // We'll handle that by not reducing the target of "highly-rated same-genre" picks when authorRec is missing.

            // --- 3) Highly-rated books of the same genre (Rating >= 4.0), with two different authors ---
            if (booksNeeded > 0)
            {
                // We need either 2 picks (if authorRec was found) or 3 picks (if authorRec NOT found)
                int targetHighlyRatedCount = (recommendations.Count == 0) ? 3 : Math.Min(2, booksNeeded);

                // Build candidates: same genre, rating >= 4.0, not already selected
                var highlyRatedCandidates = availableBooks
                    .Where(b => b.GenreID == targetGenreID
                                && (b.Rating ?? 0) >= 4.0
                                && !recommendedIds.Contains(b.BookID))
                    .OrderByDescending(b => b.Rating ?? 0)
                    .ToList();

                // Add up to targetHighlyRatedCount, enforcing distinct authors
                foreach (var candidate in highlyRatedCandidates)
                {
                    if (recommendations.Count >= maxRecommendations) break;
                    if (recommendations.Count - (sameAuthorSameGenreCandidates.Any() ? 1 : 0) >= targetHighlyRatedCount && sameAuthorSameGenreCandidates.Any()) break;

                    var candidateAuthorKey = (candidate.Authors ?? "").Trim();
                    if (!usedAuthors.Any(u => string.Equals(u, candidateAuthorKey, StringComparison.OrdinalIgnoreCase)))
                    {
                        recommendations.Add(candidate);
                        recommendedIds.Add(candidate.BookID);
                        usedAuthors.Add(candidateAuthorKey);
                    }

                    // If we still need more but we hit different-author constraint and there are not enough different authors,
                    // the later fill logic will pick low/no rating or overall top books.
                    if (recommendations.Count >= maxRecommendations) break;
                }
            }

            // Recompute needed slots
            booksNeeded = maxRecommendations - recommendations.Count;

            // --- 4) Fill with Low/No Rating (same genre) to fill blanks (Req. 122) ---
            if (booksNeeded > 0)
            {
                var lowRatedCandidates = availableBooks
                    .Where(b => b.GenreID == targetGenreID && !recommendedIds.Contains(b.BookID))
                    .OrderBy(b => b.Rating ?? 0) // low / no rating first
                    .ToList();

                foreach (var c in lowRatedCandidates)
                {
                    if (recommendations.Count >= maxRecommendations) break;
                    recommendations.Add(c);
                    recommendedIds.Add(c.BookID);
                    usedAuthors.Add((c.Authors ?? "").Trim());
                }
            }

            // Recompute needed slots
            booksNeeded = maxRecommendations - recommendations.Count;

            // --- 5) Fill with highest rated books overall if still short (Req. 123-124) ---
            if (booksNeeded > 0)
            {
                var overallCandidates = availableBooks
                    .Where(b => !recommendedIds.Contains(b.BookID))
                    .OrderByDescending(b => b.Rating ?? 0)
                    .ToList();

                foreach (var c in overallCandidates)
                {
                    if (recommendations.Count >= maxRecommendations) break;
                    recommendations.Add(c);
                    recommendedIds.Add(c.BookID);
                    usedAuthors.Add((c.Authors ?? "").Trim());
                }
            }

            // Finally return up to maxRecommendations (defensive)
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
