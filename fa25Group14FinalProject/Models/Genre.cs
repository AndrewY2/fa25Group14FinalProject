using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace fa25Group14FinalProject.Models
{
    public class Genre
        //genres
    {
        // Primary Key
        public int GenreID { get; set; } // Matches the PK GenreID in the ERD [cite: 72]

        // Scalar Property
        [Display(Name = "Genre Name")]
        [Required(ErrorMessage = "Genre Name is required.")]
        public string GenreName { get; set; } // Matches the GenreName in the ERD [cite: 73]

        // Navigational Property (One-to-Many with Book)
        // A single genre can be associated with multiple books.
        public List<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}