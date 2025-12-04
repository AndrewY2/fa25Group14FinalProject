using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using System.Collections.Generic;

namespace fa25Group14FinalProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        // --- DASHBOARD AND SELECTION ---

        // GET: Reports/Index (Report Selection Dashboard)
        public IActionResult Index()
        {
            // The view should contain options to select the ReportType (A-F) and input filtering criteria.
            return View();
        }

        // --- GENERATE REPORTS (MAIN LOGIC) ---

        // POST/GET: Reports/GenerateReport
        // Handles generating all required reports (A, B, C, D, E, F)
        public async Task<IActionResult> GenerateReport(string reportType, ReportSearchViewModel vm) // Assume a ReportSearchViewModel for input
        {
            IQueryable<OrderDetail> query = _context.OrderDetails
                .Include(od => od.Book)
                .Include(od => od.Order)
                    .ThenInclude(o => o.Customer)
                .AsQueryable();

            // 1. APPLY FILTERS (Simplified - you'll need to expand this based on VM)
            // Example: Date range filter, Customer filter, etc.
            // if (vm.StartDate.HasValue) { query = query.Where(od => od.Order.OrderDate >= vm.StartDate); }

            // 2. GENERATE REPORT BASED ON TYPE
            switch (reportType)
            {
                case "A": // All books sold (Per Book/OrderDetail)
                    var reportA = await query.Select(od => new
                    {
                        BookTitle = od.Book.Title,
                        Quantity = od.Quantity,
                        OrderNumber = od.OrderID, // Use OrderID as Order Number
                        CustomerName = od.Order.Customer.FirstName + " " + od.Order.Customer.LastName,
                        SellingPrice = od.Price,
                        WeightedAverageCost = od.Cost,
                        ProfitMargin = od.Price - od.Cost // Selling Price - Average Cost
                    }).ToListAsync();
                    ViewBag.RecordCount = reportA.Count;
                    return View("ReportA", reportA);

                case "B": // All Orders (Grouped by Order)
                    var reportB = await query.GroupBy(od => od.Order)
                        .Select(g => new
                        {
                            Order = g.Key,
                            Subtotal = g.Sum(od => od.Quantity * od.Price), // Total Revenue (excluding shipping)
                            TotalCost = g.Sum(od => od.Quantity * od.Cost),
                            ProfitMargin = g.Sum(od => od.Quantity * (od.Price - od.Cost)) // Profit for the entire order
                        })
                        // You will need to project this into a final list/view model for sorting/display
                        .ToListAsync();
                    ViewBag.RecordCount = reportB.Count;
                    return View("ReportB", reportB);

                case "C": // All Customers (Grouped by Customer)
                    var reportC = await query.GroupBy(od => od.Order.Customer)
                        .Select(g => new
                        {
                            Customer = g.Key,
                            TotalRevenue = g.Sum(od => od.Quantity * od.Price),
                            TotalProfit = g.Sum(od => od.Quantity * (od.Price - od.Cost))
                        })
                        // You will need to project this into a final list/view model for sorting/display
                        .ToListAsync();
                    ViewBag.RecordCount = reportC.Count;
                    return View("ReportC", reportC);

                case "D": // Totals (Total Profit, Cost, Revenue)
                    // Note: This must calculate based on the current filtered query
                    var totals = await query.GroupBy(od => 1)
                        .Select(g => new
                        {
                            TotalRevenue = g.Sum(od => od.Quantity * od.Price),
                            TotalCost = g.Sum(od => od.Quantity * od.Cost),
                            TotalProfit = g.Sum(od => od.Quantity * (od.Price - od.Cost))
                        })
                        .FirstOrDefaultAsync();

                    return View("ReportD", totals);

                case "E": // Current Inventory
                    var reportE = await _context.Books
                        .Select(b => new
                        {
                            Title = b.Title,
                            InventoryQuantity = b.InventoryQuantity,
                            AverageCost = b.Cost // This is the Weighted Average Cost
                        })
                        .ToListAsync();

                    ViewBag.TotalInventoryValue = reportE.Sum(r => r.InventoryQuantity * r.AverageCost);
                    ViewBag.RecordCount = reportE.Count;
                    return View("ReportE", reportE);

                case "F": // Approved/Rejected Reviews (by Employee)
                    var reportF = await _context.Reviews
                        .Include(r => r.Approver) // Include the employee who approved/rejected
                        .Where(r => r.ApproverID != null) // Only count reviews that have been processed
                        .GroupBy(r => r.Approver)
                        .Select(g => new
                        {
                            EmployeeName = g.Key.FirstName + " " + g.Key.LastName,
                            ApprovedCount = g.Count(r => r.IsApproved == true),
                            RejectedCount = g.Count(r => r.IsApproved == false)
                        })
                        // Note: You must allow sorting by EmpID (AppUser.Id), Approved/Rejected count
                        .ToListAsync();
                    ViewBag.RecordCount = reportF.Count;
                    return View("ReportF", reportF);

                default:
                    return View("Error", new string[] { "Invalid report type selected." });
            }
        }
    }
}