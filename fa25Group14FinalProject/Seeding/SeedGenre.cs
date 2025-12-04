using System;
using System.Linq;
using System.Collections.Generic;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;

namespace fa25Group14FinalProject.Seeding
{
    public static class SeedGenres
    {
        public static void SeedAllGenres(AppDbContext db)
        {
            //Create counter and flag for debugging
            Int32 intGenresAdded = 0;
            String strGenreName = "Begin";

            //Create a list to hold all genres
            List<Genre> Genres = new List<Genre>();

            // ====== GENRE LIST FROM Bevos Bookstore Data v3.xlsx (Books sheet) ======
            Genres.Add(new Genre { GenreName = "Adventure" });
            Genres.Add(new Genre { GenreName = "Contemporary Fiction" });
            Genres.Add(new Genre { GenreName = "Fantasy" });
            Genres.Add(new Genre { GenreName = "Historical Fiction" });
            Genres.Add(new Genre { GenreName = "Horror" });
            Genres.Add(new Genre { GenreName = "Humor" });
            Genres.Add(new Genre { GenreName = "Mystery" });
            Genres.Add(new Genre { GenreName = "Poetry" });
            Genres.Add(new Genre { GenreName = "Romance" });
            Genres.Add(new Genre { GenreName = "Science Fiction" });
            Genres.Add(new Genre { GenreName = "Shakespeare" });
            Genres.Add(new Genre { GenreName = "Suspense" });
            Genres.Add(new Genre { GenreName = "Thriller" });

            try
            {
                foreach (Genre genreToAdd in Genres)
                {
                    //set the flag to help with debugging
                    strGenreName = genreToAdd.GenreName;

                    //look to see if this genre is already in the database
                    Genre dbGenre = db.Genres.FirstOrDefault(g => g.GenreName == genreToAdd.GenreName);

                    if (dbGenre == null)
                    {
                        //Genre not in database – add it
                        db.Genres.Add(genreToAdd);
                        db.SaveChanges();
                        intGenresAdded += 1;
                    }
                    else
                    {
                        //Genre exists – update properties (if needed)
                        dbGenre.GenreName = genreToAdd.GenreName;

                        db.Update(dbGenre);
                        db.SaveChanges();
                        intGenresAdded += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                String msg = "Genres added: " + intGenresAdded + "; Error on " + strGenreName;
                throw new InvalidOperationException(ex.Message + msg);
            }
        }
    }
}