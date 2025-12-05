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
    // All actions require authentication; specific role restrictions are placed on each action.
    [Authorize]
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

        // We’ll use Index later if you want "My Reviews"; safe to leave as-is for now.
        public IActionResult Index()
        {
            return View();
        }

        // =======================
        // CUSTOMER: CREATE REVIEW
        // =======================

        // GET: Reviews/Create/5 (Display the form to write a review for a specific book ID)
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(int? bookID)
        {
            if (bookID == null)
            {
                return NotFound();
            }

            string userID = GetUserID();

            // Check if the customer has placed an order containing this book and it is finalized.
            bool hasPurchased = await _context.OrderDetails
                .Where(od => od.BookID == bookID &&
                             od.Order.CustomerID == userID &&
                             od.Order.OrderStatus == OrderStatus.Ordered)
                .AnyAsync();

            if (!hasPurchased)
            {
                TempData["ErrorMessage"] = "You can only review books you have purchased.";
                return RedirectToAction("Details", "Books", new { id = bookID });
            }

            // A customer can only review a book once.
            bool alreadyReviewed = await _context.Reviews
                .Where(r => r.BookID == bookID && r.ReviewerID == userID)
                .AnyAsync();

            if (alreadyReviewed)
            {
                TempData["ErrorMessage"] = "You have already submitted a review for this book and cannot change it.";
                return RedirectToAction("Details", "Books", new { id = bookID });
            }

            // Fetch book details for view display
            Book book = await _context.Books.FindAsync(bookID);
            if (book == null) return NotFound();

            // Pre-populate Review
            Review newReview = new Review
            {
                BookID = bookID.Value,
                Book = book,
                ReviewDate = DateTime.Now
            };

            return View(newReview);
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID, Rating, ReviewText")] Review review)
        {
            // 1. Attach internal fields that are NOT coming from the form
            review.ReviewerID = GetUserID();
            review.ReviewDate = DateTime.Now;
            review.IsApproved = null; // must be approved by employee

            // Because ReviewerID etc. aren't in the form, ModelState may
            // think they're "missing" – clear those specific keys.
            ModelState.Remove("ReviewerID");
            ModelState.Remove("Reviewer");
            ModelState.Remove("Approver");
            ModelState.Remove("ApproverID");
            ModelState.Remove("Book");
            ModelState.Remove("DisputeStatus");
            ModelState.Remove("IsApproved");
            ModelState.Remove("ReviewDate");

            // 2. Validate the basic model (rating + text)
            if (!ModelState.IsValid)
            {
                // Re-load the Book so the view can display title/author
                review.Book = await _context.Books.FindAsync(review.BookID);
                return View(review);
            }

            // 3. Security/business rule: user must have bought the book
            //    and can only review once.
            if (!HasPurchasedAndNotReviewed(review.BookID, review.ReviewerID))
            {
                TempData["ErrorMessage"] = "You can only review books you have purchased and you may only review each book once.";
                return RedirectToAction("Details", "Books", new { id = review.BookID });
            }

            // 4. All good – save the review as pending approval
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Review submitted successfully! It will appear on the website once approved by an employee.";
            return RedirectToAction("Details", "Books", new { id = review.BookID });
        }


        // Helper: purchase + single-review constraint
        private bool HasPurchasedAndNotReviewed(int bookID, string userID)
        {
            bool hasPurchased = _context.OrderDetails
                .Any(od => od.BookID == bookID &&
                           od.Order.CustomerID == userID &&
                           od.Order.OrderStatus == OrderStatus.Ordered);

            bool alreadyReviewed = _context.Reviews
                .Any(r => r.BookID == bookID && r.ReviewerID == userID);

            return hasPurchased && !alreadyReviewed;
        }

        // ======================
        // EMPLOYEE/ADMIN QUEUE
        // ======================

        // GET: Reviews/Pending
        // Shows all reviews where IsApproved is null (pending)
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Pending()
        {
            var pendingReviews = await _context.Reviews
                .Where(r => r.IsApproved == null)
                .Include(r => r.Book)
                .Include(r => r.Reviewer)
                .OrderBy(r => r.ReviewDate)
                .ToListAsync();

            return View(pendingReviews);
        }

        // POST: Reviews/Approve/5
        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            review.IsApproved = true;
            review.DisputeStatus = DisputeStatus.Approve;
            review.ApproverID = GetUserID();

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Review for '{review.Book?.Title}' has been approved.";
            return RedirectToAction(nameof(Pending));
        }

        // POST: Reviews/Reject/5
        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            review.IsApproved = false;
            review.DisputeStatus = DisputeStatus.Reject;
            review.ApproverID = GetUserID();

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Review for '{review.Book?.Title}' has been rejected.";
            return RedirectToAction(nameof(Pending));
        }
    }
}
