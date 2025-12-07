using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            // The old logic of checking for the role object is generally unnecessary
            // if you rely on the string role name, and the role should always exist.
            // But we will keep it simple and directly use UserManager.

            // FIX: Use the UserManager to fetch only users in the "Customer" role.
            var customerUsers = await _userManager.GetUsersInRoleAsync("Customer");

            // Sort the retrieved list of customers
            var sortedCustomers = customerUsers
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ToList();

            // Return the filtered and sorted list of *customers* to the view
            return View(sortedCustomers);
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
       /* ---- MANAGE EMPLOYEES ----*/
[Authorize(Roles = "Admin")]
    public async Task<IActionResult> ManageEmployees()
    {
        // Get all users in Employee or Admin roles
        var employees = await _userManager.GetUsersInRoleAsync("Employee");
        var admins = await _userManager.GetUsersInRoleAsync("Admin");

        // Union employees + admins, remove duplicates, sort
        var all = employees
            .Concat(admins)
            .GroupBy(u => u.Id)
            .Select(g => g.First())
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ToList();

        var model = new List<EmployeeListViewModel>();

        foreach (var u in all)
        {
            var roles = await _userManager.GetRolesAsync(u);

            model.Add(new EmployeeListViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                IsActive = u.IsActive,
                IsAdmin = roles.Contains("Admin")
            });
        }

        return View(model);
    }
        [Authorize(Roles = "Admin")]
        public IActionResult HireEmployee()
        {
            return View(new HireEmployeeViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HireEmployee(HireEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Create new AppUser for the employee
            AppUser newEmployee = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                IsActive = true // hired employees are active by default
            };

            IdentityResult result = await _userManager.CreateAsync(newEmployee, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            // Put them in Employee role
            await _userManager.AddToRoleAsync(newEmployee, "Employee");

            // Optionally make them Admin too
            if (model.IsAdmin)
            {
                await _userManager.AddToRoleAsync(newEmployee, "Admin");
            }

            TempData["SuccessMessage"] = "Employee hired successfully.";
            return RedirectToAction(nameof(ManageEmployees));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleEmployeeActive(string id)
        {
            if (String.IsNullOrEmpty(id)) return NotFound();

            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            // Flip IsActive
            user.IsActive = !user.IsActive;

            await _userManager.UpdateAsync(user);

            TempData["SuccessMessage"] = user.IsActive
                ? $"Employee {user.Email} rehired (account enabled)."
                : $"Employee {user.Email} fired (account disabled).";

            return RedirectToAction(nameof(ManageEmployees));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PromoteToAdmin(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            await _userManager.AddToRoleAsync(user, "Admin");

            TempData["SuccessMessage"] = $"{user.Email} promoted to Admin.";
            return RedirectToAction(nameof(ManageEmployees));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DemoteFromAdmin(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            // Optional: prevent demoting yourself so you don't lock out all admins
            if (user.Email == User.Identity.Name)
            {
                TempData["ErrorMessage"] = "You cannot remove your own Admin role.";
                return RedirectToAction(nameof(ManageEmployees));
            }

            await _userManager.RemoveFromRoleAsync(user, "Admin");

            TempData["SuccessMessage"] = $"{user.Email} is no longer an Admin.";
            return RedirectToAction(nameof(ManageEmployees));
        }

    }
}