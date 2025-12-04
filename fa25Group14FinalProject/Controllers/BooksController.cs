using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
            // Note: This action should be expanded with robust search, filter, and sort functionality.
            var books = await _context.Books
                                      .Include(b => b.Genre)
                                      .ToListAsync();

            ViewBag.RecordCount = books.Count;
            return View(books);
        }
        [HttpGet]
        public IActionResult Search()
        {
            SearchViewModel svm = new SearchViewModel();

            SelectList genreSelectList = new SelectList(_context.Genres, "GenreID", "GenreName");
            ViewBag.GenreSelectList = genreSelectList;
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

            return View("Index", books);   // <-- return to Index view!
        }


        [HttpPost]
        public IActionResult DisplaySearchResults(SearchViewModel svm)
        {
            // Basic query
            var query = from b in _context.Books
                        select b;

            // Search by Title
            if (!String.IsNullOrEmpty(svm.Title))
            {
                query = query.Where(b => b.Title.Contains(svm.Title));
            }

            // Search by Author
            if (!String.IsNullOrEmpty(svm.Authors))
            {
                query = query.Where(b => b.Authors.Contains(svm.Authors));
            }

            // Combination: Title + Author
            if (!String.IsNullOrEmpty(svm.Title) && !String.IsNullOrEmpty(svm.Authors))
            {
                query = query.Where(b => b.Title.Contains(svm.Title) &&
                                         b.Authors.Contains(svm.Authors));
            }

            // Search by Unique Number
            if (svm.BookNumber.HasValue)
            {
                query = query.Where(b => b.BookNumber == svm.BookNumber);
            }

            // Genre (ONE and ONLY ONE genre)
            if (svm.GenreID.HasValue)
            {
                query = query.Where(b => b.GenreID == svm.GenreID);
            }

            // Filter: In Stock ONLY
            if (svm.InStockOnly == true)
            {
                query = query.Where(b => b.InStock == true);
            }

            // Sorting options
            switch (svm.SortOption)
            {
                case SearchViewModel.SortType.Title:
                    query = query.OrderBy(b => b.Title);
                    break;

                case SearchViewModel.SortType.Author:
                    query = query.OrderBy(b => b.Authors);
                    break;

                case SearchViewModel.SortType.MostPopular:
                    query = query.OrderByDescending(b => b.TimesPurchased);
                    break;

                case SearchViewModel.SortType.Newest:
                    query = query.OrderByDescending(b => b.PublishDate);
                    break;

                case SearchViewModel.SortType.Oldest:
                    query = query.OrderBy(b => b.PublishDate);
                    break;

                case SearchViewModel.SortType.HighestRated:
                    query = query.OrderByDescending(b => b.Rating);
                    break;
            }

            // Execute query and include navigation properties
            List<Book> SelectedBooks = query
                .Include(b => b.Genre)
                .ToList();

            // Re-set the ViewBag for Genre list (needed because the view requires it)
            SelectList genreSelectList = new SelectList(_context.Genres, "GenreID", "GenreName");
            ViewBag.GenreSelectList = genreSelectList;

            // *** CRITICAL: Set the list of books in the same ViewBag property ***
            ViewBag.InitialBookList = SelectedBooks;

            // Record count: "Showing X of Y Books"
            ViewBag.AllBooks = _context.Books.Count();
            ViewBag.SelectedBooks = SelectedBooks.Count();

            // Return search results to Index view
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
                .Include(b => b.Reviews.Where(r => r.IsApproved == true)) // Only approved reviews for customers/employees
                .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            // Calculate the average rating (to 1 decimal place) [cite: 202, 203]
            var approvedReviews = book.Reviews.Where(r => r.IsApproved == true).ToList();

            if (approvedReviews.Any())
            {
                // Calculate simple average of approved customer ratings
                decimal averageRating = (decimal)approvedReviews.Average(r => r.Rating);

                // Round to 1 decimal place (e.g. 4.3, 3.2)
                ViewBag.AverageRating = Math.Round(averageRating, 1);
            }
            else
            {
                ViewBag.AverageRating = "N/A";
            }

            // The view logic will check the user role to display Cost/Profit (Admin only) 
            // and the Add to Cart/Write Review options (Customer only).

            return View(book);
        }

        // --- ADMIN FUNCTIONALITY (CREATE/EDIT) ---

        // GET: Books/Create
        [Authorize(Roles = "Admin")] // Only Admins can manage books
        public IActionResult Create()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,BookNumber,Title,Description,Price,Cost,PublishDate,InventoryQuantity,ReorderPoint,Authors,BookStatus,GenreID")] Book book)
        {
            // Note: Logic to auto-assign the next sequential Unique Number should be implemented here.

            if (ModelState.IsValid)
            {
                // Ensure Book cost must be greater than zero [cite: 346]
                if (book.Cost <= 0)
                {
                    ModelState.AddModelError("Cost", "Book cost must be greater than zero.");
                    ViewBag.AllGenres = GetAllGenres();
                    return View(book);
                }

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

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

            // Admins can edit all information about any book, except the automatically generated unique number field[cite: 308].
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
        public async Task<IActionResult> Edit(int id, [Bind("BookID,BookNumber,Title,Description,Price,Cost,PublishDate,InventoryQuantity,ReorderPoint,Authors,BookStatus,GenreID")] Book book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            // 1. Fetch the book from the DB to preserve fields not allowed to be edited (like UniqueNumber)
            Book bookToUpdate = _context.Books.FirstOrDefault(b => b.BookID == book.BookID);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            // 2. Check for Cost validation
            if (book.Cost <= 0)
            {
                ModelState.AddModelError("Cost", "Book cost must be greater than zero.");
            }

            if (ModelState.IsValid)
            {
                // 3. Update scalar properties (UniqueNumber is not updated)
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.Price = book.Price;
                bookToUpdate.Cost = book.Cost; // Updates Weighted Average Cost
                bookToUpdate.PublishDate = book.PublishDate;
                bookToUpdate.InventoryQuantity = book.InventoryQuantity;
                bookToUpdate.ReorderPoint = book.ReorderPoint;
                bookToUpdate.Authors = book.Authors;
                bookToUpdate.BookStatus = book.BookStatus; // Discontinued status
                bookToUpdate.GenreID = book.GenreID;

                try
                {
                    _context.Update(bookToUpdate);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }

            ViewBag.AllGenres = GetAllGenres(book.GenreID);
            return View(book);
        }

        // --- HELPER METHODS ---

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
            // Get all genres from the database
            List<Genre> genres = _context.Genres.OrderBy(g => g.GenreName).ToList();

            // Create the SelectList object, using the selectedID to pre-select the genre
            SelectList allGenres = new SelectList(genres, "GenreID", "GenreName", selectedID);

            return allGenres;
        }
    }
}