using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace fa25Group14FinalProject.Models
{
    public class Book
    {
        // --- Scalar Properties ---

        // 1. BookID (Primary Key)
        public int BookID { get; set; }

        // 2. Title
        [Required(ErrorMessage = "Book Title is required.")]
        public string Title { get; set; }

        // 3. Authors
        [Required(ErrorMessage = "Author is required.")]
        public string Authors { get; set; }

        // 4. Unique Book Number (Used instead of ISBN)
        [Required(ErrorMessage = "Unique Book Number is required.")]
        [Display(Name = "Book Number")]
        public Int32 BookNumber { get; set; }

        // 5. Description
        public string? Description { get; set; }

        // 6. Price (Selling Price)
        [Required(ErrorMessage = "Price is required.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // 7. Cost (Weighted Average Cost - crucial for reports)
        [Required(ErrorMessage = "Cost is required.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        // 8. Publication Date
        [Required(ErrorMessage = "Publication Date is required.")]
        [Display(Name = "Publication Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        // 9. Inventory Quantity
        [Required(ErrorMessage = "Inventory Quantity is required.")]
        [Display(Name = "Qty in Stock")]
        public int InventoryQuantity { get; set; }

        // 10. Reorder Point
        [Required(ErrorMessage = "Reorder Point is required.")]
        [Display(Name = "Reorder Point")]
        public int ReorderPoint { get; set; }

        // 11. Book Status (True if discontinued)
        [Display(Name = "Discontinued?")]
        public bool BookStatus { get; set; }


        // --- Navigational Properties ---

        // Relationship 1: Foreign Key to Genre (One-to-One/Many relationship)
        [Required(ErrorMessage = "Book Genre is required.")]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }
        public virtual Genre? Genre { get; set; }

        // Relationship 2: One-to-Many with OrderDetail (Sales history)
        public List<OrderDetail> OrderDetails { get; set; }

        // Relationship 3: One-to-Many with Review (Customer ratings)
        public List<Review> Reviews { get; set; }

        // Relationship 4: One-to-Many with Reorder (Procurement history) <<<--- ADDITION
        public List<Reorder> Reorders { get; set; }
        // Computed rating (average stars)
        public double? Rating // Change 'Rating' to 'AverageRating'
        {
            get
            {
                if (Reviews == null || Reviews.Count == 0) return 0;
                return Reviews.Average(r => r.Rating);
            }
        }

        // Computed number of times purchased
        public int TimesPurchased
        {
            get
            {
                if (OrderDetails == null) return 0;
                return OrderDetails.Sum(od => od.Quantity);
            }
        }

        // In-stock check
        public bool InStock
        {
            get
            {
                return InventoryQuantity > 0;
            }
        }


        // --- Constructor to initialize lists ---
        public Book()
        {
            OrderDetails = new List<OrderDetail>();
            Reviews = new List<Review>();
            Reorders = new List<Reorder>();
        }
    }
}