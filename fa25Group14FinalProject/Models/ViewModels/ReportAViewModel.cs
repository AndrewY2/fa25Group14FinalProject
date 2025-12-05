using System;

namespace fa25Group14FinalProject.ViewModels
{
    public class ReportAViewModel
    {
        public String BookTitle { get; set; }
        public Int32 Quantity { get; set; }

        public Int32 OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public String CustomerName { get; set; }
        public String CustomerEmail { get; set; }

        // Selling price specific to the order (per book)
        public Decimal SellingPrice { get; set; }

        // Weighted average cost per book
        public Decimal WeightedAverageCost { get; set; }

        // Profit margin per book (selling price - average cost)
        public Decimal PerUnitMargin => SellingPrice - WeightedAverageCost;

        // Totals for this row (ignore shipping)
        public Decimal Revenue => Quantity * SellingPrice;
        public Decimal Cost => Quantity * WeightedAverageCost;
        public Decimal Profit => Revenue - Cost;
    }
}
