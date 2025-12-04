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
    // Restricts access to only users in the Admin role (Required)
    [Authorize(Roles = "Admin")]
    public class PromotionsController : Controller
    {
        private readonly AppDbContext _context;

        public PromotionsController(AppDbContext context)
        {
            _context = context;
        }

        // --- VIEW AND STATUS MANAGEMENT ---

        // GET: Promotions/Index
        // Admins should be able to see a list of all coupon codes.
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupons
                                      .OrderByDescending(c => c.Status)
                                      .ThenBy(c => c.CouponCode)
                                      .ToListAsync());
        }

        // GET: Promotions/Details/5 (View details of a specific promotion)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                                       .FirstOrDefaultAsync(m => m.CouponID == id);

            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: Promotions/ToggleStatus/5
        // Promotions cannot be modified after they are created, but they can be enabled or disabled.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            Coupon couponToUpdate = await _context.Coupons.FindAsync(id);

            if (couponToUpdate == null)
            {
                return NotFound();
            }

            // Toggle the Status field (enable/disable)
            couponToUpdate.Status = !couponToUpdate.Status;

            try
            {
                _context.Update(couponToUpdate);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Coupon code '{couponToUpdate.CouponCode}' successfully {(couponToUpdate.Status ? "enabled" : "disabled")}.";
            }
            catch (DbUpdateConcurrencyException)
            {
                // Log error
                TempData["ErrorMessage"] = "Concurrency error while updating coupon status.";
            }

            return RedirectToAction(nameof(Index));
        }

        // --- CREATION ---

        // GET: Promotions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // NOTE: Status removed from the Bind list – we set it manually below
        public async Task<IActionResult> Create([Bind("CouponCode,CouponType,DiscountPercent,FreeThreshold")] Coupon coupon)
        {
            // Set default status to active
            coupon.Status = true;

            // Manual validation for uniqueness of CouponCode (Required)
            if (_context.Coupons.Any(c => c.CouponCode == coupon.CouponCode))
            {
                ModelState.AddModelError("CouponCode", "This coupon code must be unique.");
            }

            // Manual validation based on Coupon Type
            if (coupon.CouponType == CouponType.PercentOff)
            {
                if (coupon.DiscountPercent == null || coupon.DiscountPercent <= 0)
                {
                    ModelState.AddModelError("DiscountPercent", "Percentage discount must be set for this coupon type.");
                }
                coupon.FreeThreshold = null; // Clear unused property
            }
            else if (coupon.CouponType == CouponType.FreeShipping)
            {
                if (coupon.FreeThreshold == null || coupon.FreeThreshold < 0)
                {
                    ModelState.AddModelError("FreeThreshold", "Free shipping threshold must be set (use 0 for all orders).");
                }
                coupon.DiscountPercent = null; // Clear unused property
            }

            if (ModelState.IsValid)
            {
                _context.Add(coupon);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"New coupon '{coupon.CouponCode}' successfully created.";
                return RedirectToAction(nameof(Details), new { id = coupon.CouponID });
            }

            return View(coupon);
        }
    }
}
