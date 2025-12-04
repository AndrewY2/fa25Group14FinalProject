using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace fa25Group14FinalProject.Models
{
    public enum OrderStatus
    {
        InCart,
        Ordered
    }

    public class Order
    {
        // ---------- Scalar Properties ----------

        public int OrderID { get; set; }

        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [Required]
        [Display(Name = "Shipping Fee")]
        [DataType(DataType.Currency)]
        public decimal ShippingFee { get; set; }

        // ✅ MUST be settable so the controller can assign to it
        [Display(Name = "Discount Amount")]
        [DataType(DataType.Currency)]
        public decimal? DiscountAmount { get; set; }

        [Display(Name = "Status")]
        public OrderStatus OrderStatus { get; set; }

        // ---------- Navigation / FK Properties ----------

        public string CustomerID { get; set; }
        public virtual AppUser? Customer { get; set; }

        public int? CardID { get; set; }
        public virtual Card? Card { get; set; }

        public int? CouponID { get; set; }
        public virtual Coupon? Coupon { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        // ---------- Calculated (not mapped) ----------

        [Display(Name = "Subtotal")]
        [DataType(DataType.Currency)]
        [NotMapped]
        public decimal Subtotal
        {
            get { return OrderDetails.Sum(od => od.Price * od.Quantity); }
        }

        [Display(Name = "Order Total")]
        [DataType(DataType.Currency)]
        [NotMapped]
        public decimal OrderTotal
        {
            get
            {
                decimal discount = DiscountAmount ?? 0m;
                return Subtotal - discount + ShippingFee;
            }
        }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
