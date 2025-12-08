using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.Utilities;
using fa25Group14FinalProject.ViewModels;
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
using fa25Group14FinalProject.Utilities;
using static fa25Group14FinalProject.ViewModels.SearchViewModel;

namespace fa25Group14FinalProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BooksController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // --- CUSTOMER & EMPLOYEE FUNCTIONALITY (SEARCH/INDEX/DETAILS) ---

        // GET: Books - Accessible by everyone
        public async Task<IActionResult> Index()
        {
            // The Index view is often just the initial view, leading to search.
            var books = await _context.Books
                                         .Include(b => b.Genre)
                                         .Include(b => b.Reviews)
                                         .ToListAsync();

            ViewBag.RecordCount = books.Count;
            ViewBag.AllBooks = books.Count;
            ViewBag.SelectedBooks = books.Count;

            return View(books);
        }

        [HttpGet]
        public IActionResult Search()
        {
            SearchViewModel svm = new SearchViewModel();

            SelectList genreSelectList = new SelectList(_context.Genres, "GenreID", "GenreName");
            ViewBag.GenreSelectList = genreSelectList;

            // Load all books + reviews for initial list
            List<Book> allBooks = _context.Books
                                        .Include(b => b.Genre)
                                        .Include(b => b.Reviews)
                                        .ToList();

            ViewBag.InitialBookList = allBooks;
            ViewBag.AllBooks = allBooks.Count;
            ViewBag.SelectedBooks = allBooks.Count;

            // Set the default search mode for the view (used in the partial view)
            ViewBag.SearchMode = User.IsInRole("Admin") ? "admin" : (User.IsInRole("Employee") ? "employee" : "customer");

            return View(svm);
        }

        [HttpGet]
        public IActionResult DisplaySearchResults()
        {
            // This means "show ALL books"
            var books = _context.Books
                                 .Include(b => b.Genre)
                                 .Include(b => b.Reviews)
                                 .ToList();

            ViewBag.AllBooks = books.Count;
            ViewBag.SelectedBooks = books.Count;

            // Re-use the Search view model with empty filters
            SearchViewModel svm = new SearchViewModel();
            SelectList genreSelectList = new SelectList(_context.Genres, "GenreID", "GenreName");
            ViewBag.GenreSelectList = genreSelectList;
            ViewBag.InitialBookList = books;
            ViewBag.SearchMode = User.IsInRole("Admin") ? "admin" : (User.IsInRole("Employee") ? "employee" : "customer");

            return View("Search", svm);
        }

        [HttpPost]
        public IActionResult DisplaySearchResults(SearchViewModel svm)
        {
            var query = BuildBookSearchQuery(svm);
            List<Book> SelectedBooks = query.ToList();

            if (svm.SortOption == SortType.MostPopular)
            {
                SelectedBooks = SelectedBooks
                    .OrderByDescending(b => b.TimesPurchased)
                    .ToList();
            }
            else if (svm.SortOption == SortType.HighestRated)
            {
                // Rating is a computed property based on Reviews – must sort in memory
                SelectedBooks = SelectedBooks
                    .OrderByDescending(b => b.Rating ?? 0.0)
                    .ToList();
            }

                SelectList genreSelectList = new SelectList(_context.Genres, "GenreID", "GenreName");
            ViewBag.GenreSelectList = genreSelectList;

            ViewBag.InitialBookList = SelectedBooks;
            ViewBag.AllBooks = _context.Books.Count();
            ViewBag.SelectedBooks = SelectedBooks.Count();
            ViewBag.SearchMode = User.IsInRole("Admin") ? "admin" : (User.IsInRole("Employee") ? "employee" : "customer");

            return View("Search", svm);
        }


        // GET: Books/Details/5 - Accessible by everyone
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include Genre and Reviews (only approved ones for public view)
            var book = await _context.Books
                .Include(b => b.Genre)
                // Note: Filtering on Include is functional but filtering the collection after Fetch is safer.
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null)
            {
                return NotFound();
            }
            bool alreadyInCart = false;

            if (User.Identity.IsAuthenticated && User.IsInRole("Customer"))
            {
                string currentUserId = _userManager.GetUserId(User);

                alreadyInCart = await _context.Orders
                    .Where(o => o.CustomerID == currentUserId &&
                                o.OrderStatus == OrderStatus.InCart)
                    .SelectMany(o => o.OrderDetails)
                    .AnyAsync(od => od.BookID == book.BookID);
            }

            ViewBag.AlreadyInCart = alreadyInCart;

            // --- Rating Calculation Fix ---
            var approvedReviews = book.Reviews.Where(r => r.IsApproved == true).ToList();

            if (approvedReviews.Any())
            {
                decimal averageRating = (decimal)approvedReviews.Average(r => r.Rating);

                // Fix: Explicitly round to 1 decimal place .
                ViewBag.AverageRating = Math.Round(averageRating, 1);
            }
            else
            {
                ViewBag.AverageRating = "N/A";
            }

            return View(book);
        }

        // --- ADMIN FUNCTIONALITY (CREATE/EDIT) ---

        // GET: Books/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            // --- 1. Unique Book Number Calculation (for display) ---
            const int LastSeedBookNumber = 222300;
            int nextBookNumber = LastSeedBookNumber;

            try
            {
                // Check if there are any books in the database to calculate the max number
                if (await _context.Books.AnyAsync())
                {
                    int maxBookNumber = await _context.Books.MaxAsync(b => b.BookNumber);
                    // Ensure we start counting from where the seed data ended (222300)
                    nextBookNumber = Math.Max(maxBookNumber, LastSeedBookNumber);
                }

                // Store the calculated next number (current max + 1)
                ViewBag.NextBookNumber = nextBookNumber + 1;
            }
            catch (Exception)
            {
                // If the database connection or query fails, set to null to trigger error message in view
                ViewBag.NextBookNumber = null;
            }

            // --- 2. Genre List for Dropdown ---
            ViewBag.AllGenres = GetAllGenres();

            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        // Note: BookNumber and InventoryQuantity removed from Bind attribute (handled internally)
        public async Task<IActionResult> Create(Book book)
        {
            // The InventoryQuantity must start at 0 until an order is received.
            book.InventoryQuantity = 0;

            // --- 1. Unique Book Number Assignment Logic ---
            const int LastSeedBookNumber = 222300;
            int nextBookNumber = LastSeedBookNumber;

            // Find the current highest BookNumber in the database
            if (_context.Books.Any())
            {
                int maxBookNumber = await _context.Books.MaxAsync(b => b.BookNumber);
                nextBookNumber = Math.Max(maxBookNumber, LastSeedBookNumber);
            }

            // ASSIGN the calculated number to the book object being saved (current max + 1)
            book.BookNumber = nextBookNumber + 1;


            // --- 2. Validation and Save Logic ---

            // Validate Book Cost
             if (book.Cost <= 0) // Requirement: Book costs must be greater than zero[cite: 346].
            {
                ModelState.AddModelError("Cost", "Book cost must be greater than zero.");
            }

            // Check if the GenreID is valid (Assuming GenreID field is required)
            if (book.GenreID == 0)
            {
                ModelState.AddModelError("GenreID", "Please select or create a genre for the book.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();

                // --- 3. Redirect to Procurement ---
                // Once a new title has been added, the admin can order copies of the book.

                TempData["SuccessMessage"] = $"Book '{book.Title}' created successfully with Unique Number {book.BookNumber}. You must now order initial copies.";

                // Redirect to the OrderBook action in the Reorders controller for manual order placement
                return RedirectToAction("OrderBook", "Reorders", new { id = book.BookID });
            }

            // If ModelState is invalid (error path):
            // We must pass the calculated next number back to the view for display (even though it won't be saved)
            ViewBag.NextBookNumber = book.BookNumber; // Use the calculated number for the display
            ViewBag.AllGenres = GetAllGenres();
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Admin")] // Only Admins can edit books
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = await _context.Books
                                        .Include(b => b.Genre)
                                        .FirstOrDefaultAsync(b => b.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            ViewBag.AllGenres = GetAllGenres(book.GenreID);
            return View(book);
        }
        private async Task HandleBookDiscontinuedAsync(Book discontinuedBook)
        {
            // Find all *in-cart* orders that contain this book
            var affectedCarts = await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderStatus == OrderStatus.InCart &&
                            o.OrderDetails.Any(od => od.BookID == discontinuedBook.BookID))
                .ToListAsync();

            if (!affectedCarts.Any()) return;

            foreach (var cart in affectedCarts)
            {
                // Remove the discontinued book from the cart
                var detailsToRemove = cart.OrderDetails
                    .Where(od => od.BookID == discontinuedBook.BookID)
                    .ToList();

                _context.OrderDetails.RemoveRange(detailsToRemove);

                // Look up the customer from the Users table (no login needed)
                var customer = await _context.Users.FirstOrDefaultAsync(u => u.Id == cart.CustomerID);
                if (customer != null)
                {
                    var body = new StringBuilder();
                    body.AppendLine($"Hi {customer.FirstName},");
                    body.AppendLine();
                    body.AppendLine($"The book '{discontinuedBook.Title}' by {discontinuedBook.Authors} ");
                    body.AppendLine("was discontinued and has been removed from your cart.");
                    body.AppendLine();
                    body.AppendLine("You can visit Bevo's Books anytime to continue shopping.");
                    body.AppendLine("Team 14 – Bevo's Books");

                    string subject = "Team 14: Cart Update – Items Removed";
                    await EmailUtils.SendEmailAsync(customer.Email, subject, body.ToString());
                }
            }

            // Persist cart changes
            await _context.SaveChangesAsync();
        }

        // POST: Books/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            // 🔹 NOTE: BookNumber and InventoryQuantity REMOVED from the Bind list
            [Bind("BookID,Title,Description,Price,Cost,PublishDate,ReorderPoint,Authors,BookStatus,GenreID")]
        Book book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            // Fetch the book from the DB to preserve fields not allowed to be edited (Unique #, Inventory)
            // We use AsNoTracking() to prevent tracking issues when we fetch bookToUpdate and then update it.
            Book bookToUpdate = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.BookID == book.BookID);

            if (bookToUpdate == null)
            {
                return NotFound();
            }
            bool wasDiscontinuedBefore = bookToUpdate.BookStatus;
            // Cost validation
            if (book.Cost <= 0)
            {
                ModelState.AddModelError("Cost", "Book cost must be greater than zero.");
            }

            if (ModelState.IsValid)
            {
                // 🔹 Update only the editable fields
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.Price = book.Price;
                bookToUpdate.Cost = book.Cost;
                bookToUpdate.PublishDate = book.PublishDate;
                bookToUpdate.ReorderPoint = book.ReorderPoint;
                bookToUpdate.Authors = book.Authors;
                bookToUpdate.BookStatus = book.BookStatus;
                bookToUpdate.GenreID = book.GenreID;

                // 🔸 Preserve Non-Editable Fields by attaching the original entity and updating specific properties
                // This is generally done implicitly, but if tracking issues arise, you can explicitly detach/attach or manually set.

                try
                {
                    // Attach and update the entity with only the properties that changed
                    _context.Update(bookToUpdate);
                    await _context.SaveChangesAsync();
                    if (!wasDiscontinuedBefore && bookToUpdate.BookStatus == true)
                    {
                        await HandleBookDiscontinuedAsync(bookToUpdate);
                    }
                    TempData["Message"] = $"Book '{bookToUpdate.Title}' was successfully updated.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(bookToUpdate.BookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // ✅ After saving, go back to the searchable list
                return RedirectToAction("Search", "Books");
            }

            // If validation fails, rebuild dropdown and redisplay form
            ViewBag.AllGenres = GetAllGenres(book.GenreID);
            return View(book);
        }


        // --- HELPER METHODS ---

        private IQueryable<Book> BuildBookSearchQuery(SearchViewModel svm)
        {
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

            // Search by unique number (used instead of ISBN)
            if (svm.BookNumber.HasValue)
            {
                query = query.Where(b => b.BookNumber == svm.BookNumber);
            }

            // Search by genre ID
            if (svm.GenreID.HasValue)
            {
                query = query.Where(b => b.GenreID == svm.GenreID);
            }

            // Filter to see only items in stock [cite: 96]
            if (svm.InStockOnly == true)
            {
                query = query.Where(b => b.InventoryQuantity > 0);
            }

            // Discontinued books are always shown unless filtered
            // Discontinued books still show up in search results [cite: 302-303]
            // Your current logic is correct as it doesn't filter by BookStatus.

            switch (svm.SortOption)
            {
                case SearchViewModel.SortType.Title:
                    query = query.OrderBy(b => b.Title);
                    break;
                case SearchViewModel.SortType.Author:
                    query = query.OrderBy(b => b.Authors);
                    break;
                case SearchViewModel.SortType.MostPopular:
                    break;
                case SearchViewModel.SortType.Newest:
                    query = query.OrderByDescending(b => b.PublishDate);
                    break;
                case SearchViewModel.SortType.Oldest:
                    query = query.OrderBy(b => b.PublishDate);
                    break;
                case SearchViewModel.SortType.HighestRated:
                    break;
            }

            return query.Include(b => b.Genre);
        }


        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }

        private SelectList GetAllGenres()
        {
            return GetAllGenres(0);
        }

        private SelectList GetAllGenres(int selectedID)
        {
            List<Genre> genres = _context.Genres.OrderBy(g => g.GenreName).ToList();
            SelectList allGenres = new SelectList(genres, "GenreID", "GenreName", selectedID);
            return allGenres;
        }
    }
}