// In fa25Group14FinalProject.Models/IndexViewModel.cs (or similar location)
using System.Collections.Generic;

namespace fa25Group14FinalProject.Models
{
    public class AccountIndexViewModel
    {
        // Properties needed for the Account Index View
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } // The Email is often used as UserName
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // The list of cards for the credit card management section
        public ICollection<Card> Cards { get; set; }
    }
}
