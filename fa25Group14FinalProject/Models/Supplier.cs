using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using fa25Group14FinalProject.Models;

namespace fa25Group14FinalProject.Models
{
    public class Supplier
    {
        // Scalar Properties

        // a. SupplierID (Primary key)
        public int SupplierID { get; set; }

        // b. SupplierName (String) - Required
        [Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "Supplier Name is required.")]
        public string SupplierName { get; set; }

        // c. Email (String)
        [Display(Name = "Email")]
        public string Email { get; set; }

        // d. PhoneNumber (String)
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Navigational Property (for Many-to-Many with Product)

        // A supplier provides multiple products (Many side of the many-to-many)
        public List<Product> Products { get; set; }

        public Supplier()
        {
            Products = new List<Product>();
        }
    }
}