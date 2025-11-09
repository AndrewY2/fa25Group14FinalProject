using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using fa25Group14FinalProject.Models;

namespace fa25Group14FinalProject.Models
{
    public class Order
    {
        // e. Named Constant for TAX_RATE
        public const decimal TAX_RATE = 0.0825m;

        // Scalar Properties

        // a. OrderID (Primary key)
        public int OrderID { get; set; }

        // b. OrderNumber (Starts at 70001) - Use Display for formatting
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }

        // c. OrderDate
        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        // d. OrderNotes
        [Display(Name = "Order Notes")]
        public string OrderNotes { get; set; }

        // Navigational Properties

        // Relationship 1: One-to-Many with AppUser (Customer)
        // Each order belongs to a single customer (AppUser)
        public AppUser User { get; set; }

        // Relationship 2: One-to-Many with OrderDetail
        // An order consists of many order details (the many-to-many join)
        public List<OrderDetail> OrderDetails { get; set; }


        // Read-Only Properties for Summary Calculations (as suggested in step 5e of Part Five)

        // The sum of the extended prices of the order details
        [Display(Name = "Subtotal")]
        [DataType(DataType.Currency)]
        [NotMapped] // Tell EF not to map this to a database column
        public decimal Subtotal
        {
            get { return OrderDetails.Sum(od => od.ExtendedPrice); }
        }

        // Sales tax (subtotal * TAX_RATE)
        [Display(Name = "Sales Tax")]
        [DataType(DataType.Currency)]
        [NotMapped] // Tell EF not to map this to a database column
        public decimal Tax
        {
            get { return Subtotal * TAX_RATE; }
        }

        // Order total (subtotal + sales tax)
        [Display(Name = "Order Total")]
        [DataType(DataType.Currency)]
        [NotMapped] // Tell EF not to map this to a database column
        public decimal OrderTotal
        {
            get { return Subtotal + Tax; }
        }


        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
