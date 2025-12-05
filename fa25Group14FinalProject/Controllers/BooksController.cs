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
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.Price = book.Price;
                bookToUpdate.Cost = book.Cost;
                bookToUpdate.PublishDate = book.PublishDate;
                bookToUpdate.InventoryQuantity = book.InventoryQuantity;
                bookToUpdate.ReorderPoint = book.ReorderPoint;
                bookToUpdate.Authors = book.Authors;
                bookToUpdate.BookStatus = book.BookStatus;
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
