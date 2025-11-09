using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // Added for the navigational property to Order

namespace fa25Group14FinalProject.Models
{
    public class AppUser : IdentityUser
    {
        // Custom Scalar Properties (Required by Step 6)

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } // Corrected String to string

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")] // <-- **CORRECTED THIS DISPLAY NAME**
        public string LastName { get; set; } // Corrected String to string


        // Navigational Property (Required by Step 13d for 1:Many relationship)

        // A customer will have many orders.
        public List<Order> Orders { get; set; }

        public AppUser()
        {
            Orders = new List<Order>();
        }
    }
}