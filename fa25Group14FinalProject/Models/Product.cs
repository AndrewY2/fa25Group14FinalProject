using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace fa25Group14FinalProject.Models
{
    public enum ProductType
    {
        [Display(Name = "New Hardback")]
        NewHardback = 0,

        [Display(Name = "New Paperback")]
        NewPaperback = 1,

        [Display(Name = "Used Hardback")]
        UsedHardback = 2,

        [Display(Name = "Used Paperback")]
        UsedPaperback = 3,

        Other
    }
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)] // Use C for Currency formatting
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product type is required.")]
        [Display(Name = "Product Type")]
        public ProductType ProductType { get; set; }

        // Navigational Property (for Many-to-Many with Supplier)
        public List<Supplier> Suppliers { get; set; }

        // Navigational Property (for Many-to-Many with Order via OrderDetail)
        public List<OrderDetail> OrderDetails { get; set; }

        // Constructor to initialize lists to prevent NullReferenceExceptions
        public Product()
        {
            Suppliers = new List<Supplier>();
            OrderDetails = new List<OrderDetail>();
        }
    }
}