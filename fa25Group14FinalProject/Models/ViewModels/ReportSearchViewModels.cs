using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace fa25Group14FinalProject.Models
{
    public class ReportSearchViewModel
    {
        // General Report Selection
        [Display(Name = "Report Type")]
        public string ReportType { get; set; }

        // Date Range Filtering (Required for sales/order reports A, B, C, D)
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        // Specific Filtering (Example)
        [Display(Name = "Filter by Customer")]
        public string? CustomerFilter { get; set; } // E.g., Customer Email or Name

        [Display(Name = "Filter by Book/Genre")]
        public string? BookFilter { get; set; } // E.g., Book Title or Genre Name

        // Sorting (Required for all reports)
        [Display(Name = "Sort By")]
        public string SortField { get; set; } // E.g., "ProfitMargin", "Title", "Quantity"

        [Display(Name = "Direction")]
        public string SortDirection { get; set; } // E.g., "Ascending" or "Descending"

        // Helper property for the sorting options dropdown list (You would populate this in the Controller)
        public SelectList AvailableSorts { get; set; }
    }
}