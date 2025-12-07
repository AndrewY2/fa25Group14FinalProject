using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using System.Collections.Generic;
using System;

namespace fa25Group14FinalProject.Controllers
{
    [Authorize (Roles = "Admin")]
    
    public class GenresController : Controller
    {
        private readonly AppDbContext _context;

        public GenresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genres.OrderBy(g => g.GenreName).ToListAsync());
        }

        // GET: Genres/Create
        public IActionResult Create(string returnContext)
        {
            ViewBag.ReturnContext = returnContext; // Pass the context string to the view
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreID,GenreName")] Genre genre, string returnContext)
        {
            // The bookId parameter has been replaced with the string returnContext

            if (ModelState.IsValid)
            {
                // Check if genre name already exists (case-insensitive)
                var exists = await _context.Genres.AnyAsync(g => g.GenreName.ToLower() == genre.GenreName.ToLower());

                if (exists)
                {
                    ModelState.AddModelError("GenreName", "A genre with this name already exists.");
                    // Must reload the return context here for the view
                    ViewBag.ReturnContext = returnContext;
                    return View(genre);
                }

                _context.Add(genre);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Genre created successfully.";

                // --- REVISED REDIRECTION LOGIC ---

                // 1. Check for redirection back to the Books/Create page
                if (returnContext == "BooksCreate")
                {
                    // Redirect back to Books/Create so the Admin can select the new genre
                    return RedirectToAction("Create", "Books");
                }

                // 2. Check for redirection back to a Books/Edit page (if an existing BookID was passed)
                if (int.TryParse(returnContext, out int existingBookId))
                {
                    // Redirect back to Books/Edit using the parsed BookID
                    return RedirectToAction("Edit", "Books", new { id = existingBookId });
                }

                // 3. Default: Redirect to the Genres Index page
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is invalid, reload the return context and return to the view
            ViewBag.ReturnContext = returnContext;
            return View(genre);
        }
    }
}
