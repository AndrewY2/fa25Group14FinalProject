using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fa25Group14FinalProject.Models
{
    public class AppUser : IdentityUser
    {
        // --- Custom Scalar Properties (Based on Customer Requirements) ---

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /*[Required(ErrorMessage = "Phone Number is required.")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }*/


        [Required(ErrorMessage = "Street Address is required.")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        // Status field to track if the account is active/disabled (as required for employee management)
        [Display(Name = "Account Is Active")]
        public bool IsActive { get; set; } = true; // Default to active


        // --- Navigational Properties (Based on ERD Relationships) ---

        // 1. One-to-Many with Order (A customer will have many orders.)
        public List<Order> Orders { get; set; }

        // 2. One-to-Many with Card (A customer can have up to 3 credit cards.)
        public List<Card> Cards { get; set; }

        // 3. One-to-Many with Review (A user writes many reviews.)
        [InverseProperty("Reviewer")]
        public List<Review> ReviewsWritten { get; set; }

        // 4. One-to-Many with Review (A user (Employee/Admin) approves many reviews.)
        // This is a separate relationship from ReviewsWritten
        [InverseProperty("Approver")]
        public List<Review> ReviewsApproved { get; set; }

        public AppUser()
        {
            Orders = new List<Order>();
            Cards = new List<Card>();
            ReviewsWritten = new List<Review>();
            ReviewsApproved = new List<Review>();
        }
    }
}