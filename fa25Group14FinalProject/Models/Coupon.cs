using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fa25Group14FinalProject.Models
{
    // Enum to enforce the only two coupon types allowed by the project requirements
    public enum CouponType
    {
        [Display(Name = "X% Off Total Order")]
        PercentOff = 0,

        [Display(Name = "Free Shipping")]
        FreeShipping = 1
    }

    public class Coupon
    {
        // Primary Key
        public int CouponID { get; set; }

        // 1. Coupon Code (1–20-char combo, must be unique)
        [Display(Name = "Coupon Code")]
        [Required(ErrorMessage = "Coupon Code is required.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Code must be 1 to 20 characters.")]
        public string CouponCode { get; set; }

        // 2. Coupon Type (Enum)
        [Display(Name = "Coupon Type")]
        [Required(ErrorMessage = "Coupon Type is required.")]
        public CouponType CouponType { get; set; }

        // 3. Discount Percent (Used for PercentOff type only)
        // Stored as a value between 0 and 100
        [Display(Name = "Discount Percentage")]
        [Range(0.01, 100, ErrorMessage = "Discount must be between 0.01 and 100.")]
        public decimal? DiscountPercent { get; set; }

        // 4. Free Threshold (Used for FreeShipping type only)
        // Orders must be above this subtotal to qualify; 0 = all orders.
        [Display(Name = "Free Shipping Threshold ($)")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "Threshold cannot be negative.")]
        public decimal? FreeThreshold { get; set; }

        // 5. Status (For Admins to enable or disable the promotion)
        [Display(Name = "Is Active?")]
        public bool Status { get; set; }

        // Navigational Properties – which orders used this coupon
        public List<Order> Orders { get; set; }

        public Coupon()
        {
            Orders = new List<Order>();
        }
    }
}
