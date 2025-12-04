using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using System.Collections.Generic;
using System;

namespace fa25Group14FinalProject.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EmployeesController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Helper to get the logged-in user object
        private async Task<AppUser> GetLoggedInUser()
        {
            return await _userManager.FindByNameAsync(User.Identity.Name);
        }

        // --- MANAGE REVIEWS ---
        // Employees see a list of all reviews pending approval[cite: 313].

        // GET: Employees/Index (Review Management Dashboard)
        public async Task<IActionResult> Index()
        {
            // Fetch reviews where IsApproved is null (pending)
            var pendingReviews = await _context.Reviews
                .Include(r => r.Reviewer) // Include the customer who wrote it
                .Include(r => r.Book)      // Include the book title
                .Where(r => r.IsApproved == null)
                .OrderBy(r => r.ReviewDate)
                .ToListAsync();

            return View(pendingReviews);
        }

        // GET: Employees/ApproveReview/5
        public async Task<IActionResult> ApproveReview(int? id)
        {
            if (id == null) return NotFound();

            var review = await _context.Reviews
                .Include(r => r.Reviewer)
                .Include(r => r.Book)
                .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (review == null || review.IsApproved != null)
            {
                // Review is already approved/rejected or not found
                return NotFound();
            }

            return View(review);
        }

        // POST: Employees/ApproveReview/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Employee may edit the text, but not the rating[cite: 315].
        public async Task<IActionResult> ApproveReview(int id, string ReviewText, bool IsApproved)
        {
            Review reviewToUpdate = await _context.Reviews.FindAsync(id);

            if (reviewToUpdate == null || reviewToUpdate.IsApproved != null) return NotFound();

            // Update the review text and set the status
            reviewToUpdate.ReviewText = ReviewText; // Employees can edit text
            reviewToUpdate.IsApproved = IsApproved;
            reviewToUpdate.ApproverID = _userManager.GetUserId(User); // Log the employee who approved/rejected it

            try
            {
                _context.Update(reviewToUpdate);
                await _context.SaveChangesAsync();

                // Book rating is updated automatically upon save if logic is in the Book model's getter/setter
                // or a recalculation service is called.

                TempData["SuccessMessage"] = $"Review for {reviewToUpdate.Book.Title} was successfully {(IsApproved ? "approved" : "rejected")}.";
            }
            catch (DbUpdateConcurrencyException)
            {
                return View("Error", new string[] { "Concurrency error while updating review." });
            }

            return RedirectToAction(nameof(Index));
        }

        // --- MANAGE CUSTOMERS ---
        // Employees can create and modify customers[cite: 306].

        // GET: Employees/ManageCustomers
        public async Task<IActionResult> ManageCustomers()
        {
            // Only fetch users who are customers
            var customerRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Customer");
            if (customerRole == null)
            {
                TempData["ErrorMessage"] = "The 'Customer' role does not exist.";
                return RedirectToAction(nameof(Index));
            }

            // You would typically use UserManager.GetUsersInRoleAsync("Customer") here
            // For simple demonstration: fetch all users and let the view filter/link to roles.
            var allUsers = await _context.Users
                .OrderBy(u => u.LastName)
                .ToListAsync();

            // Note: You need links here to AccountController actions (e.g., Register for 'Create')
            // and an action below for Disable/Enable.

            return View(allUsers);
        }

        // POST: Employees/ToggleAccountStatus/5
        // Disables/enables customer account[cite: 307].
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleAccountStatus(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Check if the target user is an Admin (Admins cannot disable other Admins via Employee control)
            if (await _userManager.IsInRoleAsync(user, "Admin") && !User.IsInRole("Admin"))
            {
                TempData["ErrorMessage"] = "Only Admins can manage other Admin accounts.";
                return RedirectToAction(nameof(ManageCustomers));
            }

            user.IsActive = !user.IsActive; // Toggle the status

            await _userManager.UpdateAsync(user);

            TempData["SuccessMessage"] = $"{user.Email}'s account was successfully {(user.IsActive ? "enabled" : "disabled")}.";
            return RedirectToAction(nameof(ManageCustomers));
        }
    }
}