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
            // You'll need to populate SortField and SortDirection options in the ViewModel for the view
            return View();
        }

        // --- GENERATE REPORTS (MAIN LOGIC) ---

        // POST/GET: Reports/GenerateReport
        public async Task<IActionResult> GenerateReport(string reportType, ReportSearchViewModel vm)
        {
            // Initial query starts with OrderDetails, including all necessary related entities.
            // Note: Added ThenInclude(b => b.Genre) for filtering on genre name.
            IQueryable<OrderDetail> query = _context.OrderDetails
                .Include(od => od.Book).ThenInclude(b => b.Genre)
                .Include(od => od.Order)
                    .ThenInclude(o => o.Customer)
                .AsQueryable();

            // 1. APPLY FILTERS (Reports A, B, C, D)
            // Filters only apply to sales reports (A, B, C, D) which use the OrderDetail query.

            // Filter by Date Range
            if (vm.StartDate.HasValue)
            {
                query = query.Where(od => od.Order.OrderDate >= vm.StartDate);
            }
            if (vm.EndDate.HasValue)
            {
                // To include the end date, filter up to the end of the day (23:59:59)
                DateTime endOfDay = vm.EndDate.Value.AddDays(1).AddSeconds(-1);
                query = query.Where(od => od.Order.OrderDate <= endOfDay);
            }

            // Filter by Customer (Email or Name)
            if (!string.IsNullOrEmpty(vm.CustomerFilter))
            {
                // Filter by customer email OR full name (case-insensitive contains)
                query = query.Where(od => od.Order.Customer.Email.Contains(vm.CustomerFilter) ||
                                          (od.Order.Customer.FirstName + " " + od.Order.Customer.LastName).Contains(vm.CustomerFilter));
            }

            // Filter by Book (Title or Genre Name)
            if (!string.IsNullOrEmpty(vm.BookFilter))
            {
                // Filter by book title OR genre name (case-insensitive contains)
                // Assuming Genre model has a property named 'Name' for the genre name.
                query = query.Where(od => od.Book.Title.Contains(vm.BookFilter) ||
                                          od.Book.Genre.GenreName.Contains(vm.BookFilter));
            }

            // 2. GENERATE REPORT BASED ON TYPE
            switch (reportType)
            {
                case "A": // All books sold (Per Book/OrderDetail)
                    var reportAQuery = query.Select(od => new
                    {
                        BookTitle = od.Book.Title,
                        Quantity = od.Quantity,
                        OrderNumber = od.OrderID,
                        OrderDate = od.Order.OrderDate,
                        CustomerName = od.Order.Customer.FirstName + " " + od.Order.Customer.LastName,
                        SellingPrice = od.Price,
                        WeightedAverageCost = od.Cost,
                        ProfitMargin = od.Price - od.Cost,
                        // For 'Most Popular' sorting on total quantity, we'll need to sort after aggregating if not filtering
                        // For single OrderDetail row sorting, use od.Quantity
                    });

                    // Apply Sorting for Report A
                    switch (vm.SortField)
                    {
                        case "ProfitMargin":
                            reportAQuery = (vm.SortDirection == "Ascending") ? reportAQuery.OrderBy(r => r.ProfitMargin) : reportAQuery.OrderByDescending(r => r.ProfitMargin);
                            break;
                        case "Price":
                            reportAQuery = (vm.SortDirection == "Ascending") ? reportAQuery.OrderBy(r => r.SellingPrice) : reportAQuery.OrderByDescending(r => r.SellingPrice);
                            break;
                        case "MostPopular":
                            reportAQuery = (vm.SortDirection == "Ascending") ? reportAQuery.OrderBy(r => r.Quantity) : reportAQuery.OrderByDescending(r => r.Quantity);
                            break;
                        default: // Defaults to "Most Recent First" (OrderDate Descending)
                            reportAQuery = reportAQuery.OrderByDescending(r => r.OrderDate);
                            break;
                    }

                    var reportA = await reportAQuery.ToListAsync();
                    ViewBag.RecordCount = reportA.Count;
                    return View("ReportA", reportA);

                case "B": // All Orders - grouped by order
                    {
                        var reportBQuery = query
                            .GroupBy(od => new
                            {
                                od.Order.OrderID,
                                od.Order.OrderDate,
                                CustomerFirst = od.Order.Customer.FirstName,
                                CustomerLast = od.Order.Customer.LastName
                            })
                            .Select(g => new
                            {
                                OrderID = g.Key.OrderID,
                                OrderDate = g.Key.OrderDate,
                                CustomerName = g.Key.CustomerFirst + " " + g.Key.CustomerLast,
                                OrderPrice = g.Sum(od => od.Quantity * od.Price), // total revenue (no shipping)
                                TotalCost = g.Sum(od => od.Quantity * od.Cost),
                                ProfitMargin = g.Sum(od => od.Quantity * (od.Price - od.Cost))
                            });

                        // Apply Sorting for Report B
                        switch (vm.SortField)
                        {
                            case "ProfitMargin":
                                reportBQuery = (vm.SortDirection == "Ascending") ? reportBQuery.OrderBy(r => r.ProfitMargin) : reportBQuery.OrderByDescending(r => r.ProfitMargin);
                                break;
                            case "Price":
                                reportBQuery = (vm.SortDirection == "Ascending") ? reportBQuery.OrderBy(r => r.OrderPrice) : reportBQuery.OrderByDescending(r => r.OrderPrice);
                                break;
                            default: // Defaults to "Most Recent First" (OrderDate Descending)
                                reportBQuery = reportBQuery.OrderByDescending(r => r.OrderDate);
                                break;
                        }

                        var reportB = await reportBQuery.ToListAsync();
                        ViewBag.RecordCount = reportB.Count;
                        return View("ReportB", reportB);
                    }


                case "C": // All Customers (Grouped by Customer)
                    var reportCQuery = query.GroupBy(od => new { od.Order.Customer.Id, od.Order.Customer.FirstName, od.Order.Customer.LastName })
                        .Select(g => new
                        {
                            CustomerName = g.Key.FirstName + " " + g.Key.LastName,
                            TotalRevenue = g.Sum(od => od.Quantity * od.Price),
                            TotalProfit = g.Sum(od => od.Quantity * (od.Price - od.Cost))
                        });

                    // Apply Sorting for Report C
                    switch (vm.SortField)
                    {
                        case "TotalRevenue":
                            reportCQuery = (vm.SortDirection == "Ascending") ? reportCQuery.OrderBy(r => r.TotalRevenue) : reportCQuery.OrderByDescending(r => r.TotalRevenue);
                            break;
                        case "ProfitMargin": // Use "ProfitMargin" to match the report name, but sort on TotalProfit
                            reportCQuery = (vm.SortDirection == "Ascending") ? reportCQuery.OrderBy(r => r.TotalProfit) : reportCQuery.OrderByDescending(r => r.TotalProfit);
                            break;
                        default: // Default to Profit Margin Descending if no sort is specified.
                            reportCQuery = reportCQuery.OrderByDescending(r => r.TotalProfit);
                            break;
                    }

                    var reportC = await reportCQuery.ToListAsync();
                    ViewBag.RecordCount = reportC.Count;
                    return View("ReportC", reportC);

                case "D": // Totals (Total Profit, Cost, Revenue)
                    // Note: Calculations are based on the currently filtered 'query'
                    var totals = await query.GroupBy(od => 1) // Group everything into one record
                        .Select(g => new
                        {
                            TotalRevenue = g.Sum(od => od.Quantity * od.Price),
                            TotalCost = g.Sum(od => od.Quantity * od.Cost),
                            TotalProfit = g.Sum(od => od.Quantity * (od.Price - od.Cost))
                        })
                        .FirstOrDefaultAsync();

                    ViewBag.RecordCount = (totals != null) ? 1 : 0;
                    return View("ReportD", totals);

                case "E": // Current Inventory
                          // 1. Start with the full Book query, including Genre for filtering
                    IQueryable<Book> bookQuery = _context.Books
                        .Include(b => b.Genre)
                        .AsQueryable();

                    // 2. Apply Book filtering (Filter on the IQueryable<Book> before projection)
                    if (!string.IsNullOrEmpty(vm.BookFilter))
                    {
                        // This 'b' still refers to the full Book entity, so b.Genre.Name is accessible
                        // (Assuming your Genre model has a 'Name' property for the genre name)
                        bookQuery = bookQuery.Where(b => b.Title.Contains(vm.BookFilter) ||
                                                         b.Genre.GenreName.Contains(vm.BookFilter));
                    }

                    // 3. Project the filtered results into the anonymous type for the report
                    var reportE = await bookQuery.Select(b => new
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
                    // Filtering on sales data (OrderDetails) does not apply here.
                    var reportFQuery = _context.Reviews
                        .Include(r => r.Approver) // Include the employee who approved/rejected
                        .Where(r => r.ApproverID != null) // Only count reviews that have been processed
                        .GroupBy(r => r.Approver)
                        .Select(g => new
                        {
                            EmployeeID = g.Key.Id, // Used for sorting by EmpID
                            EmployeeName = g.Key.FirstName + " " + g.Key.LastName,
                            ApprovedCount = g.Count(r => r.IsApproved == true),
                            RejectedCount = g.Count(r => r.IsApproved == false)
                        });

                    // Apply Sorting for Report F
                    if (vm.SortField == "ApprovedCount")
                    {
                        reportFQuery = (vm.SortDirection == "Ascending") ? reportFQuery.OrderBy(r => r.ApprovedCount) : reportFQuery.OrderByDescending(r => r.ApprovedCount);
                    }
                    else if (vm.SortField == "RejectedCount")
                    {
                        reportFQuery = (vm.SortDirection == "Ascending") ? reportFQuery.OrderBy(r => r.RejectedCount) : reportFQuery.OrderByDescending(r => r.RejectedCount);
                    }
                    else // Default to EmpID ascending
                    {
                        reportFQuery = reportFQuery.OrderBy(r => r.EmployeeID);
                    }

                    var reportF = await reportFQuery.ToListAsync();
                    ViewBag.RecordCount = reportF.Count;
                    return View("ReportF", reportF);

                default:
                    return View("Error", new string[] { "Invalid report type selected." });
            }
        }
    }
}