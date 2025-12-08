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
        [HttpGet]
        public async Task<IActionResult> ManualOrder()
        {
            var books = await _context.Books
                                      .Include(b => b.Genre)
                                      .Include(b => b.Reviews)
                                      .OrderBy(b => b.Title)
                                      .ToListAsync();

            var svm = new fa25Group14FinalProject.ViewModels.SearchViewModel();

            ViewBag.InitialBookList = books;
            ViewBag.AllBooks = books.Count;
            ViewBag.SelectedBooks = books.Count;
            ViewBag.GenreSelectList = new SelectList(_context.Genres, "GenreID", "GenreName");

            return View(svm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManualOrder(fa25Group14FinalProject.ViewModels.SearchViewModel svm)
        {
            // Start with Books + Reviews so we can compute ratings if needed
            var query = _context.Books
                                .Include(b => b.Reviews)
                                .AsQueryable();

            if (!String.IsNullOrEmpty(svm.Title))
            {
                query = query.Where(b => b.Title.Contains(svm.Title));
            }

            if (!String.IsNullOrEmpty(svm.Authors))
            {
                query = query.Where(b => b.Authors.Contains(svm.Authors));
            }

            if (svm.BookNumber.HasValue)
            {
                query = query.Where(b => b.BookNumber == svm.BookNumber);
            }

            if (svm.GenreID.HasValue)
            {
                query = query.Where(b => b.GenreID == svm.GenreID);
            }

            // NOTE: For procurement, you probably do NOT want to filter out out-of-stock books,
            // because you are trying to reorder them. So we ignore svm.InStockOnly here.

            switch (svm.SortOption)
            {
                case fa25Group14FinalProject.ViewModels.SearchViewModel.SortType.Title:
                    query = query.OrderBy(b => b.Title);
                    break;
                case fa25Group14FinalProject.ViewModels.SearchViewModel.SortType.Author:
                    query = query.OrderBy(b => b.Authors);
                    break;
                case fa25Group14FinalProject.ViewModels.SearchViewModel.SortType.MostPopular:
                    query = query.OrderByDescending(b => b.TimesPurchased);
                    break;
                case fa25Group14FinalProject.ViewModels.SearchViewModel.SortType.Newest:
                    query = query.OrderByDescending(b => b.PublishDate);
                    break;
                case fa25Group14FinalProject.ViewModels.SearchViewModel.SortType.Oldest:
                    query = query.OrderBy(b => b.PublishDate);
                    break;
                case fa25Group14FinalProject.ViewModels.SearchViewModel.SortType.HighestRated:
                    query = query.OrderByDescending(b => b.Rating);
                    break;
            }

            var selectedBooks = query
                .Include(b => b.Genre)
                .ToList();

            ViewBag.InitialBookList = selectedBooks;
            ViewBag.AllBooks = _context.Books.Count();
            ViewBag.SelectedBooks = selectedBooks.Count();
            ViewBag.SearchMode = "procurement";
            ViewBag.GenreSelectList = new SelectList(_context.Genres, "GenreID", "GenreName");

            return View("ManualOrder", svm); // returns Views/Reorders/ManualOrder.cshtml
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

            decimal avgProfitMargin = await CalculateAvgProfitMargin(book.BookID);
            ViewBag.AvgProfitMargin = avgProfitMargin.ToString("C"); // Format as Currency for the View

            // Create a new Reorder object for the form input
            Reorder reorder = new Reorder
            {
                BookID = book.BookID,
                Book = book,
                Cost = (lastCost > 0) ? lastCost : book.Cost, // Book costs must be greater than zero.
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
            // Ensure cost is greater than zero
            if (reorder.Cost <= 0) // Requirement: Book costs must be greater than zero [cite: 224]
            {
                ModelState.AddModelError("Cost", "Book cost must be greater than zero.");
            }
            // Ensure quantity is greater than zero
            // NOTE: For manual order, the Admin orders a quantity, so it must be > 0.
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

            // --- FIX: Reload the view with errors, ensuring all view data is present ---

            // 1. Reload the Book object completely (needed for Title, Authors, Selling Price, etc., in the view)
            reorder.Book = await _context.Books
                                         .Include(b => b.Reorders) // Required for getting last cost if you rebuild the view
                                         .FirstOrDefaultAsync(b => b.BookID == reorder.BookID);

            if (reorder.Book == null)
            {
                return NotFound();
            }

            // 2. Recalculate and set the required ViewBag data

            // You MUST have the CalculateAvgProfitMargin method implemented in ReordersController.
            // Assuming the method exists:
            decimal avgProfitMargin = await CalculateAvgProfitMargin(reorder.BookID);
            ViewBag.AvgProfitMargin = avgProfitMargin.ToString("C");

            // Note: The Reorder.Cost model property already holds the value the user typed in (even if invalid)
            // so no need to recalculate lastCost here unless you overwrite reorder.Cost.

            // Return the specific view name and the model
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
                        Cost = (lastCost > 0) ? lastCost : book.Cost,
                        Quantity = 5, // Default number of new copies
                        ReorderStatus = ReorderStatus.Ordered
                    });
                }
            }

            // Pass the list of prospective reorders to a view where Admin can edit quantities/costs
            return View("ReviewAutomaticOrders", reordersToPlace);
        }

        // Fulfills the requirement to remove a book from the reorder list by setting its ReorderPoint to 0.
        // ReordersController.cs

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveAndSetReorderPointToZero(int bookId) // Parameter MUST be named 'bookId'
        {
            Book book = await _context.Books.FindAsync(bookId);

            if (book == null)
            {
                TempData["ErrorMessage"] = "Error: Book not found.";
                return RedirectToAction(nameof(AutomaticCheck));
            }

            book.ReorderPoint = 0;

            _context.Update(book);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"'{book.Title}' was removed from the reorder list and its reorder point was set to 0.";

            // This is the line that redirects and refreshes the list:
            return RedirectToAction(nameof(AutomaticCheck));
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
                //r.Book = null;
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

            // 1. Calculate the actual number to accept (cannot accept more than ordered) 
            int remainingToReceive = reorder.Quantity - reorder.QuantityReceived;
            int acceptedCopies = Math.Min(CopiesArrived, remainingToReceive);

            if (acceptedCopies <= 0)
            {
                TempData["ErrorMessage"] = $"No copies were accepted for Reorder {ReorderID} as they were either over-shipped or the quantity was zero.";
                return RedirectToAction(nameof(ViewBooksOnOrder));
            }

            // --- WAC CALCULATION MUST HAPPEN BEFORE INVENTORY QUANTITY IS UPDATED ---

            // WAC Logic: (Old Stock * Old WAC) + (New Stock * New Cost) / (Old Stock + New Stock)
            decimal oldWAC = reorder.Book.Cost;
            // Calculate old stock BEFORE adding new accepted copies
            int oldTotalStock = reorder.Book.InventoryQuantity;

            // Only update WAC if there was existing stock or the new cost is different from the old WAC.
            if (oldTotalStock > 0 || acceptedCopies > 0)
            {
                // Total value of the inventory BEFORE this arrival
                decimal totalOldValue = oldWAC * oldTotalStock;

                // Total value of the new copies received in this reorder
                decimal totalNewValue = reorder.Cost * acceptedCopies;

                // Total quantity after receiving
                int newTotalStock = oldTotalStock + acceptedCopies;

                if (newTotalStock > 0)
                {
                    // Calculate and apply the new WAC
                    reorder.Book.Cost = (totalOldValue + totalNewValue) / newTotalStock;
                }
            }
            // Note: If newTotalStock is 0, the book is considered out of stock, and WAC maintains its last value.

            // --- INVENTORY UPDATE ---

            // 2. Update Inventory Quantity [cite: 243]
            reorder.Book.InventoryQuantity += acceptedCopies;

            // 3. Update Reorder Status
            reorder.QuantityReceived += acceptedCopies;

            if (reorder.QuantityReceived == reorder.Quantity)
            {
                reorder.ReorderStatus = ReorderStatus.FullyReceived; // [cite: 241-242]
            }
            else if (reorder.QuantityReceived > 0 && reorder.QuantityReceived < reorder.Quantity)
            {
                reorder.ReorderStatus = ReorderStatus.PartiallyReceived;
            }
            // Note: Over-shipped copies were already handled by acceptedCopies = Math.Min(...), per requirement[cite: 244].

            // 4. Save changes
            _context.Update(reorder.Book);
            _context.Update(reorder);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Successfully checked in {acceptedCopies} copies for {reorder.Book.Title}.";
            return RedirectToAction(nameof(ViewBooksOnOrder));
        }

        // Helper function to calculate average profit margin from historical sales
        private async Task<decimal> CalculateAvgProfitMargin(int bookId)
        {
            // Fetch all OrderDetails for this book from final orders
            var salesHistory = await _context.OrderDetails
                .Include(od => od.Order)
                .Where(od => od.BookID == bookId && od.Order.OrderStatus == OrderStatus.Ordered)
                .ToListAsync();

            var book = await _context.Books.FindAsync(bookId);

            if (!salesHistory.Any())
            {
                return book.Price - book.Cost;
            }

            // Profit = Total Revenue (based on price at time of order) - Total Cost (based on WAC at time of order)
            decimal totalRevenue = salesHistory.Sum(od => od.Quantity * od.Price);
            decimal totalCost = salesHistory.Sum(od => od.Quantity * od.Cost);
            decimal totalProfit = totalRevenue - totalCost;

            // Margin Percentage: (Profit / Revenue) * 100
            if (totalRevenue == 0) return 0m;

            // Note: The requirement asks for the "average profit margin" number (e.g., $5.00), not the percentage.
            // We will calculate the average profit *per unit sold*.

            int totalQuantitySold = salesHistory.Sum(od => od.Quantity);

            if (totalQuantitySold == 0) return 0m;

            return totalProfit / totalQuantitySold; // Average Profit Margin per unit sold
        }
    }
}