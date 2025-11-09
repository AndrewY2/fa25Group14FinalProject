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
using Microsoft.AspNetCore.Identity; // **FIX 1: Added using for Identity**

namespace fa25Group14FinalProject.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager; // **FIX 2: Added UserManager field**

        // **FIX 3: Updated Constructor to include UserManager**
        public OrderDetailsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: OrderDetails/Index
        public async Task<IActionResult> Index(int? orderID)
        {
            if (orderID == null)
            {
                return NotFound();
            }

            // NOTE: Security/Ownership checks require including the User here
            var orderDetails = _context.OrderDetails
                               .Where(od => od.Order.OrderID == orderID)
                               .Include(od => od.Product);

            // FIX: Include User for potential security checks (as per assignment requirements)
            Order parentOrder = _context.Orders.Include(o => o.User).FirstOrDefault(o => o.OrderID == orderID);

            if (parentOrder == null)
            {
                return NotFound();
            }

            // NOTE: Add your ownership check here (if needed for Index action)

            ViewBag.OrderNumber = parentOrder.OrderNumber;
            ViewBag.OrderID = parentOrder.OrderID;

            return View(await orderDetails.ToListAsync());
        }

        // GET: OrderDetails/Create
        public IActionResult Create(int orderID)
        {
            OrderDetail od = new OrderDetail();
            Order order = _context.Orders.Find(orderID);

            if (order == null)
            {
                return NotFound();
            }

            od.Order = order;
            ViewBag.AllProducts = GetAllProducts();

            return View(od);
        }

        // POST: OrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDetail orderDetail, int SelectedProduct)
        {
            // CRITICAL FIXES: Remove validation for all complex navigation properties
            ModelState.Remove("Product");
            ModelState.Remove("Order");
            ModelState.Remove("Order.OrderNotes");
            ModelState.Remove("Order.User");
            ModelState.Remove("Order.UserId");
            ModelState.Remove("Order.OrderNumber");
            ModelState.Remove("Order.OrderDate");

            int orderID = orderDetail.Order?.OrderID ?? 0;

            if (ModelState.IsValid == false)
            {
                ViewBag.AllProducts = GetAllProducts(SelectedProduct);
                orderDetail.Order = _context.Orders.Find(orderID);
                return View(orderDetail);
            }

            // FIND AND SET ENTITIES
            Product productFound = _context.Products.Find(SelectedProduct);
            Order orderFound = _context.Orders.Find(orderID);

            if (productFound == null || orderFound == null)
            {
                ModelState.AddModelError("", "The selected product or parent order could not be found.");
                ViewBag.AllProducts = GetAllProducts(SelectedProduct);
                orderDetail.Order = _context.Orders.Find(orderID);
                return View(orderDetail);
            }

            orderDetail.Product = productFound;
            orderDetail.Order = orderFound;

            // CALCULATE AND SAVE
            orderDetail.ProductPrice = productFound.Price;
            orderDetail.ExtendedPrice = orderDetail.Quantity * orderDetail.ProductPrice;

            _context.Add(orderDetail);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Orders", new { id = orderFound.OrderID });
        }


        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var orderDetail = await _context.OrderDetails
                .Include(od => od.Product)
                .Include(od => od.Order)
                    .ThenInclude(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);

            if (orderDetail == null) return NotFound();

            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailID,Quantity")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailID) return NotFound();

            // --- CRITICAL FINAL VALIDATION REMOVALS ---

            // 1. **THE NEW DEFINITIVE FIX:** Remove validation for the entire Order navigation object.
            ModelState.Remove("Order"); // Target the main navigation property

            // 2. Remove validation for the Product navigation object (also missing)
            ModelState.Remove("Product");

            // 3. Remove validation for nested Order properties (safety net)
            ModelState.Remove("Order.OrderNumber");
            ModelState.Remove("Order.OrderDate");
            ModelState.Remove("Order.OrderNotes");
            ModelState.Remove("Order.User");
            ModelState.Remove("Order.UserId");
            ModelState.Remove("Order.OrderID");
            // ------------------------------------------

            if (ModelState.IsValid)
            {
                // Eagerly load the required entities
                OrderDetail odToUpdate = _context.OrderDetails
                                                 .Include(od => od.Order)
                                                 .Include(od => od.Product)
                                                 .FirstOrDefault(od => od.OrderDetailID == id);

                if (odToUpdate == null) return NotFound();

                try
                {
                    int orderID = odToUpdate.Order.OrderID;

                    // Update scalar fields and recalculate
                    odToUpdate.Quantity = orderDetail.Quantity;
                    odToUpdate.ExtendedPrice = odToUpdate.Quantity * odToUpdate.ProductPrice;

                    _context.Update(odToUpdate);
                    await _context.SaveChangesAsync();

                    // Redirect to the Orders/Details page
                    return RedirectToAction("Details", "Orders", new { id = orderID });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderDetailID)) return NotFound();
                    else throw;
                }
            }

            // If validation fails (due to invalid quantity), reload and return view 
            var errorDetail = _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .FirstOrDefault(od => od.OrderDetailID == id);

            errorDetail.Quantity = orderDetail.Quantity;

            return View(errorDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var orderDetail = await _context.OrderDetails
                               .Include(od => od.Product)
                               .Include(od => od.Order)
                               .FirstOrDefaultAsync(m => m.OrderDetailID == id);

            if (orderDetail == null) return NotFound();

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetails
                               .Include(od => od.Order)
                               .FirstOrDefaultAsync(r => r.OrderDetailID == id);

            if (orderDetail == null) return NotFound();

            int orderID = orderDetail.Order.OrderID;

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Orders", new { id = orderID });
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailID == id);
        }

        private SelectList GetAllProducts(int? selectedId = null)
        {
            List<Product> products = _context.Products.OrderBy(p => p.Name).ToList();
            SelectList allProducts = new SelectList(products, nameof(Product.ProductId), nameof(Product.Name), selectedId);
            return allProducts;
        }
    }
}