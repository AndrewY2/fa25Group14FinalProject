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
    // Part Five, Step 1a: Restrict all methods to authorized users (Admins and Customers)
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

        // GET: Orders 
        public async Task<IActionResult> Index()
        {
            // Part Five, Step 8: Add Include statements for OrderDetails 
            var orders = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .AsQueryable();

            // Filter for Customers
            if (User.IsInRole("Customer"))
            {
                // Get the ID of the currently logged-in user
                String currentUserID = _userManager.GetUserId(User);

                // Only show orders belonging to the current user
                orders = orders.Where(o => o.User.Id == currentUserID);
            }

            return View(await orders.ToListAsync());
        }

        // GET: Orders/Details/5 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Eager load the required related entities: OrderDetails, Product, User
            var order = await _context.Orders
                .Include(o => o.OrderDetails) // Include the OrderDetails collection
                    .ThenInclude(od => od.Product) // Then include the Product for each OrderDetail
                .Include(o => o.User) // Include the User for ownership check and display
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            // Part Five, Step 1e: Check if the user is a Customer AND the order doesn't belong to them
            if (User.IsInRole("Customer") && order.User.Id != _userManager.GetUserId(User))
            {
                return Forbid(); // Return 403 Forbidden
            }

            return View(order);
        }

        // GET: Orders/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([Bind("OrderNotes")] Order order)
        {
            // Part Five, Step 1g i & ii: Auto-generate OrderNumber and OrderDate
            Int32 intNextOrderNum = _context.Orders.DefaultIfEmpty().Max(o => o == null ? 70000 : o.OrderNumber) + 1;
            order.OrderNumber = intNextOrderNum;
            order.OrderDate = DateTime.Now;

            // Part Five, Step 1g iii: Associate the order with the logged-in user
            String currentUserID = _userManager.GetUserId(User);
            AppUser currentUser = await _userManager.FindByIdAsync(currentUserID);
            order.User = currentUser;

            // FIX: Clear ModelState and re-validate after setting required properties (User, OrderNumber, OrderDate)
            ModelState.Clear();

            if (TryValidateModel(order)) // Re-check validation now that all required properties are set
            {
                _context.Add(order);
                await _context.SaveChangesAsync();

                // Part Five, Step 1g iv: Redirect to OrderDetails/Create, passing the new OrderID
                return RedirectToAction("Create", "OrderDetails", new { orderID = order.OrderID });
            }

            // If ModelState is still invalid, return the view
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Part Five, Step 9c & 10: Use Include and ThenInclude to load: OrderDetails, Product, User
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            // Authorization check
            if (User.IsInRole("Customer") && order.User.Id != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            return View(order);
        }

        // POST: Orders/Edit/5 (Secured by controller-level Authorize tag)
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Part Five, Step 11: Modify Bind list to only accept editable fields (OrderNotes)
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderNotes")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            // Retrieve the existing order from the database, including the user for the ownership check
            Order orderToUpdate = _context.Orders
                .Include(o => o.User)
                .FirstOrDefault(o => o.OrderID == id);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            // Authorization check (similar to Details GET): A customer can only edit their own order
            if (User.IsInRole("Customer") && orderToUpdate.User.Id != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            // FIX: Remove validation errors for required properties not on the form
            ModelState.Remove("OrderNumber");
            ModelState.Remove("OrderDate");
            ModelState.Remove("User");

            // Step 2: Update ONLY the OrderNotes field from the submitted model
            if (ModelState.IsValid)
            {
                try
                {
                    // Direct assignment of the only field that was allowed to be edited
                    orderToUpdate.OrderNotes = order.OrderNotes;

                    _context.Update(orderToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to details page
            }

            // If validation fails (shouldn't happen now, but for safety):
            return View(orderToUpdate);
        }

        // NOTE: DELETE ACTIONS REMOVED as per Part Five, Steps 19 & 20
        // (No one should be able to delete orders)

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}