using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using Microsoft.AspNetCore.Identity;

namespace fa25Group14FinalProject.Controllers
{
    // Only customers who have purchased a book can write a review.
    //removed for milestone 6
    [Authorize(Roles = "Customer")]
    public class ReviewsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReviewsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Helper: Get the current logged-in user ID
        private String GetUserID()
        {
            return _userManager.GetUserId(User);
        }

        //index method - added for milestone 6
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Reviews/Create/5 (Display the form to write a review for a specific book ID)
        public async Task<IActionResult> Create(int? bookID)
        {
            if (bookID == null)
            {
                return NotFound();
            }

            // 1. Authorization Check: Customers are limited to rating books they have purchased. [cite: 200]
            string userID = GetUserID();

            // Check if the customer has placed a shipped order containing this book.
            bool hasPurchased = await _context.OrderDetails
                .Where(od => od.BookID == bookID &&
                             od.Order.CustomerID == userID &&
                             od.Order.OrderStatus == OrderStatus.Ordered) // Check against finalized orders
                .AnyAsync();

            if (!hasPurchased)
            {
                TempData["ErrorMessage"] = "You can only review books you have purchased.";
                return RedirectToAction("Details", "Books", new { id = bookID });
            }

            // 2. Check: A customer can only review a book once. [cite: 204]
            bool alreadyReviewed = await _context.Reviews
                .Where(r => r.BookID == bookID && r.ReviewerID == userID)
                .AnyAsync();

            if (alreadyReviewed)
            {
                TempData["ErrorMessage"] = "You have already submitted a review for this book and cannot change it.";
                return RedirectToAction("Details", "Books", new { id = bookID });
            }

            // Fetch book details for the view display
            Book book = await _context.Books.FindAsync(bookID);

            // Pre-populate the Review model
            Review newReview = new Review { BookID = bookID.Value, Book = book, ReviewDate = DateTime.Now };

            return View(newReview);
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID, Rating, ReviewText")] Review review)
        {
            // Set required foreign keys and internal properties
            review.ReviewerID = GetUserID();
            review.ReviewDate = DateTime.Now;
            review.IsApproved = null; // Reviews must be approved by an employee before they show up. [cite: 201]

            // Remove navigational properties from model state validation
            ModelState.Remove("Reviewer");
            ModelState.Remove("Book");

            // Re-check purchase authorization and single review rule inside POST (security)
            if (!ModelState.IsValid || !HasPurchasedAndNotReviewed(review.BookID, review.ReviewerID))
            {
                TempData["ErrorMessage"] = "Invalid submission. Please ensure you have purchased the book and have not reviewed it previously.";
                review.Book = await _context.Books.FindAsync(review.BookID);
                return View(review);
            }

            // IMPORTANT: If writing a review, the customer must include a rating on a scale of 1-5 (whole numbers). [cite: 198]
            // Review model validation annotations should enforce Rating and ReviewText length (100 characters). [cite: 199]

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Review submitted successfully! It will appear on the website once approved by an employee.";

            return RedirectToAction("Details", "Books", new { id = review.BookID });
        }

        // --- HELPER METHOD ---

        // Helper to check the purchase and single-review constraint inside the POST
        private bool HasPurchasedAndNotReviewed(int bookID, string userID)
        {
            // Check if customer has placed a shipped order containing this book.
            bool hasPurchased = _context.OrderDetails
                .Where(od => od.BookID == bookID &&
                             od.Order.CustomerID == userID &&
                             od.Order.OrderStatus == OrderStatus.Ordered)
                .Any();

            // Check if already reviewed
            bool alreadyReviewed = _context.Reviews
                .Where(r => r.BookID == bookID && r.ReviewerID == userID)
                .Any();

            return hasPurchased && !alreadyReviewed;
        }
    }
}