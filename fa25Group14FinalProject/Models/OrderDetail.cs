using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Required for [NotMapped]
using fa25Group14FinalProject.Models;

namespace fa25Group14FinalProject.Models
{
    public class OrderDetail
    {
        // Primary Key (Explicit ID is good practice)
        public int OrderDetailID { get; set; }

        // Scalar Properties

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }
        // 1. Quantity
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be 1 or greater.")] // Adjusted max range to int.MaxValue
        public int Quantity { get; set; }

        // 2. Price (The selling price of the book unit at the time of order) - Renamed from ProductPrice
        [Display(Name = "Price Paid")]
        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // 3. Cost (The weighted average cost of the book unit at the time of order) - NEW FIELD for reporting
        [Display(Name = "Average Cost")]
        [Required(ErrorMessage = "Cost is required.")]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        // Extended price (quantity * selling price) - Read-Only Property
        [Display(Name = "Extended Price")]
        [DataType(DataType.Currency)]
        [NotMapped] // Tell EF not to map this to a database column (it's calculated)
        public decimal ExtendedPrice
        {
            get { return Quantity * Price; }
        }

        // Inside OrderDetail model:
        // ... (After ExtendedPrice) ...

        // Helper Method for Coupon Preview (NotMapped)
        public decimal GetUnitPriceAfterCoupon(decimal discountPercent)
        {
            if (discountPercent <= 0 || discountPercent > 100) return Price;

            decimal discountFactor = 1.0m - (discountPercent / 100.0m);
            return Price * discountFactor;
        }

        // Profit Margin for this item (ExtendedPrice - (Quantity * Cost)) - Read-Only Property
        [Display(Name = "Profit Margin")]
        [DataType(DataType.Currency)]
        [NotMapped]
        public decimal ProfitMargin
        {
            get { return ExtendedPrice - (Quantity * Cost); }
        }


        // Navigational Properties (Foreign Keys)

        // 1. Relationship to Order
        public int OrderID { get; set; } // Explicit Foreign Key
        public virtual Order? Order { get; set; }

        // 2. Relationship to Book - Renamed from 'Product'
        public int BookID { get; set; } // Explicit Foreign Key (replaces old ProductID)
        public virtual Book? Book { get; set; } // Navigational property (renamed from Product)
    }
}