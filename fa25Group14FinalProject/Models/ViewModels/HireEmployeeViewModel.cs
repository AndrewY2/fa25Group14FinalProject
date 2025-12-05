using System.ComponentModel.DataAnnotations;

namespace fa25Group14FinalProject.ViewModels
{
    public class HireEmployeeViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Street Address (Required) 
        [Required(ErrorMessage = "Street Address is required.")]
        [Display(Name = "Street Address")]
        public String Address { get; set; }

        // City (Required) 
        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public String City { get; set; }

        // State (Required) 
        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public String State { get; set; }

        // Zip Code (Required) 
        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Make Admin?")]
        public bool IsAdmin { get; set; }
    }
}

