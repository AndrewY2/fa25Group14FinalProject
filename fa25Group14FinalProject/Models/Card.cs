using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;

namespace fa25Group14FinalProject.Models
{
    // Enum to enforce allowed card types as per project requirement
    public enum CardType
    {
        [Display(Name = "Visa")]
        Visa,

        [Display(Name = "American Express")]
        AmericanExpress,

        [Display(Name = "Discover")]
        Discover,

        [Display(Name = "MasterCard")]
        Mastercard
    }

    public class Card
    {
        // Primary Key
        public int CardID { get; set; }

        // Scalar Properties

        // 1. Card Number
        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Card Number is required.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Credit Card must be 16 digits.")]
        public string CardNumber { get; set; }

        // 2. Card Type
        [Required(ErrorMessage = "Card Type is required.")]
        [Display(Name = "Card Type")]
        public CardType CardType { get; set; }

        // 3. Last 4 Digits (Read-only property for display, as required at checkout)
        [NotMapped]
        public string LastFour
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CardNumber))
                {
                    return string.Empty;
                }
                return CardNumber.Substring(CardNumber.Length - 4);
            }
        }

        // Navigational Properties

        // 1. Foreign Key to Customer/ApplicationUser
        public string CustomerID { get; set; }
        public virtual AppUser? Customer { get; set; }

        // 2. One-to-Many with Order
        public List<Order> Orders { get; set; }

        public Card()
        {
            Orders = new List<Order>();
        }
    }
}