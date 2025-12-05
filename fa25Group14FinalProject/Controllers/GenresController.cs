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
        public IActionResult Create(int? bookId)
        {
            ViewBag.ReturnBookId = bookId;
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreID,GenreName")] Genre genre, int? bookId)
        {
            if (ModelState.IsValid)
            {
                // Check if genre name already exists (case-insensitive)
                var exists = await _context.Genres.AnyAsync(g => g.GenreName.ToLower() == genre.GenreName.ToLower());
                if (exists)
                {
                    ModelState.AddModelError("GenreName", "A genre with this name already exists.");
                    ViewBag.ReturnBookId = bookId;
                    return View(genre);
                }

                _context.Add(genre);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Genre created successfully.";
                if (bookId.HasValue)
                {
                    return RedirectToAction("Edit", "Books", new { id = bookId.Value });
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ReturnBookId = bookId;
            return View(genre);
        }
    }
}
