using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static fa25Group14FinalProject.ViewModels.SearchViewModel;

namespace fa25Group14FinalProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // --- CUSTOMER & EMPLOYEE FUNCTIONALITY (SEARCH/INDEX/DETAILS) ---

        // GET: Books - Accessible by everyone
        public async Task<IActionResult> Index()
        {
            // Include Genre AND Reviews so we can compute ratings in the view
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
                .Include(b => b.Reviews.Where(r => r.IsApproved == true))
                .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            // We now compute the average rating in the view itself,
            // so ViewBag.AverageRating is no longer strictly necessary.
            // (Leaving this in case something else still uses it.)
            var approvedReviews = book.Reviews.Where(r => r.IsApproved == true).ToList();

            if (approvedReviews.Any())
            {
                decimal averageRating = (decimal)approvedReviews.Average(r => r.Rating);
                ViewBag.AverageRating = Math.Round(averageRating, 1);
            }
            else
            {
                ViewBag.AverageRating = "N/A";
            }

            return View(book);
        }

        // --- ADMIN FUNCTIONALITY (CREATE/EDIT) ---

        // Inside your BooksController.cs

        // GET: Books/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            // --- 1. Unique Book Number Calculation ---
            // Unique numbers start at 222001. Seed data runs from 222001-222300[cite: 299].
                        // The next book added MUST be 222301.

            const int LastSeedBookNumber = 222300;
            int nextBookNumber = LastSeedBookNumber;

            try
            {
                // Check if there are any books in the database to calculate the max number
                if (await _context.Books.AnyAsync())
                {
                    int maxBookNumber = await _context.Books.MaxAsync(b => b.BookNumber);
                    // We use Math.Max to ensure we don't start counting backwards if the seed data 
                    // has a higher number than manually entered books (though unlikely).
                    nextBookNumber = Math.Max(maxBookNumber, LastSeedBookNumber);
                }

                // Store the calculated next number (current max + 1)
                ViewBag.NextBookNumber = nextBookNumber + 1;
            }
            catch (Exception ex)
            {
                // If the database connection or query fails, the ViewBag remains null or you can set a flag
                // Log the exception (ex) here for debugging purposes.
                ViewBag.NextBookNumber = null; // Forces the error message in the view
            }

            // --- 2. Genre List for Dropdown ---
            // Assuming GetAllGenres() returns an appropriate SelectList
            ViewBag.AllGenres = GetAllGenres();

            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            // The Admin is never allowed to set the InventoryQuantity directly during creation.
            // It must start at 0 until an order is received.
            book.InventoryQuantity = 0;

            // --- 1. Unique Book Number Assignment Logic ---
            // The next book added MUST be 222301[cite: 299].

            const int LastSeedBookNumber = 222300;
            int nextBookNumber = LastSeedBookNumber;

            // Find the current highest BookNumber in the database
            if (_context.Books.Any())
            {
                int maxBookNumber = await _context.Books.MaxAsync(b => b.BookNumber);
                // Ensure we start counting from where the seed data ended (222300)
                nextBookNumber = Math.Max(maxBookNumber, LastSeedBookNumber);
            }

            // *** FIX: Assign the calculated number to the book object being saved ***
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
                // Once a new title has been added, the admin can order copies of the book[cite: 296].

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

        // POST: Books/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            // 🔹 NOTE: InventoryQuantity REMOVED from the Bind list
            [Bind("BookID,BookNumber,Title,Description,Price,Cost,PublishDate,ReorderPoint,Authors,BookStatus,GenreID")]
    Book book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            // Fetch the book from the DB to preserve fields not allowed to be edited
            Book bookToUpdate = _context.Books.FirstOrDefault(b => b.BookID == book.BookID);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

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
                // 🔸 DO NOT TOUCH InventoryQuantity here – it is maintained via reorders
                bookToUpdate.ReorderPoint = book.ReorderPoint;
                bookToUpdate.Authors = book.Authors;
                bookToUpdate.BookStatus = book.BookStatus;
                bookToUpdate.GenreID = book.GenreID;

                try
                {
                    _context.Update(bookToUpdate);
                    await _context.SaveChangesAsync();

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

                // ✅ After saving, go back to the searchable list, not the plain index
                return RedirectToAction("Search", "Books");
            }

            // If validation fails, rebuild dropdown and redisplay form
            ViewBag.AllGenres = GetAllGenres(book.GenreID);
            return View(book);
        }


        // --- HELPER METHODS ---

        // inside BooksController
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

            if (svm.BookNumber.HasValue)
            {
                query = query.Where(b => b.BookNumber == svm.BookNumber);
            }

            if (svm.GenreID.HasValue)
            {
                query = query.Where(b => b.GenreID == svm.GenreID);
            }

            if (svm.InStockOnly == true)
            {
                query = query.Where(b => b.InventoryQuantity > 0);
            }

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
