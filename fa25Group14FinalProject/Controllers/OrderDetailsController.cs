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

namespace fa25Group14FinalProject.Controllers
{
    // Restrict access to logged-in customers only for cart management
    [Authorize(Roles = "Customer")]
    public class OrderDetailsController : Controller // Name reverted to OrderDetailsController
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderDetailsController(AppDbContext context, UserManager<AppUser> userManager)
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
        private Order GetShoppingCart()
        {
            String userID = GetUserID();

            // Find the unplaced order (cart) for the current user.
            Order cart = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                .FirstOrDefault(o => o.CustomerID == userID && o.OrderStatus == OrderStatus.InCart);

            // If the user doesn't have a cart, create one
            if (cart == null)
            {
                cart = new Order
                {
                    CustomerID = userID,
                    OrderDate = DateTime.Now,
                    OrderStatus = OrderStatus.InCart,
                    ShippingFee = 0.00m
                };
                _context.Orders.Add(cart);
                _context.SaveChanges();
            }

            bool cartModified = false;
            string removeMessageKey = "CartRemovalMessages";
            List<string> removalMessages = TempData[removeMessageKey] as List<string> ?? new List<string>();

            // Logic to check for discontinued/out-of-stock items and update prices
            var detailsToRemove = cart.OrderDetails
                .Where(od => od.Book.BookStatus == true || od.Book.InventoryQuantity == 0)
                .ToList();

            foreach (var od in detailsToRemove)
            {
                string bookTitle = od.Book.Title;
                string message = "";

                // Check discontinued (70)
                if (od.Book.BookStatus == true)
                {
                    message = $"'{bookTitle}' was discontinued and removed from your cart.";
                }
                // Check out of stock (67)
                else if (od.Book.InventoryQuantity == 0)
                {
                    message = $"'{bookTitle}' went out of stock and was removed from your cart.";
                }

                // Only add message if it's new (70)
                if (!string.IsNullOrWhiteSpace(message) && !removalMessages.Contains(message))
                {
                    removalMessages.Add(message);
                }

                cart.OrderDetails.Remove(od);
                _context.OrderDetails.Remove(od);
                cartModified = true;
            }

            // Update prices to current book price [cite: 232]
            foreach (var od in cart.OrderDetails)
            {
                if (od.Price != od.Book.Price)
                {
                    od.Price = od.Book.Price;
                    cartModified = true;
                }
            }
            if (cartModified)
            {
                TempData[removeMessageKey] = removalMessages; // Preserve messages for the view
                _context.SaveChanges();
            }

            return cart;
        }


        // Helper: Calculates shipping fee dynamically (using AdminSettings if available, or defaults)
        private decimal CalculateShippingFee(int bookCount)
        {
            if (bookCount == 0) return 0.00m;

            // Look up dynamic settings (assuming AdminSettings is implemented)
            // If AdminSettings is not implemented, use the default values
            // (Shipping price is $3.50 for the first book, and $1.50 for each additional book. [cite: 246])

            decimal firstBookFee = 3.50m;
            decimal additionalBookFee = 1.50m;

            return firstBookFee + (bookCount - 1) * additionalBookFee;
        }

        // --- CUSTOMER ACTIONS ---

        // GET: OrderDetails/Index (The Shopping Cart Page)
        public IActionResult Index()
        {
            Order cart = GetShoppingCart(); // Runs maintenance, updates current prices

            // 1. Calculate Current Totals
            int totalBooksInCart = cart.OrderDetails.Sum(od => od.Quantity);
            decimal currentShippingFee = CalculateShippingFee(totalBooksInCart); // Accessing the helper
            decimal currentSubtotal = cart.Subtotal; // Uses Order.Subtotal (no item discount)
            decimal currentOrderTotal = currentSubtotal + currentShippingFee;

            // 2. Fetch all active coupons (Requirement 72)
            var activeCoupons = _context.Coupons
                .Where(c => c.Status == true)
                .ToList();

            // 3. Calculate Potential Totals for the View
            var potentialSavings = new List<dynamic>();

            foreach (var coupon in activeCoupons)
            {
                decimal potentialShipping = currentShippingFee;
                decimal potentialSubtotal = currentSubtotal;

                if (coupon.CouponType == CouponType.FreeShipping)
                {
                    // Calculate potential total for Free Shipping
                    if (coupon.FreeThreshold == 0 || currentSubtotal >= coupon.FreeThreshold)
                    {
                        potentialShipping = 0.00m;
                    }
                }
                else if (coupon.CouponType == CouponType.PercentOff && coupon.DiscountPercent.HasValue)
                {
                    // Calculate potential total for Percent Off
                    decimal discountFactor = 1.0m - (coupon.DiscountPercent.Value / 100.0m);
                    potentialSubtotal *= discountFactor;
                }

                // Store calculation results
                potentialSavings.Add(new
                {
                    Code = coupon.CouponCode,
                    Type = coupon.CouponType.ToString(),
                    PercentOff = coupon.DiscountPercent ?? 0m, // Pass percent for item-level display
                    Savings = currentOrderTotal - (potentialSubtotal + potentialShipping),
                    PotentialTotal = potentialSubtotal + potentialShipping
                });
            }

            ViewBag.CurrentOrderTotal = currentOrderTotal;
            ViewBag.CurrentShippingFee = currentShippingFee; // Need to pass shipping fee separately
            ViewBag.PotentialSavings = potentialSavings;
            ViewBag.ActiveCoupons = activeCoupons; // For basic coupon listing/messages

            return View(cart);
        }

