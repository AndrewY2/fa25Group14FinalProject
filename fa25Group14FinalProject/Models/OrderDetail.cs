using System.ComponentModel.DataAnnotations;
using fa25Group14FinalProject.Models;

namespace fa25Group14FinalProject.Models
{
    public class OrderDetail
    {
        // Composite Key Setup (No explicit OrderDetailID needed)
        // EF Core will use the foreign keys (OrderID and ProductID) as the composite primary key by convention.
        // We can optionally add an explicit OrderDetailID if we need a simple primary key for scaffolding or other purposes.
        public int OrderDetailID { get; set; }

        // Scalar Properties

        // a. Quantity
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        public int Quantity { get; set; }

        // b. Product price (the price of the product at the time of order)
        // This is the price the customer actually paid for one unit.
        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Product Price is required.")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        // c. Extended price (quantity * product price at the time of the order)
        [Display(Name = "Extended Price")]
        [DataType(DataType.Currency)]
        public decimal ExtendedPrice { get; set; }


        // Navigational Properties (Foreign Keys for the many-to-many join)

        // Relationship 1: To Order (One-to-Many side)
        // A single order detail is only associated with one order.
        public virtual Order Order { get; set; }

        // Relationship 2: To Product (One-to-Many side)
        // A single order detail is only associated with one product.
        public virtual Product Product { get; set; }
    }
}

