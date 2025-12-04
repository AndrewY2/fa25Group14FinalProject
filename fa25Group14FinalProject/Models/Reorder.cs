using System;
using System.ComponentModel.DataAnnotations;

namespace fa25Group14FinalProject.Models
{
    // Enum to represent the status of the supplier order
    public enum ReorderStatus
    {
        [Display(Name = "Ordered")]
        Ordered = 0,

        [Display(Name = "Partially Received")]
        PartiallyReceived = 1,

        [Display(Name = "Fully Received")]
        FullyReceived = 2
    }

    public class Reorder
    {
        // Primary Key
        public int ReorderID { get; set; }

        // Scalar Properties

        // 1. Cost (The price paid to the supplier for this specific reorder)
        // This defaults to the last paid cost but can be manually changed by the Admin.
        [Display(Name = "Cost to Supplier")]
        [Required(ErrorMessage = "Cost is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost must be greater than zero.")]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        // 2. Quantity (The number of copies ordered)
        [Display(Name = "Quantity Ordered")]
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity { get; set; }

        // 3. Quantity Received (The number of copies checked in so far)
        [Display(Name = "Quantity Received")]
        public int QuantityReceived { get; set; }

        // 4. Date the order was placed
        [Display(Name = "Order Date")]
        public DateTime Date { get; set; }

        // 5. Status of the order
        [Display(Name = "Status")]
        public ReorderStatus ReorderStatus { get; set; }


        // Navigational Properties (Foreign Key)

        // Foreign Key to the Book being ordered
        public int BookID { get; set; }
        public virtual Book? Book { get; set; }

        public Reorder()
        {
            // Set initial values
            Date = DateTime.Now;
            QuantityReceived = 0;
            ReorderStatus = ReorderStatus.Ordered;
        }
    }
}