using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fa25Group14FinalProject.Controllers
{
    // Restricts access to only users in the Admin role (Required)
    [Authorize(Roles = "Admin")]
    public class ReordersController : Controller
    {
        private readonly AppDbContext _context;

        public ReordersController(AppDbContext context)
        {
            _context = context;
        }

        // --- DASHBOARD AND PROCUREMENT OPTIONS ---

        // GET: Reorders/Index (Procurement Dashboard)
        public IActionResult Index()
        {
            // Provides options: Manual Order, Automatic Check, View Books on Order
            return View();
        }

        // --- MANUAL REORDERING ---

        // GET: Reorders/ManualOrder (Search books to order)
        public IActionResult ManualOrder()
        {
            // Initial view displays a search form, similar to Books/Index but focused on procurement.
            return View();
        }

        // GET: Reorders/OrderBook/5 (Displays book details and form to place a manual reorder)
        public async Task<IActionResult> OrderBook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch book details, including cost/profit info for the Admin
            Book book = await _context.Books
                .Include(b => b.Reorders) // Include reorders to calculate last cost
                .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            // Get the last paid cost for the supplier (default cost)
            decimal lastCost = book.Reorders
                .OrderByDescending(r => r.Date)
                .Select(r => r.Cost)
                .FirstOrDefault();

            // Create a new Reorder object for the form input
            Reorder reorder = new Reorder
            {
                BookID = book.BookID,
                Book = book,
                Cost = (lastCost > 0) ? lastCost : 0.01m, // Book costs must be greater than zero.
                Quantity = 5, // Default quantity can be anything, here we use 5.
                ReorderStatus = ReorderStatus.Ordered
            };

            // Calculate Average Profit Margin (Requires a complex query or logic in the book model/service)
            // ViewBag.AvgProfitMargin = CalculateAvgProfitMargin(book.BookID); 

            return View(reorder);
        }

        // POST: Reorders/PlaceManualOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceManualOrder([Bind("BookID,Cost,Quantity")] Reorder reorder)
        {
            // Ensure cost is > 0 and quantity >= 0
            if (reorder.Cost <= 0)
            {
                ModelState.AddModelError("Cost", "Book cost must be greater than zero.");
            }
            if (reorder.Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Quantity must be greater than zero for a manual order.");
            }

            if (ModelState.IsValid)
            {
                // Set non-form properties
                reorder.Date = DateTime.Now;
                reorder.ReorderStatus = ReorderStatus.Ordered;
                reorder.QuantityReceived = 0; // Starts at 0

                _context.Reorders.Add(reorder);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Manual order placed for {reorder.Quantity} copies.";
                return RedirectToAction(nameof(Index));
            }

            // Reload the view with errors
            reorder.Book = await _context.Books.FindAsync(reorder.BookID);
            // ViewBag.AvgProfitMargin = CalculateAvgProfitMargin(reorder.BookID);
            return View("OrderBook", reorder);
        }

        // --- AUTOMATIC REORDERING ---

        // GET: Reorders/AutomaticCheck
        // Shows books below the reorder point, excluding those with enough copies already on order.
        public async Task<IActionResult> AutomaticCheck()
        {
            // 1. Identify all books that have pending Reorder quantities
            var pendingOrders = _context.Reorders
                .Where(r => r.ReorderStatus == ReorderStatus.Ordered || r.ReorderStatus == ReorderStatus.PartiallyReceived)
                .GroupBy(r => r.BookID)
                .Select(g => new
                {
                    BookID = g.Key,
                    CopiesOnOrder = g.Sum(r => r.Quantity - r.QuantityReceived)
                })
                .ToList();

            // 2. Identify books that are currently below the reorder point
            var booksBelowReorderPoint = await _context.Books
                .Where(b => b.InventoryQuantity < b.ReorderPoint)
                .ToListAsync();

            // 3. Filter: Check if existing copies on order bring the book over the reorder point
            List<Reorder> reordersToPlace = new List<Reorder>();

            foreach (var book in booksBelowReorderPoint)
            {
                int copiesOnOrder = pendingOrders.FirstOrDefault(p => p.BookID == book.BookID)?.CopiesOnOrder ?? 0;

                // Inventory + CopiesOnOrder must be less than ReorderPoint
                if (book.InventoryQuantity + copiesOnOrder < book.ReorderPoint)
                {
                    // Get last cost for default value
                    decimal lastCost = _context.Reorders
                        .Where(r => r.BookID == book.BookID)
                        .OrderByDescending(r => r.Date)
                        .Select(r => r.Cost)
                        .FirstOrDefault();

                    // Create a Reorder object (but don't save it yet)
                    reordersToPlace.Add(new Reorder
                    {
                        BookID = book.BookID,
                        Book = book,
                        Cost = (lastCost > 0) ? lastCost : 0.01m,
                        Quantity = 5, // Default number of new copies
                        ReorderStatus = ReorderStatus.Ordered
                    });
                }
            }

            // Pass the list of prospective reorders to a view where Admin can edit quantities/costs
            return View("ReviewAutomaticOrders", reordersToPlace);
        }

        // POST: Reorders/PlaceAutomaticOrders
        [HttpPost]
        [ValidateAntiForgeryToken]
        // This action receives a list of Reorder objects (potentially via a ViewModel)
        public async Task<IActionResult> PlaceAutomaticOrders(List<Reorder> reorders)
        {
            if (reorders == null || !reorders.Any())
            {
                TempData["ErrorMessage"] = "No reorders were submitted.";
                return RedirectToAction(nameof(Index));
            }

            int count = 0;
            foreach (var r in reorders.Where(r => r.Quantity > 0))
            {
                // Set final properties and add to context
                r.Date = DateTime.Now;
                r.ReorderStatus = ReorderStatus.Ordered;
                r.QuantityReceived = 0;
                _context.Reorders.Add(r);
                count++;
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully placed {count} automatic orders.";
            return RedirectToAction(nameof(Index));
        }

        // --- TRACKING AND RECEIVING BOOKS ---

        // GET: Reorders/ViewBooksOnOrder
        public async Task<IActionResult> ViewBooksOnOrder()
        {
            // List all Reorders that are not yet Fully Received
            var booksOnOrder = await _context.Reorders
                .Include(r => r.Book)
                .Where(r => r.ReorderStatus != ReorderStatus.FullyReceived)
                .OrderBy(r => r.Date)
                .ToListAsync();

            return View(booksOnOrder);
        }

        // POST: Reorders/BookArrival/5
        // Handles checking books in at the loading dock
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Binds only the ReorderID and the quantity that just arrived
        public async Task<IActionResult> BookArrival(int ReorderID, int CopiesArrived)
        {
            Reorder reorder = await _context.Reorders.Include(r => r.Book).FirstOrDefaultAsync(r => r.ReorderID == ReorderID);

            if (reorder == null) return NotFound();

            // Calculate the actual number to accept (cannot accept more than ordered)
            int remainingToReceive = reorder.Quantity - reorder.QuantityReceived;
            int acceptedCopies = Math.Min(CopiesArrived, remainingToReceive);

            if (acceptedCopies <= 0)
            {
                TempData["ErrorMessage"] = $"No copies were accepted for Reorder {ReorderID}.";
                return RedirectToAction(nameof(ViewBooksOnOrder));
            }

            // 1. Update Inventory (use the accepted copies, not the arrival quantity)
            reorder.Book.InventoryQuantity += acceptedCopies;

            // 2. Update Reorder Status
            reorder.QuantityReceived += acceptedCopies;

            if (reorder.QuantityReceived == reorder.Quantity)
            {
                reorder.ReorderStatus = ReorderStatus.FullyReceived;
            }
            else if (reorder.QuantityReceived > 0 && reorder.QuantityReceived < reorder.Quantity)
            {
                reorder.ReorderStatus = ReorderStatus.PartiallyReceived;
            }
            // Note: The excess copies are assumed to be returned, per requirements.

            // 3. Update the Book's Weighted Average Cost (WAC) - CRUCIAL
            // This logic is complex and should ideally be in a service/utility.
            // Simplified WAC update: (Old Stock * Old WAC) + (New Stock * New Cost) / (Old Stock + New Stock)
            /*
            decimal oldWAC = reorder.Book.Cost; // The old WAC is stored in the Cost field of the Book model
            decimal totalOldValue = oldWAC * (reorder.Book.InventoryQuantity - acceptedCopies);
            decimal totalNewValue = reorder.Cost * acceptedCopies;
            int newTotalStock = reorder.Book.InventoryQuantity;

            reorder.Book.Cost = (totalOldValue + totalNewValue) / newTotalStock;
            */

            // 4. Save changes
            _context.Update(reorder.Book);
            _context.Update(reorder);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Successfully checked in {acceptedCopies} copies for {reorder.Book.Title}.";
            return RedirectToAction(nameof(ViewBooksOnOrder));
        }
    }
}