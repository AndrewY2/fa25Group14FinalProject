using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace fa25Group14FinalProject.Models
{
    public class Book
    {
        // --- Scalar Properties ---

        public int BookID { get; set; }

        [Required(ErrorMessage = "Book Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Authors { get; set; }

        // Unique Book Number must be positive
        [Required(ErrorMessage = "Unique Book Number is required.")]
        [Display(Name = "Book Number")]
        public Int32 BookNumber { get; set; }

        public string? Description { get; set; }

        // Price must be positive
        [Required(ErrorMessage = "Price is required.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        // Cost must be positive
        [Required(ErrorMessage = "Cost is required.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost must be greater than 0.")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Publication Date is required.")]
        [Display(Name = "Publication Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        // Inventory must be 0 or greater
        [Required(ErrorMessage = "Inventory Quantity is required.")]
        [Display(Name = "Qty in Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Inventory Quantity cannot be negative.")]
        public int InventoryQuantity { get; set; }

        // Reorder Point must be positive
        [Required(ErrorMessage = "Reorder Point is required.")]
        [Display(Name = "Reorder Point")]
        [Range(0, int.MaxValue, ErrorMessage = "Reorder Point must be 0 or greater.")]
        public int ReorderPoint { get; set; }

        [Display(Name = "Discontinued?")]
        public bool BookStatus { get; set; }


        // Navigational Properties

        [Required(ErrorMessage = "Book Genre is required.")]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }
        public virtual Genre? Genre { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Reorder> Reorders { get; set; }

        public double? Rating
        {
            get
            {
                var approved = Reviews?
                    .Where(r => r.IsApproved == true)
                    .ToList();

                if (approved == null || approved.Count == 0) return null;

                return approved.Average(r => r.Rating);
            }
        }

        public int TimesPurchased { get; set; } = 0;

        // Constructor
        public Book()
        {
            OrderDetails = new List<OrderDetail>();
            Reviews = new List<Review>();
            Reorders = new List<Reorder>();
        }
    }
}