        // POST: OrderDetails/AddItem (Used when customer clicks "Add to Cart")
        // This is the new 'Create' functionality
        [HttpPost]
        public async Task<IActionResult> AddItem(int BookID, int Quantity)
        {
            Order cart = GetShoppingCart();
            Book bookToAdd = _context.Books.Find(BookID);

            // Books that are out of stock cannot be added to the shopping cart [cite: 188]
            if (bookToAdd == null || bookToAdd.BookStatus == true || bookToAdd.InventoryQuantity == 0)
            {
                TempData["ErrorMessage"] = "This book is currently unavailable or discontinued.";
                return RedirectToAction("Details", "Books", new { id = BookID });
            }

            // Customers cannot add a quantity greater than the number in stock [cite: 198]
            if (Quantity > bookToAdd.InventoryQuantity)
            {
                TempData["ErrorMessage"] = $"Cannot add {Quantity} copies. Only {bookToAdd.InventoryQuantity} are in stock.";
                return RedirectToAction("Details", "Books", new { id = BookID });
            }

            OrderDetail existingOD = cart.OrderDetails.FirstOrDefault(od => od.BookID == BookID);

            if (existingOD != null)
            {
                int newTotalQuantity = existingOD.Quantity + Quantity;
                if (newTotalQuantity > bookToAdd.InventoryQuantity)
                {
                    TempData["ErrorMessage"] = $"Adding {Quantity} would exceed stock. Only {bookToAdd.InventoryQuantity - existingOD.Quantity} more can be added.";
                    return RedirectToAction("Details", "Books", new { id = BookID });
                }
                existingOD.Quantity = newTotalQuantity;
            }
            else
            {
                // Add new OrderDetail item to the cart
                OrderDetail newOD = new OrderDetail
                {
                    Quantity = Quantity,
                    BookID = BookID,
                    Price = bookToAdd.Price, // Capture current selling price
                    Cost = bookToAdd.Cost,    // Capture current weighted average cost
                    ProductName = bookToAdd.Title
                };
                cart.OrderDetails.Add(newOD);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: OrderDetails/Edit (Update quantity in the cart)
        // Note: The action name must be 'Edit' to replace the old scaffolding action.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailID,Quantity")] OrderDetail orderDetail) // id is OrderDetailID
        {
            OrderDetail odToUpdate = _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Book)
                .FirstOrDefault(od => od.OrderDetailID == id && od.Order.CustomerID == GetUserID());

            if (odToUpdate == null || odToUpdate.Order.OrderStatus != OrderStatus.InCart) return NotFound();

            // Check max quantity [cite: 198]
            if (orderDetail.Quantity > odToUpdate.Book.InventoryQuantity)
            {
                TempData["ErrorMessage"] = $"Cannot set quantity to {orderDetail.Quantity}. Only {odToUpdate.Book.InventoryQuantity} are in stock.";
                return RedirectToAction(nameof(Index));
            }

            // Customers can change the quantity of books [cite: 196]
            if (orderDetail.Quantity <= 0)
            {
                _context.OrderDetails.Remove(odToUpdate);
            }
            else
            {
                odToUpdate.Quantity = orderDetail.Quantity;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: OrderDetails/Delete (Remove item entirely)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // id is OrderDetailID
        {
            // Customers can delete them entirely [cite: 196]
            OrderDetail odToDelete = _context.OrderDetails
                .Include(od => od.Order)
                .FirstOrDefault(od => od.OrderDetailID == id && od.Order.CustomerID == GetUserID());

            if (odToDelete == null || odToDelete.Order.OrderStatus != OrderStatus.InCart) return NotFound();


            _context.OrderDetails.Remove(odToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ❌ REMOVED: All scaffolding actions like GET: Edit, GET: Delete, and the old POST: Create helper methods.
        /* The Index action is now the Shopping Cart view (using no ID parameter). */
    }
}