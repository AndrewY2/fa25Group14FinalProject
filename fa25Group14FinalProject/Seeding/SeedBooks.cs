
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fa25Group14FinalProject.Seeding
{

    public static class SeedBooks
    {
        public static void SeedAllBooks(AppDbContext db)
        {
            if (db.Books.Any()) return;
            List<Book> AllBooks = new List<Book>();
            Book b1 = new Book()
            {
                BookNumber = 222001,
                Title = "The Art Of Racing In The Rain",
                Authors = "Garth Stein",
                Description = "A Lab-terrier mix with great insight into the human condition helps his owner, a struggling race car driver.",
                Price = 23.95m,
                Cost = 10.30m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2008-05-24 00:00:00")
            };
            b1.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b1);

            Book b2 = new Book()
            {
                BookNumber = 222002,
                Title = "The Host",
                Authors = "Stephenie Meyer",
                Description = "Aliens have taken control of the minds and bodies of most humans, but one woman won’t surrender.",
                Price = 25.99m,
                Cost = 13.25m,
                ReorderPoint = 7,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2008-05-24 00:00:00")
            };
            b2.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b2);

            Book b3 = new Book()
            {
                BookNumber = 222003,
                Title = "Chasing Darkness",
                Authors = "Robert Crais",
                Description = "The Los Angeles private eye Elvis Cole responsible for the release of a serial killer?",
                Price = 25.95m,
                Cost = 9.08m,
                ReorderPoint = 7,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2008-07-05 00:00:00")
            };
            b3.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b3);

            Book b4 = new Book()
            {
                BookNumber = 222004,
                Title = "Say Goodbye",
                Authors = "Lisa Gardner",
                Description = "An F.B.I. agent tracks a serial killer who uses spiders as a weapon.",
                Price = 25.00m,
                Cost = 11.25m,
                ReorderPoint = 2,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2008-07-19 00:00:00")
            };
            b4.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b4);

            Book b5 = new Book()
            {
                BookNumber = 222005,
                Title = "The Gargoyle",
                Authors = "Andrew Davidson",
                Description = "A hideously burned man is cared for by a sculptress who claims they were lovers seven centuries ago.",
                Price = 25.95m,
                Cost = 16.09m,
                ReorderPoint = 3,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2008-08-09 00:00:00")
            };
            b5.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b5);

            Book b6 = new Book()
            {
                BookNumber = 222006,
                Title = "Foreign Body",
                Authors = "Robin Cook",
                Description = "A medical student investigates a rising number of deaths among medical tourists at foreign hospitals.",
                Price = 25.95m,
                Cost = 24.65m,
                ReorderPoint = 6,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2008-08-09 00:00:00")
            };
            b6.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b6);

            Book b7 = new Book()
            {
                BookNumber = 222007,
                Title = "Acheron",
                Authors = "Sherrilyn Kenyon",
                Description = "Book 12 of the Dark-Hunter paranormal series.",
                Price = 24.95m,
                Cost = 13.72m,
                ReorderPoint = 2,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2008-08-09 00:00:00")
            };
            b7.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b7);

            Book b8 = new Book()
            {
                BookNumber = 222008,
                Title = "Being Elizabeth",
                Authors = "Barbara Taylor Bradford",
                Description = "A 25-year-old newly in control of her family’s corporate empire faces tough choices in business and in love.",
                Price = 27.95m,
                Cost = 21.80m,
                ReorderPoint = 5,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2008-08-23 00:00:00")
            };
            b8.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b8);

            Book b9 = new Book()
            {
                BookNumber = 222009,
                Title = "Just Breathe",
                Authors = "Susan Wiggs",
                Description = "Her marriage broken, the author of a syndicated comic strip flees to California, where romance and surprise await.",
                Price = 25.95m,
                Cost = 5.45m,
                ReorderPoint = 8,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2008-08-30 00:00:00")
            };
            b9.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b9);

            Book b10 = new Book()
            {
                BookNumber = 222010,
                Title = "The Gypsy Morph",
                Authors = "Terry Brooks",
                Description = "In the third volume of the Genesis of Shannara series, champions of the Word and the Void clash.",
                Price = 27.00m,
                Cost = 6.75m,
                ReorderPoint = 6,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2008-08-30 00:00:00")
            };
            b10.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b10);

            Book b11 = new Book()
            {
                BookNumber = 222011,
                Title = "The Other Queen",
                Authors = "Philippa Gregory",
                Description = "The story of Mary, Queen of Scots, in captivity under Queen Elizabeth.",
                Price = 25.95m,
                Cost = 23.61m,
                ReorderPoint = 3,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2008-09-20 00:00:00")
            };
            b11.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b11);

            Book b12 = new Book()
            {
                BookNumber = 222012,
                Title = "One Fifth Avenue",
                Authors = "Candace Bushnell",
                Description = "The worlds of gossip, theater and hedge funds have one address in common.",
                Price = 25.95m,
                Cost = 17.65m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2008-09-27 00:00:00")
            };
            b12.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b12);

            Book b13 = new Book()
            {
                BookNumber = 222013,
                Title = "The Given Day",
                Authors = "Dennis Lehane",
                Description = "A policman, a fugitive and their families persevere in the turbulence of Boston at the end of World War I.",
                Price = 27.95m,
                Cost = 6.99m,
                ReorderPoint = 6,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2008-09-27 00:00:00")
            };
            b13.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b13);

            Book b14 = new Book()
            {
                BookNumber = 222014,
                Title = "A Cedar Cove Christmas",
                Authors = "Debbie Macomber",
                Description = "A pregnant woman shows up in Cedar Cove on Christmas Eve and goes into labor in a room above a stable.",
                Price = 16.95m,
                Cost = 4.75m,
                ReorderPoint = 4,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2008-10-04 00:00:00")
            };
            b14.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b14);

            Book b15 = new Book()
            {
                BookNumber = 222015,
                Title = "The Pirate King",
                Authors = "R A Salvatore",
                Description = "In Book 2 of the Transitions fantasy series, Drizzt returns to Luskan, a city dominated by dangerous pirates.",
                Price = 27.95m,
                Cost = 14.25m,
                ReorderPoint = 5,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2008-10-11 00:00:00")
            };
            b15.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b15);

            Book b16 = new Book()
            {
                BookNumber = 222016,
                Title = "Bones",
                Authors = "Jonathan Kellerman",
                Description = "The psychologist-detective Alex Delaware is called in when women’s bodies keep turning up in a Los Angeles marsh.",
                Price = 27.00m,
                Cost = 14.85m,
                ReorderPoint = 2,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2008-10-25 00:00:00")
            };
            b16.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b16);

            Book b17 = new Book()
            {
                BookNumber = 222017,
                Title = "Rough Weather",
                Authors = "Robert B Parker",
                Description = "The Boston private eye Spenser gets involved when a gunman kidnaps the bride from her wedding on a private island.",
                Price = 26.95m,
                Cost = 20.75m,
                ReorderPoint = 8,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2008-10-25 00:00:00")
            };
            b17.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b17);

            Book b18 = new Book()
            {
                BookNumber = 222018,
                Title = "Extreme Measures",
                Authors = "Vince Flynn",
                Description = "Mitch Rapp teams up with a C.I.A. colleague to fight a terrorist cell — and the politicians who would rein them in.",
                Price = 27.95m,
                Cost = 15.09m,
                ReorderPoint = 2,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2008-10-25 00:00:00")
            };
            b18.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b18);

            Book b19 = new Book()
            {
                BookNumber = 222019,
                Title = "A Good Woman",
                Authors = "Danielle Steel",
                Description = "An American society girl who made a new life as a doctor in World War I France returns to New York.",
                Price = 27.00m,
                Cost = 10.53m,
                ReorderPoint = 1,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2008-11-01 00:00:00")
            };
            b19.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b19);

            Book b20 = new Book()
            {
                BookNumber = 222020,
                Title = "Midnight",
                Authors = "Sister Souljah",
                Description = "A boy from Sudan struggles to protect his mother and sister and remain true to his Islamic principles in a Brooklyn housing project.",
                Price = 26.95m,
                Cost = 21.29m,
                ReorderPoint = 3,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2008-11-08 00:00:00")
            };
            b20.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b20);

            Book b21 = new Book()
            {
                BookNumber = 222021,
                Title = "Scarpetta",
                Authors = "Patricia Cornwell",
                Description = "The forensic pathologist Kay Scarpetta takes an assignment in New York City.",
                Price = 27.95m,
                Cost = 13.14m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2008-12-06 00:00:00")
            };
            b21.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b21);

            Book b22 = new Book()
            {
                BookNumber = 222022,
                Title = "A Darker Place",
                Authors = "Jack Higgins",
                Description = "A Russian defector becomes a counterspy.",
                Price = 26.95m,
                Cost = 11.86m,
                ReorderPoint = 7,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2009-01-31 00:00:00")
            };
            b22.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b22);

            Book b23 = new Book()
            {
                BookNumber = 222023,
                Title = "Fatally Flaky",
                Authors = "Diane Mott Davidson",
                Description = "The caterer Goldy Schulz tries to outwit a killer on the grounds of an Aspen spa.",
                Price = 25.99m,
                Cost = 22.09m,
                ReorderPoint = 1,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2009-04-11 00:00:00")
            };
            b23.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b23);

            Book b24 = new Book()
            {
                BookNumber = 222024,
                Title = "Turn Coat",
                Authors = "Jim Butcher",
                Description = "Book 11 of the Dresden Files series about a wizard detective in Chicago.",
                Price = 25.95m,
                Cost = 9.34m,
                ReorderPoint = 3,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2009-04-11 00:00:00")
            };
            b24.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b24);

            Book b25 = new Book()
            {
                BookNumber = 222025,
                Title = "Borderline",
                Authors = "Nevada Barr",
                Description = "Off duty and on vacation in Big Bend National Park, Anna Pigeon rescues a baby and is drawn into cross-border intrigue.",
                Price = 25.95m,
                Cost = 3.11m,
                ReorderPoint = 3,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2009-04-11 00:00:00")
            };
            b25.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b25);

            Book b26 = new Book()
            {
                BookNumber = 222026,
                Title = "Summer On Blossom Street",
                Authors = "Debbie Macomber",
                Description = "More stories of life and love from a Seattle knitting class.",
                Price = 24.95m,
                Cost = 7.24m,
                ReorderPoint = 2,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2009-05-02 00:00:00")
            };
            b26.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b26);

            Book b27 = new Book()
            {
                BookNumber = 222027,
                Title = "Dead And Gone",
                Authors = "Charlaine Harris",
                Description = "Sookie Stackhouse searches for the killer of a werepanther.",
                Price = 25.95m,
                Cost = 24.65m,
                ReorderPoint = 5,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2009-05-09 00:00:00")
            };
            b27.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b27);

            Book b28 = new Book()
            {
                BookNumber = 222028,
                Title = "Brooklyn",
                Authors = "Colm Toibin",
                Description = "An unsophisticated young Irishwoman leaves her home for New York in the 1950s. Originally published in 2009 and the basis of the 2015 movie.",
                Price = 18.95m,
                Cost = 3.60m,
                ReorderPoint = 1,
                InventoryQuantity = 1,
                PublishDate = DateTime.Parse("2009-05-09 00:00:00")
            };
            b28.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b28);

            Book b29 = new Book()
            {
                BookNumber = 222029,
                Title = "The Last Child",
                Authors = "John Hart",
                Description = "A teenager searches for his inexplicably vanished twin sister.",
                Price = 24.95m,
                Cost = 15.72m,
                ReorderPoint = 2,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2009-05-16 00:00:00")
            };
            b29.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b29);

            Book b30 = new Book()
            {
                BookNumber = 222030,
                Title = "Heartless",
                Authors = "Diana Palmer",
                Description = "A woman‘s secret makes it hard for her to accept her stepbrother‘s love.",
                Price = 24.95m,
                Cost = 21.46m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2009-05-30 00:00:00")
            };
            b30.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b30);

            Book b31 = new Book()
            {
                BookNumber = 222031,
                Title = "Shanghai Girls",
                Authors = "Lisa See",
                Description = "Two Chinese sisters in the 1930s are sold as wives to men from California, and leave their war-torn country to join them.",
                Price = 25.00m,
                Cost = 2.50m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2009-05-30 00:00:00")
            };
            b31.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b31);

            Book b32 = new Book()
            {
                BookNumber = 222032,
                Title = "Skin Trade",
                Authors = "Laurell K Hamilton",
                Description = "Investigating some killings in Las Vegas, the vampire hunter Anita Blake must contend with the power of the weretigers.",
                Price = 26.95m,
                Cost = 2.70m,
                ReorderPoint = 8,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2009-06-06 00:00:00")
            };
            b32.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b32);

            Book b33 = new Book()
            {
                BookNumber = 222033,
                Title = "Roadside Crosses",
                Authors = "Jeffery Deaver",
                Description = "A California kinesics expert pursues a killer who stalks victims using information they’ve posted online.",
                Price = 26.95m,
                Cost = 7.82m,
                ReorderPoint = 8,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2009-06-13 00:00:00")
            };
            b33.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b33);

            Book b34 = new Book()
            {
                BookNumber = 222034,
                Title = "Finger Lickin’ Fifteen",
                Authors = "Janet Evanovich",
                Description = "The bounty hunter Stephanie Plum hunts a celebrity chef’s killer.",
                Price = 27.95m,
                Cost = 3.63m,
                ReorderPoint = 4,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2009-06-27 00:00:00")
            };
            b34.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b34);

            Book b35 = new Book()
            {
                BookNumber = 222035,
                Title = "Return To Sullivans Island",
                Authors = "Dorothea Benton Frank",
                Description = "A recent college graduate returns to her family’s home on an island in the South Carolina Lowcountry and wrestles with tragedy and betrayal in the company of her appealing relatives.",
                Price = 25.99m,
                Cost = 13.25m,
                ReorderPoint = 8,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2009-07-04 00:00:00")
            };
            b35.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b35);

            Book b36 = new Book()
            {
                BookNumber = 222036,
                Title = "The Castaways",
                Authors = "Elin Hilderbrand",
                Description = "A Nantucket couple drowns, raising questions and precipitating conflicts among their group of friends.",
                Price = 24.99m,
                Cost = 16.99m,
                ReorderPoint = 2,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2009-07-11 00:00:00")
            };
            b36.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b36);

            Book b37 = new Book()
            {
                BookNumber = 222037,
                Title = "Rain Gods",
                Authors = "James Lee Burke",
                Description = "A Texas sheriff investigates a mass murder of illegal aliens and tries to find the young Iraq war veteran who may have been involved — before the F.B.I. can.",
                Price = 25.99m,
                Cost = 21.05m,
                ReorderPoint = 2,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2009-07-18 00:00:00")
            };
            b37.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b37);

            Book b38 = new Book()
            {
                BookNumber = 222038,
                Title = "Undone",
                Authors = "Karin Slaughter",
                Description = "Dr. Sara Linton works with agents of the Georgia Bureau of Investigation to stop a killer who tortures his victims.",
                Price = 26.00m,
                Cost = 7.28m,
                ReorderPoint = 2,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2009-07-18 00:00:00")
            };
            b38.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b38);

            Book b39 = new Book()
            {
                BookNumber = 222039,
                Title = "Guardian Of Lies",
                Authors = "Steve Martini",
                Description = "The lawyer Paul Madriani unravels a mystery involving gold coins, the C.I.A., and a weapon forgotten since the Cuban missile crisis.",
                Price = 26.99m,
                Cost = 18.62m,
                ReorderPoint = 2,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2009-07-18 00:00:00")
            };
            b39.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b39);

            Book b40 = new Book()
            {
                BookNumber = 222040,
                Title = "Dreamfever",
                Authors = "Karen Marie Moning",
                Description = "MacKlaya finds herself under the erotic spell of a Fae master.",
                Price = 26.00m,
                Cost = 21.06m,
                ReorderPoint = 6,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2009-08-22 00:00:00")
            };
            b40.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b40);

            Book b41 = new Book()
            {
                BookNumber = 222041,
                Title = "Resurrecting Midnight",
                Authors = "Eric Jerome Dickey",
                Description = "Gideon, an international assassin, travels to Argentina in pursuit of a dangerous assignment.",
                Price = 26.95m,
                Cost = 14.55m,
                ReorderPoint = 3,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2009-08-29 00:00:00")
            };
            b41.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b41);

            Book b42 = new Book()
            {
                BookNumber = 222042,
                Title = "Dexter By Design",
                Authors = "Jeff Lindsay",
                Description = "A serial killer who arranges victims in artful poses challenges the Miami Police Department and its blood splatter analyst, Dexter.",
                Price = 25.00m,
                Cost = 2.75m,
                ReorderPoint = 9,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2009-09-12 00:00:00")
            };
            b42.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b42);

            Book b43 = new Book()
            {
                BookNumber = 222043,
                Title = "The Professional",
                Authors = "Robert B Parker",
                Description = "Rich women are turning up dead, and the Boston P.I. Spenser investigates.",
                Price = 26.95m,
                Cost = 7.01m,
                ReorderPoint = 8,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2009-10-10 00:00:00")
            };
            b43.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b43);

            Book b44 = new Book()
            {
                BookNumber = 222044,
                Title = "The Unseen Academicals",
                Authors = "Terry Pratchett",
                Description = "In this Discworld fantasy, the benevolent tyrant of Ankh-Morpork suggests that Unseen University put together a football team.",
                Price = 25.99m,
                Cost = 3.12m,
                ReorderPoint = 9,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2009-10-10 00:00:00")
            };
            b44.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b44);

            Book b45 = new Book()
            {
                BookNumber = 222045,
                Title = "Pursuit Of Honor",
                Authors = "Vince Flynn",
                Description = "The counterterrorism operative Mitch Rapp must teach politicians about national security following a new Qaeda attack.",
                Price = 27.99m,
                Cost = 5.04m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2009-10-17 00:00:00")
            };
            b45.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b45);

            Book b46 = new Book()
            {
                BookNumber = 222046,
                Title = "No Less Than Victory",
                Authors = "Jeff Shaara",
                Description = "The final volume of a trilogy of novels about World War II focuses on the final years of the war, including the Battle of the Bulge and the American sweep through Germany.",
                Price = 28.00m,
                Cost = 20.72m,
                ReorderPoint = 1,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2009-11-07 00:00:00")
            };
            b46.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b46);

            Book b47 = new Book()
            {
                BookNumber = 222047,
                Title = "Ford County",
                Authors = "John Grisham",
                Description = "Stories set in rural Mississippi.",
                Price = 24.00m,
                Cost = 14.88m,
                ReorderPoint = 10,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2009-11-07 00:00:00")
            };
            b47.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b47);

            Book b48 = new Book()
            {
                BookNumber = 222048,
                Title = "Wishin' And Hopin'",
                Authors = "Wally Lamb",
                Description = "A fifth-grader in 1964 gets ready for Christmas.",
                Price = 15.00m,
                Cost = 13.95m,
                ReorderPoint = 3,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2009-11-14 00:00:00")
            };
            b48.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Humor");
            AllBooks.Add(b48);

            Book b49 = new Book()
            {
                BookNumber = 222049,
                Title = "First Lord’S Fury",
                Authors = "Jim Butcher",
                Description = "With their survival at stake, Alerans prepare for a final battle in the sixth book of the Alera fantasy cycle.",
                Price = 25.95m,
                Cost = 13.23m,
                ReorderPoint = 1,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2009-11-28 00:00:00")
            };
            b49.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b49);

            Book b50 = new Book()
            {
                BookNumber = 222050,
                Title = "Altar Of Eden",
                Authors = "James Rollins",
                Description = "A Louisiana veterinarian discovers a wrecked fishing trawler filled with genetically altered animals.",
                Price = 27.99m,
                Cost = 25.75m,
                ReorderPoint = 1,
                InventoryQuantity = 1,
                PublishDate = DateTime.Parse("2010-01-02 00:00:00")
            };
            b50.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b50);

            Book b51 = new Book()
            {
                BookNumber = 222051,
                Title = "Deeper Than The Dead",
                Authors = "Tami Hoag",
                Description = "An F.B.I. investigator and a teacher track a series of murders in California in 1985.",
                Price = 26.95m,
                Cost = 9.70m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2010-01-02 00:00:00")
            };
            b51.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b51);

            Book b52 = new Book()
            {
                BookNumber = 222052,
                Title = "Roses",
                Authors = "Leila Meacham",
                Description = "Three generations in a small East Texas town.",
                Price = 24.99m,
                Cost = 20.99m,
                ReorderPoint = 8,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2010-01-16 00:00:00")
            };
            b52.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b52);

            Book b53 = new Book()
            {
                BookNumber = 222053,
                Title = "Blood Ties",
                Authors = "Kay Hooper",
                Description = "The F.B.I. agent Noah Bishop and his special crimes unit  pursue a brutal enemy.",
                Price = 26.00m,
                Cost = 5.20m,
                ReorderPoint = 7,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2010-01-30 00:00:00")
            };
            b53.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b53);

            Book b54 = new Book()
            {
                BookNumber = 222054,
                Title = "The Midnight House",
                Authors = "Alex Berenson",
                Description = "Who is killing members of a secret unit that interrogated terrorists? The C.I.A. agent John Wells is on the case.",
                Price = 25.95m,
                Cost = 3.11m,
                ReorderPoint = 5,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2010-02-13 00:00:00")
            };
            b54.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b54);

            Book b55 = new Book()
            {
                BookNumber = 222055,
                Title = "Poor Little Bitch Girl",
                Authors = "Jackie Collins",
                Description = "Hollywood murder, three beautiful 20-something high school friends, a hot New York club owner.",
                Price = 26.99m,
                Cost = 17.54m,
                ReorderPoint = 1,
                InventoryQuantity = 1,
                PublishDate = DateTime.Parse("2010-02-13 00:00:00")
            };
            b55.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b55);

            Book b56 = new Book()
            {
                BookNumber = 222056,
                Title = "Deep Shadow",
                Authors = "Randy Wayne White",
                Description = "Murderers want Doc Ford to help them dive for the remains of a wrecked plane supposedly laden with Cuban gold.",
                Price = 25.95m,
                Cost = 5.45m,
                ReorderPoint = 1,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2010-03-13 00:00:00")
            };
            b56.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b56);

            Book b57 = new Book()
            {
                BookNumber = 222057,
                Title = "Think Twice",
                Authors = "Lisa Scottoline",
                Description = "A woman takes over her twin sister’s life.",
                Price = 26.99m,
                Cost = 21.86m,
                ReorderPoint = 6,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2010-03-20 00:00:00")
            };
            b57.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b57);

            Book b58 = new Book()
            {
                BookNumber = 222058,
                Title = "The Girl Who Chased The Moon",
                Authors = "Sarah Addison Allen",
                Description = "Mysteries and magic in a quirky North Carolina town.",
                Price = 25.00m,
                Cost = 11.25m,
                ReorderPoint = 3,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2010-03-20 00:00:00")
            };
            b58.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b58);

            Book b59 = new Book()
            {
                BookNumber = 222059,
                Title = "Without Mercy",
                Authors = "Lisa Jackson",
                Description = "Students are dying at an Oregon boarding school for wayward kids, and the concerned new teacher may be the next target.",
                Price = 25.00m,
                Cost = 4.25m,
                ReorderPoint = 3,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2010-04-03 00:00:00")
            };
            b59.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b59);

            Book b60 = new Book()
            {
                BookNumber = 222060,
                Title = "Wrecked",
                Authors = "Carol Higgins Clark",
                Description = "In the 13th mystery in this series, the suspicious disappearance of a neighbor interrupts a romantic weekend on Cape Cod for the P.I. Regan Reilly and her husband.",
                Price = 25.00m,
                Cost = 18.00m,
                ReorderPoint = 8,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2010-04-17 00:00:00")
            };
            b60.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b60);

            Book b61 = new Book()
            {
                BookNumber = 222061,
                Title = "Reckless",
                Authors = "Andrew Gross",
                Description = "A close friend from the investigator Ty Hauck's past has been brutally murdered, and he will risk everything he loves to avenge her death.",
                Price = 22.00m,
                Cost = 9.46m,
                ReorderPoint = 8,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2010-05-01 00:00:00")
            };
            b61.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b61);

            Book b62 = new Book()
            {
                BookNumber = 222062,
                Title = "Executive Intent",
                Authors = "Dale Brown",
                Description = "With the United States unleashing a missile-launching satellite that can strike anywhere in seconds, China and Russia respond swiftly and brutally.",
                Price = 27.95m,
                Cost = 22.64m,
                ReorderPoint = 7,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2010-05-15 00:00:00")
            };
            b62.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b62);

            Book b63 = new Book()
            {
                BookNumber = 222063,
                Title = "Heart Of The Matter",
                Authors = "Emily Giffin",
                Description = "The lives of two women — one married to a pediatric plastic surgeon, the other a lawyer and single mother — converge after an accident involving the lawyer’s son.",
                Price = 26.99m,
                Cost = 6.21m,
                ReorderPoint = 3,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2010-05-15 00:00:00")
            };
            b63.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b63);

            Book b64 = new Book()
            {
                BookNumber = 222064,
                Title = "That Perfect Someone",
                Authors = "Johanna Lindsey",
                Description = "To avoid falling into a ruthless nobleman's trap, an heiress enters into a risky, intimate charade with a man she was once bound to wed.",
                Price = 25.00m,
                Cost = 18.25m,
                ReorderPoint = 9,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2010-06-19 00:00:00")
            };
            b64.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b64);

            Book b65 = new Book()
            {
                BookNumber = 222065,
                Title = "Mission Of Honor",
                Authors = "David Weber",
                Description = "Honor Harrington defends the Star Kingdom of Manticore as it is besieged by many enemies.",
                Price = 27.00m,
                Cost = 6.75m,
                ReorderPoint = 1,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2010-06-26 00:00:00")
            };
            b65.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b65);

            Book b66 = new Book()
            {
                BookNumber = 222066,
                Title = "Sizzling Sixteen",
                Authors = "Janet Evanovich",
                Description = "The bounty hunter Stephanie Plum comes to the aid of a cousin with gambling debts.",
                Price = 27.99m,
                Cost = 12.32m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2010-06-26 00:00:00")
            };
            b66.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b66);

            Book b67 = new Book()
            {
                BookNumber = 222067,
                Title = "The Thousand Autumns Of Jacob De Zoet",
                Authors = "David Mitchell",
                Description = "Forbidden love in Edo-era Japan.",
                Price = 26.00m,
                Cost = 9.62m,
                ReorderPoint = 10,
                InventoryQuantity = 15,
                PublishDate = DateTime.Parse("2010-07-03 00:00:00")
            };
            b67.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b67);

            Book b68 = new Book()
            {
                BookNumber = 222068,
                Title = "The Search",
                Authors = "Nora Roberts",
                Description = "The only survivor of a serial killer has found peace in the Pacific Northwest, but her life is shaken by the appearance of a new man and a copycat murderer.",
                Price = 26.95m,
                Cost = 8.62m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2010-07-10 00:00:00")
            };
            b68.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b68);

            Book b69 = new Book()
            {
                BookNumber = 222069,
                Title = "Death On The D-List",
                Authors = "Nancy Grace",
                Description = "Fading celebrities who appear on Hailey Dean’s TV show are being murdered.",
                Price = 25.99m,
                Cost = 5.98m,
                ReorderPoint = 1,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2010-08-14 00:00:00")
            };
            b69.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b69);

            Book b70 = new Book()
            {
                BookNumber = 222070,
                Title = "No Mercy",
                Authors = "Sherrilyn Kenyon",
                Description = "Book 19 of the Dark-Hunter paranormal series.",
                Price = 24.99m,
                Cost = 5.25m,
                ReorderPoint = 10,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2010-09-11 00:00:00")
            };
            b70.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b70);

            Book b71 = new Book()
            {
                BookNumber = 222071,
                Title = "The Fall",
                Authors = "Guillermo del Toro and Chuck Hogan",
                Description = "A war erupts between Old and New World vampires. Book 2 of the Strain trilogy.",
                Price = 26.99m,
                Cost = 13.23m,
                ReorderPoint = 7,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2010-09-25 00:00:00")
            };
            b71.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b71);

            Book b72 = new Book()
            {
                BookNumber = 222072,
                Title = "Legacy",
                Authors = "Danielle Steel",
                Description = "A writer’s stunning family discovery leads to Paris, the French aristocracy and a mysterious Sioux ancestor.",
                Price = 28.00m,
                Cost = 6.44m,
                ReorderPoint = 1,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2010-10-02 00:00:00")
            };
            b72.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b72);

            Book b73 = new Book()
            {
                BookNumber = 222073,
                Title = "Call Me Mrs. Miracle",
                Authors = "Debbie Macomber",
                Description = "Working in the toy section of a department store, Emily Merkle is called upon to engineer some Christmas miracles.",
                Price = 16.95m,
                Cost = 8.31m,
                ReorderPoint = 4,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2010-10-02 00:00:00")
            };
            b73.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b73);

            Book b74 = new Book()
            {
                BookNumber = 222074,
                Title = "Promise Me",
                Authors = "Richard Paul Evans",
                Description = "On Christmas Day, a woman with family problems meets a handsome, mysterious stranger.",
                Price = 19.99m,
                Cost = 10.79m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2010-10-09 00:00:00")
            };
            b74.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b74);

            Book b75 = new Book()
            {
                BookNumber = 222075,
                Title = "Crescent Dawn",
                Authors = "Clive Cussler and Dirk Cussler",
                Description = "Dirk Pitt seeks a tie between a trove of ancient Roman artifacts and a series of mosque explosions.",
                Price = 27.95m,
                Cost = 20.12m,
                ReorderPoint = 4,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2010-11-20 00:00:00")
            };
            b75.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Adventure");
            AllBooks.Add(b75);

            Book b76 = new Book()
            {
                BookNumber = 222076,
                Title = "An Object Of Beauty",
                Authors = "Steve Martin",
                Description = "A young, beautiful and ambitious woman ruthlessly ascends the heights of the Manhattan art world.",
                Price = 26.99m,
                Cost = 8.91m,
                ReorderPoint = 6,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2010-11-27 00:00:00")
            };
            b76.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b76);

            Book b77 = new Book()
            {
                BookNumber = 222077,
                Title = "Dead Or Alive",
                Authors = "Tom Clancy with Grant Blackwood",
                Description = "Many characters from Clancy’s previous novels make an appearance as an intelligence group tracks a vicious terrorist called the Emir.",
                Price = 28.95m,
                Cost = 24.03m,
                ReorderPoint = 8,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2010-12-11 00:00:00")
            };
            b77.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b77);

            Book b78 = new Book()
            {
                BookNumber = 222078,
                Title = "Damage",
                Authors = "John Lescroart",
                Description = "The San Francisco detective Abe Glitsky faces a scion of wealth who’s seeking revenge against those who sent him to prison a decade ago.",
                Price = 26.95m,
                Cost = 24.26m,
                ReorderPoint = 7,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2011-01-08 00:00:00")
            };
            b78.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b78);

            Book b79 = new Book()
            {
                BookNumber = 222079,
                Title = "The Inner Circle",
                Authors = "Brad Meltzer",
                Description = "An archivist discovers a book that once belonged to George Washington and conceals a deadly secret.",
                Price = 26.99m,
                Cost = 11.61m,
                ReorderPoint = 8,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2011-01-15 00:00:00")
            };
            b79.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b79);

            Book b80 = new Book()
            {
                BookNumber = 222080,
                Title = "Shadowfever",
                Authors = "Karen Marie Moning",
                Description = "Hunting for her sister’s murderer, MacKayla Lane is caught up in the struggle between humans and the Fae.",
                Price = 26.00m,
                Cost = 13.78m,
                ReorderPoint = 9,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2011-01-22 00:00:00")
            };
            b80.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b80);

            Book b81 = new Book()
            {
                BookNumber = 222081,
                Title = "Call Me Irresistible",
                Authors = "Susan Elizabeth Phillips",
                Description = "In a small town in Texas, characters from Phillips’s earlier novels reappear as a woman persuades a friend to call off her wedding to the town’s popular mayor.",
                Price = 25.99m,
                Cost = 11.44m,
                ReorderPoint = 3,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2011-01-22 00:00:00")
            };
            b81.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b81);

            Book b82 = new Book()
            {
                BookNumber = 222082,
                Title = "A Discovery Of Witches",
                Authors = "Deborah Harkness",
                Description = "The recovery of a lost ancient manuscript in a library at Oxford sets a fantastical underworld stirring.",
                Price = 28.95m,
                Cost = 3.76m,
                ReorderPoint = 7,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2011-02-12 00:00:00")
            };
            b82.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b82);

            Book b83 = new Book()
            {
                BookNumber = 222083,
                Title = "Gideon’s Sword",
                Authors = "Douglas Preston and Lincoln Child",
                Description = "Gideon Crew avenges his father’s death and is sent on a mission by a government contractor.",
                Price = 26.99m,
                Cost = 19.70m,
                ReorderPoint = 9,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2011-02-26 00:00:00")
            };
            b83.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b83);

            Book b84 = new Book()
            {
                BookNumber = 222084,
                Title = "Treachery In Death",
                Authors = "J D Robb",
                Description = "Eve Dallas and her partner, Peabody, investigate a grocer’s murder.",
                Price = 26.95m,
                Cost = 5.93m,
                ReorderPoint = 5,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2011-02-26 00:00:00")
            };
            b84.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b84);

            Book b85 = new Book()
            {
                BookNumber = 222085,
                Title = "Live Wire",
                Authors = "Harlan Coben",
                Description = "Myron Bolitar’s search for a missing rock star leads to questions about his own missing brother.",
                Price = 27.95m,
                Cost = 13.98m,
                ReorderPoint = 6,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2011-03-26 00:00:00")
            };
            b85.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b85);

            Book b86 = new Book()
            {
                BookNumber = 222086,
                Title = "A Lesson In Secrets",
                Authors = "Jacqueline Winspear",
                Description = "In the summer of 1932, Maisie Dobbs’s first assignment for the British secret service takes her undercover to Cambridge as a professor.",
                Price = 25.99m,
                Cost = 12.22m,
                ReorderPoint = 7,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2011-03-26 00:00:00")
            };
            b86.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b86);

            Book b87 = new Book()
            {
                BookNumber = 222087,
                Title = "Crunch Time",
                Authors = "Diane Mott Davidson",
                Description = "The caterer and sleuth Goldy Schulz tries to help a friend whose rental house has been destroyed by arson.",
                Price = 26.99m,
                Cost = 3.78m,
                ReorderPoint = 2,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2011-04-09 00:00:00")
            };
            b87.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b87);

            Book b88 = new Book()
            {
                BookNumber = 222088,
                Title = "I’Ll Walk Alone",
                Authors = "Mary Higgins Clark",
                Description = "A woman haunted by the disappearance of her young son discovers that someone has stolen her identity.",
                Price = 25.99m,
                Cost = 3.90m,
                ReorderPoint = 9,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2011-04-09 00:00:00")
            };
            b88.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b88);

            Book b89 = new Book()
            {
                BookNumber = 222089,
                Title = "The Fifth Witness",
                Authors = "Michael Connelly",
                Description = "The defense lawyer Mickey Haller represents a woman facing home foreclosure who is accused of killing a banker.",
                Price = 27.99m,
                Cost = 6.16m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2011-04-09 00:00:00")
            };
            b89.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b89);

            Book b90 = new Book()
            {
                BookNumber = 222090,
                Title = "Save Me",
                Authors = "Lisa Scottoline",
                Description = "A mother’s action during a school emergency causes an uproar in a Philadelphia suburb.",
                Price = 27.99m,
                Cost = 11.20m,
                ReorderPoint = 6,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2011-04-16 00:00:00")
            };
            b90.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b90);

            Book b91 = new Book()
            {
                BookNumber = 222091,
                Title = "Quicksilver",
                Authors = "Amanda Quick",
                Description = "In this Arcane Society novel set in Victorian London, two paranormal talents must find a murderer before they become the next victims.",
                Price = 25.95m,
                Cost = 23.10m,
                ReorderPoint = 6,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2011-04-23 00:00:00")
            };
            b91.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b91);

            Book b92 = new Book()
            {
                BookNumber = 222092,
                Title = "The Sixth Man",
                Authors = "David Baldacci",
                Description = "The lawyer for an alleged serial killer is murdered, and two former Secret Service agents are on the case.",
                Price = 27.99m,
                Cost = 20.15m,
                ReorderPoint = 4,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2011-04-23 00:00:00")
            };
            b92.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b92);

            Book b93 = new Book()
            {
                BookNumber = 222093,
                Title = "Those In Peril",
                Authors = "Wilbur Smith",
                Description = "A private security agent battles pirates who have kidnapped a woman from a yacht in the Indian Ocean.",
                Price = 27.99m,
                Cost = 16.23m,
                ReorderPoint = 8,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2011-05-14 00:00:00")
            };
            b93.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b93);

            Book b94 = new Book()
            {
                BookNumber = 222094,
                Title = "The Jefferson Key",
                Authors = "Steve Berry",
                Description = "The former government operative Cotton Malone foils an assassination attempt on the president and finds himself at dangerous odds with a secret society.",
                Price = 26.00m,
                Cost = 18.20m,
                ReorderPoint = 8,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2011-05-21 00:00:00")
            };
            b94.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b94);

            Book b95 = new Book()
            {
                BookNumber = 222095,
                Title = "Summer Rental",
                Authors = "Mary Kay Andrews",
                Description = "Three friends in their mid-30s spend a month on North Carolina’s Outer Banks.",
                Price = 25.99m,
                Cost = 9.62m,
                ReorderPoint = 9,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2011-06-11 00:00:00")
            };
            b95.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b95);

            Book b96 = new Book()
            {
                BookNumber = 222096,
                Title = "One Summer",
                Authors = "David Baldacci",
                Description = "As Christmas nears, a terminally ill man is preparing his family for his death when another tragedy strikes.",
                Price = 25.99m,
                Cost = 20.01m,
                ReorderPoint = 2,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2011-06-18 00:00:00")
            };
            b96.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b96);

            Book b97 = new Book()
            {
                BookNumber = 222097,
                Title = "Before I Go To Sleep",
                Authors = "S J Watson",
                Description = "After a mysterious accident, an amnesiac cannot remember her past or form new memories.",
                Price = 14.99m,
                Cost = 6.00m,
                ReorderPoint = 1,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2011-06-18 00:00:00")
            };
            b97.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b97);

            Book b98 = new Book()
            {
                BookNumber = 222098,
                Title = "Now You See Her",
                Authors = "James Patterson and Michael Ledwidge",
                Description = "Nina Bloom, who years ago changed her identity to save her life, is forced to confront the past and the killer she thought she had escaped.",
                Price = 27.99m,
                Cost = 8.40m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2011-07-02 00:00:00")
            };
            b98.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b98);

            Book b99 = new Book()
            {
                BookNumber = 222099,
                Title = "Full Black",
                Authors = "Brad Thor",
                Description = "The covert counterterrorism operative Scot Harvath has a plan to stop a terrorist group that wants to take down the United States.",
                Price = 26.99m,
                Cost = 5.67m,
                ReorderPoint = 4,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2011-07-30 00:00:00")
            };
            b99.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b99);

            Book b100 = new Book()
            {
                BookNumber = 222100,
                Title = "Ghost Story",
                Authors = "Jim Butcher",
                Description = "Harry Dresden, the wizard detective in Chicago, has been murdered. But that doesn’t stop him when his friends are in danger.",
                Price = 27.95m,
                Cost = 12.02m,
                ReorderPoint = 9,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2011-07-30 00:00:00")
            };
            b100.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b100);

            Book b101 = new Book()
            {
                BookNumber = 222101,
                Title = "Back Of Beyond",
                Authors = "C J Box",
                Description = "Cody Hoyt, a brilliant cop and an alcoholic struggling with two months of sobriety, is determined to find his mentor’s killer.",
                Price = 25.99m,
                Cost = 24.69m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2011-08-06 00:00:00")
            };
            b101.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b101);

            Book b102 = new Book()
            {
                BookNumber = 222102,
                Title = "The Omen Machine",
                Authors = "Terry Goodkind",
                Description = "A return to the lives of Richard Rahl and Kahlan Amnell, in a tale of a new threat to their world.",
                Price = 29.99m,
                Cost = 17.69m,
                ReorderPoint = 7,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2011-08-20 00:00:00")
            };
            b102.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b102);

            Book b103 = new Book()
            {
                BookNumber = 222103,
                Title = "The Measure Of The Magic",
                Authors = "Terry Brooks",
                Description = "With the land on edge, Panterra is destined to confront a menace who seeks to claim the last black staff, and the life of the one who wields it.",
                Price = 27.00m,
                Cost = 15.39m,
                ReorderPoint = 4,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2011-08-27 00:00:00")
            };
            b103.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b103);

            Book b104 = new Book()
            {
                BookNumber = 222104,
                Title = "How Firm A Foundation",
                Authors = "David Weber",
                Description = "The island empire of Charis fights to survive.",
                Price = 27.99m,
                Cost = 23.79m,
                ReorderPoint = 7,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2011-09-17 00:00:00")
            };
            b104.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b104);

            Book b105 = new Book()
            {
                BookNumber = 222105,
                Title = "Reamde",
                Authors = "Neal Stephenson",
                Description = "A virus invades a multiplayer online role-playing game and sets off a violent struggle.",
                Price = 35.00m,
                Cost = 14.70m,
                ReorderPoint = 10,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2011-09-24 00:00:00")
            };
            b105.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b105);

            Book b106 = new Book()
            {
                BookNumber = 222106,
                Title = "Nightwoods",
                Authors = "Charles Frazier",
                Description = "When a young woman inherits her murdered sister’s troubled twins, her solitary life becomes filled with mystery and action.",
                Price = 26.00m,
                Cost = 10.92m,
                ReorderPoint = 6,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2011-10-01 00:00:00")
            };
            b106.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b106);

            Book b107 = new Book()
            {
                BookNumber = 222107,
                Title = "The Affair",
                Authors = "Lee Child",
                Description = "For Jack Reacher, an elite military police officer, it all started in 1997. A lonely railroad track. A crime scene. A cover-up.",
                Price = 28.00m,
                Cost = 8.68m,
                ReorderPoint = 6,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2011-10-01 00:00:00")
            };
            b107.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b107);

            Book b108 = new Book()
            {
                BookNumber = 222108,
                Title = "A Lawman's Christmas",
                Authors = "Linda Lael Miller",
                Description = "The death of the town marshal leaves Blue River, Texas, without a lawman, and Dara Rose Nolan without a husband. Clay McKettrick steps in, and when he and Dara Rose agree to a marriage of convenience, the temporary lawman’s Christmas wish is to make her his permanent wife.",
                Price = 28.00m,
                Cost = 15.96m,
                ReorderPoint = 5,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2011-10-01 00:00:00")
            };
            b108.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b108);

            Book b109 = new Book()
            {
                BookNumber = 222109,
                Title = "Bonnie",
                Authors = "Iris Johansen",
                Description = "The forensic sculptor Eve Duncan learns more about her daughter’s disappearance and the girl’s father‘s possible involvement.",
                Price = 27.99m,
                Cost = 24.07m,
                ReorderPoint = 9,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2011-10-22 00:00:00")
            };
            b109.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b109);

            Book b110 = new Book()
            {
                BookNumber = 222110,
                Title = "The Christmas Wedding",
                Authors = "James Patterson and Richard DiLallo",
                Description = "A widow keeps the identity of the new man she is about to marry a secret as her children gather for Christmas.",
                Price = 25.99m,
                Cost = 23.65m,
                ReorderPoint = 2,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2011-10-22 00:00:00")
            };
            b110.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b110);

            Book b111 = new Book()
            {
                BookNumber = 222111,
                Title = "Zero Day",
                Authors = "David Baldacci",
                Description = "A military investigator uncovers a conspiracy.",
                Price = 27.99m,
                Cost = 18.47m,
                ReorderPoint = 9,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2011-11-05 00:00:00")
            };
            b111.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b111);

            Book b112 = new Book()
            {
                BookNumber = 222112,
                Title = "The Scottish Prisoner",
                Authors = "Diana Gabaldon",
                Description = "Jamie Fraser, a paroled Jacobite prisoner, and Lord John Grey collaborate uneasily on a mission to Ireland.",
                Price = 28.00m,
                Cost = 24.92m,
                ReorderPoint = 2,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2011-12-03 00:00:00")
            };
            b112.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b112);

            Book b113 = new Book()
            {
                BookNumber = 222113,
                Title = "77 Shadow Street",
                Authors = "Dean Koontz",
                Description = "A 19th-century tycoon’s mansion has been turned into luxury apartments, but it remains in the grip of evil forces.",
                Price = 28.00m,
                Cost = 14.56m,
                ReorderPoint = 5,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2011-12-31 00:00:00")
            };
            b113.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Horror");
            AllBooks.Add(b113);

            Book b114 = new Book()
            {
                BookNumber = 222114,
                Title = "Love In A Nutshell",
                Authors = "Janet Evanovich and Dorien Kelly",
                Description = "A former magazine editor attempts to turn her parents’ summer house into a bed-and-breakfast.",
                Price = 27.99m,
                Cost = 22.95m,
                ReorderPoint = 3,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2012-01-07 00:00:00")
            };
            b114.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b114);

            Book b115 = new Book()
            {
                BookNumber = 222115,
                Title = "The Hunter",
                Authors = "John Lescroart",
                Description = "A San Francisco private investigator discovers chilling facts about his birth family.",
                Price = 26.95m,
                Cost = 5.66m,
                ReorderPoint = 6,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2012-01-07 00:00:00")
            };
            b115.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b115);

            Book b116 = new Book()
            {
                BookNumber = 222116,
                Title = "Copper Beach",
                Authors = "Jayne Ann Krentz",
                Description = "Amy Radwell, whose psychic talent enables her to understand the paranormal secrets in rare books, becomes the target of a blackmailer. The first book in a new series about rare books and psychic codes.",
                Price = 25.95m,
                Cost = 16.09m,
                ReorderPoint = 5,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2012-01-14 00:00:00")
            };
            b116.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b116);

            Book b117 = new Book()
            {
                BookNumber = 222117,
                Title = "Left For Dead",
                Authors = "J A Jance",
                Description = "Ali Reynolds seeks justice for an old friend and an unidentified woman, both victims of brutal attacks.",
                Price = 25.99m,
                Cost = 20.01m,
                ReorderPoint = 10,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2012-02-11 00:00:00")
            };
            b117.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b117);

            Book b118 = new Book()
            {
                BookNumber = 222118,
                Title = "Robert Ludlum’S The Janson Command",
                Authors = "Paul Garrison",
                Description = "A former American operative builds a network to help him resolve crises without torture or civilian casualties.",
                Price = 27.99m,
                Cost = 7.28m,
                ReorderPoint = 9,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2012-02-18 00:00:00")
            };
            b118.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b118);

            Book b119 = new Book()
            {
                BookNumber = 222119,
                Title = "Victims",
                Authors = "Jonathan Kellerman",
                Description = "The Los Angeles psychologist-detective Alex Delaware and the detective Milo Sturgis track down a homicidal maniac.",
                Price = 28.00m,
                Cost = 16.52m,
                ReorderPoint = 1,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2012-03-03 00:00:00")
            };
            b119.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b119);

            Book b120 = new Book()
            {
                BookNumber = 222120,
                Title = "Another Piece Of My Heart",
                Authors = "Jane Green",
                Description = "A woman in her late 30s marries the man of her dreams and reaches out to his daughters by his previous marriage, but one of them is determined to destroy her.",
                Price = 25.99m,
                Cost = 20.27m,
                ReorderPoint = 4,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2012-03-17 00:00:00")
            };
            b120.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b120);

            Book b121 = new Book()
            {
                BookNumber = 222121,
                Title = "Unnatural Acts",
                Authors = "Stuart Woods",
                Description = "The New York lawyer Stone Barrington becomes involved in the family problems of a billionaire hedge fund manager.",
                Price = 26.95m,
                Cost = 16.71m,
                ReorderPoint = 6,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2012-04-21 00:00:00")
            };
            b121.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b121);

            Book b122 = new Book()
            {
                BookNumber = 222122,
                Title = "Mission To Paris",
                Authors = "Alan Furst",
                Description = "In Paris in 1938, an actor stumbles into the clutches of Nazi conspirators who want to exploit his celebrity.",
                Price = 27.00m,
                Cost = 19.17m,
                ReorderPoint = 8,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2012-06-16 00:00:00")
            };
            b122.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b122);

            Book b123 = new Book()
            {
                BookNumber = 222123,
                Title = "Shadow Of Night",
                Authors = "Deborah Harkness",
                Description = "An Oxford scholar/witch and a vampire geneticist pursue history, secrets and each other in Elizabethan London.",
                Price = 28.95m,
                Cost = 21.13m,
                ReorderPoint = 10,
                InventoryQuantity = 15,
                PublishDate = DateTime.Parse("2012-07-14 00:00:00")
            };
            b123.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b123);

            Book b124 = new Book()
            {
                BookNumber = 222124,
                Title = "Where We Belong",
                Authors = "Emily Giffin",
                Description = "A woman’s successful life is disrupted by the appearance of an 18-year-old girl with a link to her past.",
                Price = 27.99m,
                Cost = 8.12m,
                ReorderPoint = 3,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2012-07-28 00:00:00")
            };
            b124.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b124);

            Book b125 = new Book()
            {
                BookNumber = 222125,
                Title = "Judgment Call",
                Authors = "J A Jance",
                Description = "Joanna Brady, an Arizona sheriff, must function as both a law officer and a mother when her daughter’s high school principal is murdered.",
                Price = 25.99m,
                Cost = 8.84m,
                ReorderPoint = 10,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2012-07-28 00:00:00")
            };
            b125.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b125);

            Book b126 = new Book()
            {
                BookNumber = 222126,
                Title = "Broken Harbor",
                Authors = "Tana French",
                Description = "In French’s fourth Dublin murder squad novel, a detective’s investigation of a crime in a seaside town evokes memories of his disturbing childhood there.",
                Price = 27.95m,
                Cost = 24.04m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2012-07-28 00:00:00")
            };
            b126.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b126);

            Book b127 = new Book()
            {
                BookNumber = 222127,
                Title = "Odd Apocalypse",
                Authors = "Dean Koontz",
                Description = "Odd Thomas, who can communicate with the dead, explores the mysteries of an old estate now owned by a billionaire.",
                Price = 28.00m,
                Cost = 14.28m,
                ReorderPoint = 1,
                InventoryQuantity = 1,
                PublishDate = DateTime.Parse("2012-08-04 00:00:00")
            };
            b127.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Horror");
            AllBooks.Add(b127);

            Book b128 = new Book()
            {
                BookNumber = 222128,
                Title = "Haven",
                Authors = "Kay Hooper",
                Description = "The F.B.I. agent Noah Bishop and his special crimes unit help two sisters probe the secrets of a North Carolina town.",
                Price = 26.95m,
                Cost = 14.82m,
                ReorderPoint = 1,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2012-08-04 00:00:00")
            };
            b128.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b128);

            Book b129 = new Book()
            {
                BookNumber = 222129,
                Title = "The Inn At Rose Harbor",
                Authors = "Debbie Macomber",
                Description = "A young widow buys a bed-and-breakfast.",
                Price = 26.00m,
                Cost = 24.18m,
                ReorderPoint = 5,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2012-08-18 00:00:00")
            };
            b129.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b129);

            Book b130 = new Book()
            {
                BookNumber = 222130,
                Title = "Wards Of Faerie",
                Authors = "Terry Brooks",
                Description = "In the first book of a new fantasy series, the Dark Legacy of Shannara, Druids, Elves and humans unite to try to capture the Elfstones and rescue the troubled Four Lands.",
                Price = 28.00m,
                Cost = 4.20m,
                ReorderPoint = 1,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2012-08-25 00:00:00")
            };
            b130.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b130);

            Book b131 = new Book()
            {
                BookNumber = 222131,
                Title = "A Sunless Sea",
                Authors = "Anne Perry",
                Description = "A murder case for William Monk of the Thames River Police culminates in a government minister’s corruption trial.",
                Price = 26.00m,
                Cost = 22.62m,
                ReorderPoint = 2,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2012-09-01 00:00:00")
            };
            b131.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b131);

            Book b132 = new Book()
            {
                BookNumber = 222132,
                Title = "Last To Die",
                Authors = "Tess Gerritsen",
                Description = "The detective Jane Rizzoli and the medical examiner Maura Isles protect a boy whose family and foster family have all been murdered.",
                Price = 27.00m,
                Cost = 9.99m,
                ReorderPoint = 5,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2012-09-01 00:00:00")
            };
            b132.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b132);

            Book b133 = new Book()
            {
                BookNumber = 222133,
                Title = "Telegraph Avenue",
                Authors = "Michael Chabon",
                Description = "Fathers and sons in Berkeley and Oakland, Calif.",
                Price = 27.99m,
                Cost = 11.20m,
                ReorderPoint = 10,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2012-09-15 00:00:00")
            };
            b133.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b133);

            Book b134 = new Book()
            {
                BookNumber = 222134,
                Title = "Midst Toil And Tribulation",
                Authors = "David Weber",
                Description = "In Book 6 of the Safehold science fiction series, the republic of Siddamark descends into chaos.",
                Price = 27.99m,
                Cost = 10.08m,
                ReorderPoint = 8,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2012-09-22 00:00:00")
            };
            b134.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b134);

            Book b135 = new Book()
            {
                BookNumber = 222135,
                Title = "Sleep No More",
                Authors = "Iris Johansen",
                Description = "The forensic sculptor Eve Duncan investigates when her mother’s friend disappears from a mental hospital.",
                Price = 27.99m,
                Cost = 4.48m,
                ReorderPoint = 3,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2012-10-20 00:00:00")
            };
            b135.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b135);

            Book b136 = new Book()
            {
                BookNumber = 222136,
                Title = "Sweet Tooth",
                Authors = "Ian McEwan",
                Description = "A British woman working for MI5 in 1972 falls in love with a writer the service is clandestinely supporting.",
                Price = 26.95m,
                Cost = 16.17m,
                ReorderPoint = 4,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2012-11-17 00:00:00")
            };
            b136.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b136);

            Book b137 = new Book()
            {
                BookNumber = 222137,
                Title = "Merry Christmas, Alex Cross",
                Authors = "James Patterson",
                Description = "Detective Alex Cross confronts both a hostage situation and a terrorist act at Christmas.",
                Price = 28.99m,
                Cost = 8.99m,
                ReorderPoint = 7,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2012-11-17 00:00:00")
            };
            b137.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b137);

            Book b138 = new Book()
            {
                BookNumber = 222138,
                Title = "Threat Vector",
                Authors = "Tom Clancy with Mark Greaney",
                Description = "As China threatens to invade Taiwan, the covert intelligence expert Jack Ryan Jr. aids his father’s administration  — but his agency is no longer secret.",
                Price = 28.95m,
                Cost = 10.71m,
                ReorderPoint = 9,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2012-12-08 00:00:00")
            };
            b138.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b138);

            Book b139 = new Book()
            {
                BookNumber = 222139,
                Title = "Two Graves",
                Authors = "Douglas Preston and Lincoln Child",
                Description = "Special Agent Aloysius Pendergast pursues a serial killer as well as his abducted wife.",
                Price = 26.99m,
                Cost = 13.23m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2012-12-15 00:00:00")
            };
            b139.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b139);

            Book b140 = new Book()
            {
                BookNumber = 222140,
                Title = "The Husband List",
                Authors = "Janet Evanovich and Dorien Kelly",
                Description = "In New York City in 1894, a wealthy young woman yearns for adventure and the love of an Irish-American with new money, rather than the titled Britons to whom her mother hopes to marry her off.",
                Price = 27.99m,
                Cost = 23.51m,
                ReorderPoint = 9,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2013-01-12 00:00:00")
            };
            b140.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b140);

            Book b141 = new Book()
            {
                BookNumber = 222141,
                Title = "Collateral Damage",
                Authors = "Stuart Woods",
                Description = "Back in New York, the lawyer Stone Barrington joins his former partner Holly Barker in pursuing a dangerous case.",
                Price = 26.95m,
                Cost = 19.40m,
                ReorderPoint = 10,
                InventoryQuantity = 15,
                PublishDate = DateTime.Parse("2013-01-12 00:00:00")
            };
            b141.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b141);

            Book b142 = new Book()
            {
                BookNumber = 222142,
                Title = "Kinsey And Me",
                Authors = "Sue Grafton",
                Description = "Stories about Grafton’s character Kinsey Millhone as well as explorations of Grafton’s own past.",
                Price = 27.95m,
                Cost = 25.43m,
                ReorderPoint = 7,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2013-01-12 00:00:00")
            };
            b142.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b142);

            Book b143 = new Book()
            {
                BookNumber = 222143,
                Title = "The Third Bullet",
                Authors = "Stephen Hunter",
                Description = "The veteran sniper Bob Lee Swagger investigates the assassination of John F. Kennedy. ",
                Price = 26.99m,
                Cost = 15.11m,
                ReorderPoint = 3,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2013-01-19 00:00:00")
            };
            b143.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b143);

            Book b144 = new Book()
            {
                BookNumber = 222144,
                Title = "The Night Ranger",
                Authors = "Alex Berenson",
                Description = "The former C.I.A. operative John Wells pitches in when four young Americans who work at a refugee camp in Somalia are hijacked by bandits. ",
                Price = 27.95m,
                Cost = 6.71m,
                ReorderPoint = 3,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2013-02-16 00:00:00")
            };
            b144.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b144);

            Book b145 = new Book()
            {
                BookNumber = 222145,
                Title = "Sweet Tea Revenge",
                Authors = "Laura Childs",
                Description = "Theodosia Browning, owner of Indigo Tea Shop, is a bridesmaid in her friend's wedding. But the bridegroom is found dead on the big day.",
                Price = 29.00m,
                Cost = 13.92m,
                ReorderPoint = 8,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2013-03-09 00:00:00")
            };
            b145.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b145);

            Book b146 = new Book()
            {
                BookNumber = 222146,
                Title = "The Last Threshold",
                Authors = "R A Salvatore",
                Description = "Book 4 of the fantasy Neverwinter Saga.",
                Price = 27.95m,
                Cost = 2.80m,
                ReorderPoint = 10,
                InventoryQuantity = 15,
                PublishDate = DateTime.Parse("2013-03-09 00:00:00")
            };
            b146.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b146);

            Book b147 = new Book()
            {
                BookNumber = 222147,
                Title = "The Supremes At Earl's All-You-Can-Eat",
                Authors = "Edward Kelsey Moore",
                Description = "Four decades in the friendship of three middle-class black women in a small  southern Indiana town.",
                Price = 24.95m,
                Cost = 7.49m,
                ReorderPoint = 10,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2013-03-16 00:00:00")
            };
            b147.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Humor");
            AllBooks.Add(b147);

            Book b148 = new Book()
            {
                BookNumber = 222148,
                Title = "Lover At Last",
                Authors = "J R Ward",
                Description = "Book 11 of the Black Dagger Brotherhood series.",
                Price = 27.95m,
                Cost = 12.86m,
                ReorderPoint = 7,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2013-03-30 00:00:00")
            };
            b148.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b148);

            Book b149 = new Book()
            {
                BookNumber = 222149,
                Title = "Leaving Everything Most Loved",
                Authors = "Jacqueline Winspear",
                Description = "In 1933, the private investigator Maisie Dobbs helps an Indian man whose sister’s murder has been ignored by Scotland Yard.",
                Price = 26.99m,
                Cost = 2.97m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2013-03-30 00:00:00")
            };
            b149.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b149);

            Book b150 = new Book()
            {
                BookNumber = 222150,
                Title = "All That Is",
                Authors = "James Salter",
                Description = "A veteran makes a career in publishing in postwar New York and struggles to achieve romantic success.",
                Price = 26.95m,
                Cost = 14.01m,
                ReorderPoint = 6,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2013-04-06 00:00:00")
            };
            b150.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b150);

            Book b151 = new Book()
            {
                BookNumber = 222151,
                Title = "Unintended Consequences",
                Authors = "Stuart Woods",
                Description = "The New York lawyer Stone Barrington discovers a shadowy network beneath the world of European wealth.",
                Price = 26.95m,
                Cost = 11.32m,
                ReorderPoint = 8,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2013-04-13 00:00:00")
            };
            b151.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b151);

            Book b152 = new Book()
            {
                BookNumber = 222152,
                Title = "Nos4A2",
                Authors = "Joe Hill",
                Description = "In a creepy battle between real and imaginary worlds, a brave biker chick is pitted against a ghoulish villain who lures children to a place where it is always Christmas.",
                Price = 34.00m,
                Cost = 28.56m,
                ReorderPoint = 9,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2013-05-04 00:00:00")
            };
            b152.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b152);

            Book b153 = new Book()
            {
                BookNumber = 222153,
                Title = "Zero Hour",
                Authors = "Clive Cussler and Graham Brown",
                Description = "Kurt Austin, Joe Zavala and the rest of the Numa team search for a physicist's machine, buried in an ocean trench, that can cause deadly earthquakes in the 11th Numa Files novel.",
                Price = 28.95m,
                Cost = 25.19m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2013-06-01 00:00:00")
            };
            b153.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b153);

            Book b154 = new Book()
            {
                BookNumber = 222154,
                Title = "The Son",
                Authors = "Philipp Meyer",
                Description = "More than 150 years in a Texas family, from Comanche raids to the present, and its rise to money and power in the cattle and oil industries.",
                Price = 22.00m,
                Cost = 19.58m,
                ReorderPoint = 1,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2013-06-01 00:00:00")
            };
            b154.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b154);

            Book b155 = new Book()
            {
                BookNumber = 222155,
                Title = "Red Sparrow",
                Authors = "Jason Matthews",
                Description = "A Russian intelligence officer trained in the art of seduction becomes entangled with a young C.I.A. officer.",
                Price = 26.95m,
                Cost = 11.59m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2013-06-08 00:00:00")
            };
            b155.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b155);

            Book b156 = new Book()
            {
                BookNumber = 222156,
                Title = "The Silver Star",
                Authors = "Jeannette Walls",
                Description = "When their irresponsible mother takes off, a 12-year-old California girl and her sister join the rest of their family in Virginia. ",
                Price = 23.95m,
                Cost = 8.38m,
                ReorderPoint = 8,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2013-06-15 00:00:00")
            };
            b156.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b156);

            Book b157 = new Book()
            {
                BookNumber = 222157,
                Title = "Sisterland",
                Authors = "Curtis Sittenfeld",
                Description = "Twins with psychic abilities share a devastating secret.",
                Price = 27.99m,
                Cost = 20.71m,
                ReorderPoint = 10,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2013-06-29 00:00:00")
            };
            b157.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b157);

            Book b158 = new Book()
            {
                BookNumber = 222158,
                Title = "The English Girl",
                Authors = "Daniel Silva",
                Description = "Gabriel Allon, an art restorer and occasional spy for the Israeli secret service, steps in to help the British prime minister, whose lover has been kidnapped. ",
                Price = 17.95m,
                Cost = 2.33m,
                ReorderPoint = 1,
                InventoryQuantity = 1,
                PublishDate = DateTime.Parse("2013-07-20 00:00:00")
            };
            b158.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b158);

            Book b159 = new Book()
            {
                BookNumber = 222159,
                Title = "Hunting Eve",
                Authors = "Iris Johansen",
                Description = "In the second book of a trilogy, the forensic sculptor Eve Duncan struggles to outwit a kidnapper in the Colorado wilderness.",
                Price = 35.99m,
                Cost = 28.07m,
                ReorderPoint = 3,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2013-07-20 00:00:00")
            };
            b159.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b159);

            Book b160 = new Book()
            {
                BookNumber = 222160,
                Title = "Light Of The World",
                Authors = "James Lee Burke",
                Description = "A savage killer follows the detective Dave Robicheaux and his family to a Montana ranch. ",
                Price = 32.00m,
                Cost = 10.88m,
                ReorderPoint = 5,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2013-07-27 00:00:00")
            };
            b160.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b160);

            Book b161 = new Book()
            {
                BookNumber = 222161,
                Title = "The Kill List",
                Authors = "Frederick Forsyth",
                Description = "An Arabic-speaking Marine major known as the Tracker pursues a terrorist who radicalizes young Muslims living abroad.",
                Price = 23.95m,
                Cost = 10.78m,
                ReorderPoint = 2,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2013-08-24 00:00:00")
            };
            b161.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b161);

            Book b162 = new Book()
            {
                BookNumber = 222162,
                Title = "Songs Of Willow Frost",
                Authors = "Jamie Ford",
                Description = "A 12-year-old Seattle orphan during the Depression becomes convinced that a movie star is really his vanished mother. ",
                Price = 18.00m,
                Cost = 6.30m,
                ReorderPoint = 9,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2013-09-14 00:00:00")
            };
            b162.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b162);

            Book b163 = new Book()
            {
                BookNumber = 222163,
                Title = "W Is For Wasted",
                Authors = "Sue Grafton",
                Description = "A homeless man inexplicably leaves $600,000 to Kinsey Millhone.",
                Price = 16.00m,
                Cost = 7.04m,
                ReorderPoint = 3,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2013-09-14 00:00:00")
            };
            b163.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b163);

            Book b164 = new Book()
            {
                BookNumber = 222164,
                Title = "Deadly Heat",
                Authors = "Richard Castle",
                Description = "The N.Y.P.D. homicide detective Nikki Heat and the journalist Jameson Rook search for the former C.I.A. station chief who ordered her mother’s execution.\nThe N.Y.P.D. homicide detective Nikki Heat and the journalist Jameson Rook search for the former C.I.A. station chief who ordered her mother’s execution.",
                Price = 16.00m,
                Cost = 3.36m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2013-09-21 00:00:00")
            };
            b164.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b164);

            Book b165 = new Book()
            {
                BookNumber = 222165,
                Title = "Deadline",
                Authors = "Sandra Brown",
                Description = "A journalist who pursues a story about a former marine, the son of terrorists from 40 years ago,becomes a suspect in the death of his ex-wife.",
                Price = 16.00m,
                Cost = 4.48m,
                ReorderPoint = 6,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2013-09-28 00:00:00")
            };
            b165.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b165);

            Book b166 = new Book()
            {
                BookNumber = 222166,
                Title = "Silencing Eve",
                Authors = "Iris Johansen",
                Description = "The final book of a trilogy about the forensic sculptor Eve Duncan. ",
                Price = 19.00m,
                Cost = 7.03m,
                ReorderPoint = 6,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2013-10-05 00:00:00")
            };
            b166.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b166);

            Book b167 = new Book()
            {
                BookNumber = 222167,
                Title = "Starry Night",
                Authors = "Debbie Macomber",
                Description = "At Christmastime, a big-city columnist sets out to interview a reclusive author in Alaska. ",
                Price = 24.95m,
                Cost = 17.96m,
                ReorderPoint = 10,
                InventoryQuantity = 15,
                PublishDate = DateTime.Parse("2013-10-12 00:00:00")
            };
            b167.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b167);

            Book b168 = new Book()
            {
                BookNumber = 222168,
                Title = "Bridget Jones: Mad About The Boy",
                Authors = "Helen Fielding",
                Description = "Bridget, now 51 and a mother and widow, is once again looking for love.",
                Price = 29.95m,
                Cost = 18.57m,
                ReorderPoint = 1,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2013-10-19 00:00:00")
            };
            b168.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b168);

            Book b169 = new Book()
            {
                BookNumber = 222169,
                Title = "The Last Dark",
                Authors = "Stephen R Donaldson",
                Description = "The 10th and final installment of the sprawling fantasy series about Thomas Covenant the Unbeliever.",
                Price = 16.00m,
                Cost = 10.88m,
                ReorderPoint = 3,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2013-10-19 00:00:00")
            };
            b169.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b169);

            Book b170 = new Book()
            {
                BookNumber = 222170,
                Title = "Aimless Love",
                Authors = "Billy Collins",
                Description = "More than 50 new poems as well as selections from previous books from the two-term poet laureate of the Untied States.",
                Price = 30.99m,
                Cost = 25.41m,
                ReorderPoint = 7,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2013-10-26 00:00:00")
            };
            b170.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Poetry");
            AllBooks.Add(b170);

            Book b171 = new Book()
            {
                BookNumber = 222171,
                Title = "Tatiana",
                Authors = "Martin Cruz Smith",
                Description = "A dead translator’s coded notebook may hold the key to the murders of a muckraking journalist and an oligarch in the former Soviet Union. Arkady Renko, a senior investigator in the Moscow prosecutor’s office, is on the case.",
                Price = 20.99m,
                Cost = 18.68m,
                ReorderPoint = 2,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2013-11-16 00:00:00")
            };
            b171.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b171);

            Book b172 = new Book()
            {
                BookNumber = 222172,
                Title = "Dust",
                Authors = "Patricia Cornwell",
                Description = "The murder of a computer engineer at M.I.T. leads the Massachusetts Chief Medical Examiner Kay Scarpetta in unexpected directions.",
                Price = 23.99m,
                Cost = 18.23m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2013-11-16 00:00:00")
            };
            b172.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b172);

            Book b173 = new Book()
            {
                BookNumber = 222173,
                Title = "The Supreme Macaroni Company",
                Authors = "Adriana Trigiani",
                Description = "Tensions arise when Valentine Roncalli, a Greenwich Village shoe designer, marries a handsome Italian, and the two must balance careers, countries and families. The final book in the Valentine trilogy. ",
                Price = 34.99m,
                Cost = 7.00m,
                ReorderPoint = 4,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2013-11-30 00:00:00")
            };
            b173.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b173);

            Book b174 = new Book()
            {
                BookNumber = 222174,
                Title = "Innocence",
                Authors = "Dean Koontz",
                Description = "A grotesque man living in exile beneath the city encounters a teenage girl hiding from dangerous enemies.",
                Price = 21.00m,
                Cost = 13.44m,
                ReorderPoint = 3,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2013-12-14 00:00:00")
            };
            b174.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Horror");
            AllBooks.Add(b174);

            Book b175 = new Book()
            {
                BookNumber = 222175,
                Title = "Hunting Shadows",
                Authors = "Charles Todd",
                Description = "In the aftermath of World War I, a Scotland Yard detective with a heavy burden of guilt, investigates two murders in Cambridgeshire that may be linked.",
                Price = 32.99m,
                Cost = 18.47m,
                ReorderPoint = 4,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2014-01-25 00:00:00")
            };
            b175.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b175);

            Book b176 = new Book()
            {
                BookNumber = 222176,
                Title = "Confessions Of A Wild Child",
                Authors = "Jackie Collins",
                Description = "The early years of Collins’s recurring character Lucky Santangelo.",
                Price = 30.95m,
                Cost = 17.95m,
                ReorderPoint = 10,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2014-02-08 00:00:00")
            };
            b176.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b176);

            Book b177 = new Book()
            {
                BookNumber = 222177,
                Title = "The Counterfeit Agent",
                Authors = "Alex Berenson",
                Description = "John Wells is sent on a mission to find the truth about a mysterious Iranian package said to be bound for the United States.",
                Price = 16.99m,
                Cost = 9.68m,
                ReorderPoint = 8,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2014-02-15 00:00:00")
            };
            b177.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b177);

            Book b178 = new Book()
            {
                BookNumber = 222178,
                Title = "Like A Mighty Army",
                Authors = "David Weber",
                Description = "In Book 7 of the Safehold science fiction series, the empire of Charis fights for self-determination. ",
                Price = 22.00m,
                Cost = 17.60m,
                ReorderPoint = 3,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2014-02-22 00:00:00")
            };
            b178.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b178);

            Book b179 = new Book()
            {
                BookNumber = 222179,
                Title = "Cavendon Hall",
                Authors = "Barbara Taylor Bradford",
                Description = "In Edwardian England, an aristocratic family and the family who serve them share an ancestral home. ",
                Price = 26.00m,
                Cost = 8.06m,
                ReorderPoint = 4,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2014-04-05 00:00:00")
            };
            b179.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b179);

            Book b180 = new Book()
            {
                BookNumber = 222180,
                Title = "Frog Music",
                Authors = "Emma Donoghue",
                Description = "A murder mystery set in San Francisco in 1876, when the city is in the grip of a smallpox epidemic and a heat wave.",
                Price = 16.95m,
                Cost = 4.92m,
                ReorderPoint = 5,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2014-04-05 00:00:00")
            };
            b180.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b180);

            Book b181 = new Book()
            {
                BookNumber = 222181,
                Title = "Destroyer Angel",
                Authors = "Nevada Barr",
                Description = "The National Park Service Ranger Anna Pigeon must rescue friends who are kidnapped while camping in Minnesota.",
                Price = 32.00m,
                Cost = 3.52m,
                ReorderPoint = 3,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2014-04-05 00:00:00")
            };
            b181.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b181);

            Book b182 = new Book()
            {
                BookNumber = 222182,
                Title = "Warriors",
                Authors = "Ted Bell",
                Description = "The counterspy Alex Hawke must rescue a kidnapped scientist. ",
                Price = 33.99m,
                Cost = 5.44m,
                ReorderPoint = 8,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2014-04-05 00:00:00")
            };
            b182.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b182);

            Book b183 = new Book()
            {
                BookNumber = 222183,
                Title = "Live To See Tomorrow",
                Authors = "Iris Johansen",
                Description = "The C.I.A. operative Catherine Ling must spearhead the rescue of an American journalist kidnapped in Tibet. ",
                Price = 34.00m,
                Cost = 6.46m,
                ReorderPoint = 5,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2014-05-03 00:00:00")
            };
            b183.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b183);

            Book b184 = new Book()
            {
                BookNumber = 222184,
                Title = "All The Light We Cannot See",
                Authors = "Anthony Doerr",
                Description = "The lives of a blind French girl and a gadget-obsessed German boy before and during World War II, when their paths eventually cross. ",
                Price = 23.95m,
                Cost = 10.30m,
                ReorderPoint = 6,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2014-05-10 00:00:00")
            };
            b184.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b184);

            Book b185 = new Book()
            {
                BookNumber = 222185,
                Title = "The Kraken Project",
                Authors = "Douglas Preston",
                Description = "The former C.I.A. agent Wyman Ford must stop Dorothy, a powerful artificial intelligence that has gone rogue.",
                Price = 35.00m,
                Cost = 28.00m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2014-05-17 00:00:00")
            };
            b185.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b185);

            Book b186 = new Book()
            {
                BookNumber = 222186,
                Title = "The Vacationers",
                Authors = "Emma Straub",
                Description = "Well-heeled New Yorkers and their friends spend two weeks in Majorca, a time when rivalries and secrets come to light.",
                Price = 33.00m,
                Cost = 5.94m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2014-05-31 00:00:00")
            };
            b186.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b186);

            Book b187 = new Book()
            {
                BookNumber = 222187,
                Title = "The Hurricane Sisters",
                Authors = "Dorothea Benton Frank",
                Description = "Three generations of women endure a stormy summer in South Carolina's Lowcountry.",
                Price = 16.00m,
                Cost = 9.60m,
                ReorderPoint = 4,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2014-06-07 00:00:00")
            };
            b187.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b187);

            Book b188 = new Book()
            {
                BookNumber = 222188,
                Title = "The Matchmaker",
                Authors = "Elin Hilderbrand",
                Description = "A Nantucket resident’s life is shaken by a diagnosis and the return to the island of her high school sweetheart. ",
                Price = 25.00m,
                Cost = 11.00m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2014-06-14 00:00:00")
            };
            b188.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b188);

            Book b189 = new Book()
            {
                BookNumber = 222189,
                Title = "Terminal City",
                Authors = "Linda Fairstein",
                Description = "Alexandra Cooper, a Manhattan assistant district attorney, hunts for a killer in Grand Central’s underground tunnels.",
                Price = 32.95m,
                Cost = 16.48m,
                ReorderPoint = 8,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2014-06-21 00:00:00")
            };
            b189.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b189);

            Book b190 = new Book()
            {
                BookNumber = 222190,
                Title = "Landline",
                Authors = "Rainbow Rowell",
                Description = "A woman in a troubled marriage finds a way to communicate with her husband in the past. ",
                Price = 29.00m,
                Cost = 5.80m,
                ReorderPoint = 8,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2014-07-12 00:00:00")
            };
            b190.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b190);

            Book b191 = new Book()
            {
                BookNumber = 222191,
                Title = "The Book Of Life",
                Authors = "Deborah Harkness",
                Description = "In the conclusion to the All Souls trilogy, the Oxford scholar/witch Diana Bishop and the vampire geneticist Matthew Clairmont return from Elizabethan London to the present.",
                Price = 27.95m,
                Cost = 8.66m,
                ReorderPoint = 9,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2014-07-19 00:00:00")
            };
            b191.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b191);

            Book b192 = new Book()
            {
                BookNumber = 222192,
                Title = "Magic Breaks",
                Authors = "Ilona Andrews",
                Description = "In the seventh Kate Daniels novel, Kate deals with paranormal politics in Atlanta as she prepares the Pack for an attack.",
                Price = 32.00m,
                Cost = 16.96m,
                ReorderPoint = 2,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2014-08-02 00:00:00")
            };
            b192.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b192);

            Book b193 = new Book()
            {
                BookNumber = 222193,
                Title = "Big Little Lies",
                Authors = "Liane Moriarty",
                Description = "Who will end up dead, and how, when three mothers with children in the same school become friends?",
                Price = 17.00m,
                Cost = 5.10m,
                ReorderPoint = 7,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2014-08-02 00:00:00")
            };
            b193.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b193);

            Book b194 = new Book()
            {
                BookNumber = 222194,
                Title = "Dark Skye",
                Authors = "Kresley Cole",
                Description = "Will a scarred warrior and the beautiful sorceress with the power to heal him overcome the challenges of their warring families and the chaotic battles around them? Book 15 in the Immortals After Dark series.",
                Price = 20.00m,
                Cost = 4.00m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2014-08-09 00:00:00")
            };
            b194.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b194);

            Book b195 = new Book()
            {
                BookNumber = 222195,
                Title = "The Magician's Land",
                Authors = "Lev Grossman",
                Description = "Quentin, an exiled magician, tries a risky heist in the final installment of a trilogy.",
                Price = 28.95m,
                Cost = 5.50m,
                ReorderPoint = 6,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2014-08-09 00:00:00")
            };
            b195.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b195);

            Book b196 = new Book()
            {
                BookNumber = 222196,
                Title = "Mean Streak",
                Authors = "Sandra Brown",
                Description = "A North Carolina pediatrician is held captive by a mysterious man who forces her to question her life. ",
                Price = 29.95m,
                Cost = 26.66m,
                ReorderPoint = 8,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2014-08-23 00:00:00")
            };
            b196.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b196);

            Book b197 = new Book()
            {
                BookNumber = 222197,
                Title = "The King's Curse",
                Authors = "Philippa Gregory",
                Description = "As chief lady-in-waiting to Katherine of Aragon, Margaret Pole is torn between the queen and her husband, Henry VIII.",
                Price = 18.99m,
                Cost = 3.99m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2014-09-13 00:00:00")
            };
            b197.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b197);

            Book b198 = new Book()
            {
                BookNumber = 222198,
                Title = "Bones Never Lie",
                Authors = "Kathy Reichs",
                Description = "A child murderer who eluded capture years ago has resurfaced, giving the forensic anthropologist Temperance Brennan another chance to stop her.",
                Price = 14.95m,
                Cost = 9.42m,
                ReorderPoint = 10,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2014-09-27 00:00:00")
            };
            b198.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b198);

            Book b199 = new Book()
            {
                BookNumber = 222199,
                Title = "Nora Webster",
                Authors = "Colm Toibin",
                Description = "In the 1970s, an Irish widow struggles to find her identity.",
                Price = 30.99m,
                Cost = 4.65m,
                ReorderPoint = 2,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2014-10-11 00:00:00")
            };
            b199.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b199);

            Book b200 = new Book()
            {
                BookNumber = 222200,
                Title = "Winter Street",
                Authors = "Elin Hilderbrand",
                Description = "Complications ensue when the owner of Nantucket’s Winter Street Inn gathers his four children and their families for Christmas.",
                Price = 20.95m,
                Cost = 2.30m,
                ReorderPoint = 6,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2014-10-18 00:00:00")
            };
            b200.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b200);

            Book b201 = new Book()
            {
                BookNumber = 222201,
                Title = "The Narrow Road To The Deep North",
                Authors = "Richard Flanagan",
                Description = "The hero of the Man Booker Prize-winning novel about love, good and evil is a P.O.W. working on the Thai-Burma Death Railway during World War II.",
                Price = 34.00m,
                Cost = 20.74m,
                ReorderPoint = 6,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2014-10-18 00:00:00")
            };
            b201.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b201);

            Book b202 = new Book()
            {
                BookNumber = 222202,
                Title = "The Handsome Man's De Luxe Café",
                Authors = "Alexander McCall Smith",
                Description = "The 15th book in the No. 1 Ladies’ Detective Agency series.",
                Price = 25.95m,
                Cost = 17.91m,
                ReorderPoint = 3,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2014-11-01 00:00:00")
            };
            b202.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b202);

            Book b203 = new Book()
            {
                BookNumber = 222203,
                Title = "The Burning Room",
                Authors = "Michael Connelly",
                Description = "The Los Angeles detective Harry Bosch and his new partner investigate two long-unsolved cases.",
                Price = 36.99m,
                Cost = 17.39m,
                ReorderPoint = 7,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2014-11-08 00:00:00")
            };
            b203.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b203);

            Book b204 = new Book()
            {
                BookNumber = 222204,
                Title = "The Job",
                Authors = "Janet Evanovich and Lee Goldberg",
                Description = "The F.B.I. special agent Kate O’Hare works with Nicolas Fox, a handsome con man, to pursue a drug kingpin.",
                Price = 28.95m,
                Cost = 20.27m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2014-11-22 00:00:00")
            };
            b204.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b204);

            Book b205 = new Book()
            {
                BookNumber = 222205,
                Title = "The Cinderella Murder",
                Authors = "Mary Higgins Clark and Alafair Burke",
                Description = "A  TV producer plans a show about a cold case — the murder of a U.C.L.A. student who was found with one shoe missing.",
                Price = 25.95m,
                Cost = 5.97m,
                ReorderPoint = 1,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2014-11-22 00:00:00")
            };
            b205.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b205);

            Book b206 = new Book()
            {
                BookNumber = 222206,
                Title = "The Mistletoe Promise",
                Authors = "Richard Paul Evans",
                Description = "A divorced woman enters into a contract with a strange man to pretend to be a couple until Christmas.",
                Price = 23.99m,
                Cost = 12.23m,
                ReorderPoint = 10,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2014-11-22 00:00:00")
            };
            b206.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b206);

            Book b207 = new Book()
            {
                BookNumber = 222207,
                Title = "Hope To Die",
                Authors = "James Patterson",
                Description = "Detective Alex Cross’s family is kidnapped by a madman who wants to turn Cross into a perfect killer.",
                Price = 31.95m,
                Cost = 3.51m,
                ReorderPoint = 7,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2014-11-29 00:00:00")
            };
            b207.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b207);

            Book b208 = new Book()
            {
                BookNumber = 222208,
                Title = "Trust No One",
                Authors = "Jayne Ann Krentz",
                Description = "A woman who is being stalked is aided by an unlikely ally.",
                Price = 17.95m,
                Cost = 12.39m,
                ReorderPoint = 9,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2015-01-10 00:00:00")
            };
            b208.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b208);

            Book b209 = new Book()
            {
                BookNumber = 222209,
                Title = "Private Vegas",
                Authors = "James Patterson and Maxine Paetro",
                Description = "Jack Morgan, the head of an investigative firm, uncovers a murder ring in Las Vegas.",
                Price = 32.00m,
                Cost = 25.92m,
                ReorderPoint = 8,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2015-01-31 00:00:00")
            };
            b209.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b209);

            Book b210 = new Book()
            {
                BookNumber = 222210,
                Title = "Trigger Warning",
                Authors = "Neil Gaiman",
                Description = "Stories and poems about the power of imagination.",
                Price = 17.95m,
                Cost = 10.41m,
                ReorderPoint = 4,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2015-02-07 00:00:00")
            };
            b210.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Poetry");
            AllBooks.Add(b210);

            Book b211 = new Book()
            {
                BookNumber = 222211,
                Title = "Twelve Days",
                Authors = "Alex Berenson",
                Description = "The former C.I.A. operative John Wells discovers a plot to trick the president into invading Iran.",
                Price = 25.00m,
                Cost = 18.50m,
                ReorderPoint = 8,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2015-02-14 00:00:00")
            };
            b211.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b211);

            Book b212 = new Book()
            {
                BookNumber = 222212,
                Title = "A Spool Of Blue Thread",
                Authors = "Anne Tyler",
                Description = "Four generations of a family are drawn to a house in the Baltimore suburbs.",
                Price = 15.95m,
                Cost = 1.75m,
                ReorderPoint = 10,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2015-02-14 00:00:00")
            };
            b212.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b212);

            Book b213 = new Book()
            {
                BookNumber = 222213,
                Title = "Holy Cow",
                Authors = "David Duchovny",
                Description = "A light-hearted fable by the actor.",
                Price = 19.99m,
                Cost = 11.79m,
                ReorderPoint = 5,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2015-02-14 00:00:00")
            };
            b213.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Humor");
            AllBooks.Add(b213);

            Book b214 = new Book()
            {
                BookNumber = 222214,
                Title = "Prodigal Son",
                Authors = "Danielle Steel",
                Description = "Twins, one good and one bad, reunite after 20 years when one of them returns to their hometown. But it is no longer clear who the good and who the bad one is.",
                Price = 18.95m,
                Cost = 9.10m,
                ReorderPoint = 2,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2015-02-28 00:00:00")
            };
            b214.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b214);

            Book b215 = new Book()
            {
                BookNumber = 222215,
                Title = "Last One Home",
                Authors = "Debbie Macomber",
                Description = "Three estranged sisters work to resolve their differences",
                Price = 20.00m,
                Cost = 15.60m,
                ReorderPoint = 5,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2015-03-14 00:00:00")
            };
            b215.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b215);

            Book b216 = new Book()
            {
                BookNumber = 222216,
                Title = "The Lady From Zagreb",
                Authors = "Philip Kerr",
                Description = "The former Berlin homicide detective Bernie Gunther is sent to Croatia by Joseph Goebbels to persuade a film star to appear in a movie.",
                Price = 20.95m,
                Cost = 19.27m,
                ReorderPoint = 6,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2015-04-11 00:00:00")
            };
            b216.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b216);

            Book b217 = new Book()
            {
                BookNumber = 222217,
                Title = "14Th Deadly Sin",
                Authors = "James Patterson and Maxine Paetro",
                Description = "A video of a shocking crime surfaces, casting suspicion on a San Francisco detective's colleagues.",
                Price = 24.99m,
                Cost = 6.25m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2015-05-09 00:00:00")
            };
            b217.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b217);

            Book b218 = new Book()
            {
                BookNumber = 222218,
                Title = "The Fateful Lightning",
                Authors = "Jeff Shaara",
                Description = "The fourth and final volume in a series of Civil War novels describes the war's last months through multiple perspectives.",
                Price = 28.95m,
                Cost = 5.50m,
                ReorderPoint = 8,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2015-06-06 00:00:00")
            };
            b218.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b218);

            Book b219 = new Book()
            {
                BookNumber = 222219,
                Title = "In The Unlikely Event",
                Authors = "Judy Blume",
                Description = "Secrets are revealed and love stories play out against the backdrop of a series of panic-inducing plane crashes in 1950s New Jersey.",
                Price = 18.95m,
                Cost = 16.87m,
                ReorderPoint = 9,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2015-06-06 00:00:00")
            };
            b219.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b219);

            Book b220 = new Book()
            {
                BookNumber = 222220,
                Title = "The Little Paris Bookshop",
                Authors = "Nina George",
                Description = "A bookseller with a knack for finding just the right book for making others feel better embarks on a journey in pursuit of his own happiness.",
                Price = 34.00m,
                Cost = 5.78m,
                ReorderPoint = 6,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2015-07-04 00:00:00")
            };
            b220.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b220);

            Book b221 = new Book()
            {
                BookNumber = 222221,
                Title = "Friction",
                Authors = "Sandra Brown",
                Description = "A Texas Ranger fights for custody of his daughter amid complications stemming from his attraction to the judge.",
                Price = 18.99m,
                Cost = 2.85m,
                ReorderPoint = 7,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2015-08-22 00:00:00")
            };
            b221.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b221);

            Book b222 = new Book()
            {
                BookNumber = 222222,
                Title = "The Solomon Curse",
                Authors = "Clive Cussler and Russell Blake",
                Description = "The wealthy couple Sam and Remi Fargo investigate a dangerous legend in the Solomon Islands.",
                Price = 26.95m,
                Cost = 18.06m,
                ReorderPoint = 9,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2015-09-05 00:00:00")
            };
            b222.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b222);

            Book b223 = new Book()
            {
                BookNumber = 222223,
                Title = "One Year After",
                Authors = "William R Forstchen",
                Description = "A New Regime imposes tyranny in the aftermath of a nuclear attack.",
                Price = 23.95m,
                Cost = 3.59m,
                ReorderPoint = 6,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2015-09-19 00:00:00")
            };
            b223.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b223);

            Book b224 = new Book()
            {
                BookNumber = 222224,
                Title = "The Murder House",
                Authors = "James Patterson and David Ellis",
                Description = "When bodies are found at a Hamptons estate where a series of grisly murders once occurred, a local detective and former New York City cop investigates.",
                Price = 23.95m,
                Cost = 17.72m,
                ReorderPoint = 6,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2015-10-03 00:00:00")
            };
            b224.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b224);

            Book b225 = new Book()
            {
                BookNumber = 222225,
                Title = "All The Stars In The Heavens",
                Authors = "Adriana Trigiani",
                Description = "A fictional treatment of the life of the actress Loretta Young focuses on her rumored affair with the married Clark Gable and her subsequent pregnancy.",
                Price = 26.95m,
                Cost = 19.94m,
                ReorderPoint = 2,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2015-10-17 00:00:00")
            };
            b225.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b225);

            Book b226 = new Book()
            {
                BookNumber = 222226,
                Title = "The Lake House",
                Authors = "Kate Morton",
                Description = "A London detective investigating a missing-persons case becomes curious about an unsolved 1933 kidnapping in Cornwall.",
                Price = 16.95m,
                Cost = 10.17m,
                ReorderPoint = 8,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2015-10-24 00:00:00")
            };
            b226.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b226);

            Book b227 = new Book()
            {
                BookNumber = 222227,
                Title = "The Japanese Lover",
                Authors = "Isabel Allende",
                Description = "A young refugee from the Nazis and the son of her family’s Japanese gardener must hide their love, although it lasts a lifetime.",
                Price = 33.99m,
                Cost = 8.16m,
                ReorderPoint = 3,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2015-11-07 00:00:00")
            };
            b227.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b227);

            Book b228 = new Book()
            {
                BookNumber = 222228,
                Title = "The Promise",
                Authors = "Robert Crais",
                Description = "The Los Angeles P.I. Elvis Cole joins forces with the K-9 officer Scott James of the L.A.P.D. and his German shepherd, Maggie, as well as his partner, Joe Pike, to foil a criminal mastermind.",
                Price = 27.95m,
                Cost = 18.73m,
                ReorderPoint = 8,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2015-11-14 00:00:00")
            };
            b228.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b228);

            Book b229 = new Book()
            {
                BookNumber = 222229,
                Title = "The Pharaoh's Secret",
                Authors = "Clive Cussler and Graham Brown",
                Description = "Kurt Austin and Joe Zavala must save the NUMA crew from a mysterious toxin deployed by a villain who wants to build a new Egyptian empire.",
                Price = 31.95m,
                Cost = 12.46m,
                ReorderPoint = 2,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2015-11-21 00:00:00")
            };
            b229.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b229);

            Book b230 = new Book()
            {
                BookNumber = 222230,
                Title = "The Guilty",
                Authors = "David Baldacci",
                Description = "The government hit man Will Robie investigates murder charges against his estranged father in their Mississippi hometown.",
                Price = 19.95m,
                Cost = 17.16m,
                ReorderPoint = 3,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2015-11-21 00:00:00")
            };
            b230.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b230);

            Book b231 = new Book()
            {
                BookNumber = 222231,
                Title = "The Mistletoe Inn",
                Authors = "Richard Paul Evans",
                Description = "An aspiring romance writer with a broken heart meets a complicated man at a Christmas writers’ retreat.",
                Price = 36.95m,
                Cost = 11.09m,
                ReorderPoint = 10,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2015-11-21 00:00:00")
            };
            b231.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b231);

            Book b232 = new Book()
            {
                BookNumber = 222232,
                Title = "Find Her",
                Authors = "Lisa Gardner",
                Description = "The Boston detective D.D. Warren hunts for a missing woman who was kidnapped and abused as a college student and may have become a vigilante.",
                Price = 28.95m,
                Cost = 10.71m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2016-02-13 00:00:00")
            };
            b232.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b232);

            Book b233 = new Book()
            {
                BookNumber = 222233,
                Title = "Wedding Cake Murder",
                Authors = "Joanne Fluke",
                Description = "The Lake Eden, Minn., baker Hannah Swensen is about to get married, but first she must solve the murder of a visiting celebrity chef. Recipes included.",
                Price = 23.95m,
                Cost = 17.72m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2016-02-27 00:00:00")
            };
            b233.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b233);

            Book b234 = new Book()
            {
                BookNumber = 222234,
                Title = "The Gangster",
                Authors = "Clive Cussler and Justin Scott",
                Description = "n the ninth book in this series, set in 1906, the New York detective Isaac Bell contends with a crime boss passing as a respectable businessman and a tycoon’s plot against President Theodore Roosevelt.",
                Price = 30.95m,
                Cost = 7.12m,
                ReorderPoint = 8,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2016-03-05 00:00:00")
            };
            b234.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b234);

            Book b235 = new Book()
            {
                BookNumber = 222235,
                Title = "Fool Me Once",
                Authors = "Harlan Coben",
                Description = "A retired Army helicopter pilot faces combat-related nightmares and mysteries concerning the deaths of her husband and sister.",
                Price = 24.95m,
                Cost = 12.72m,
                ReorderPoint = 10,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2016-03-26 00:00:00")
            };
            b235.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b235);

            Book b236 = new Book()
            {
                BookNumber = 222236,
                Title = "Robert B. Parker's Slow Burn",
                Authors = "Ace Atkins",
                Description = "Spenser is back, leaving a trail of antagonism as he investigates a series of suspicious Boston fires.",
                Price = 22.99m,
                Cost = 10.58m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2016-05-07 00:00:00")
            };
            b236.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b236);

            Book b237 = new Book()
            {
                BookNumber = 222237,
                Title = "Zero K",
                Authors = "Don DeLillo",
                Description = "A billionaire and his son meet at a remote desert compound dedicated to preserving bodies until they can be returned to life in the future.",
                Price = 20.00m,
                Cost = 15.20m,
                ReorderPoint = 4,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2016-05-07 00:00:00")
            };
            b237.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b237);

            Book b238 = new Book()
            {
                BookNumber = 222238,
                Title = "The Second Life Of Nick Mason",
                Authors = "Steve Hamilton",
                Description = "A deal with a fellow inmate, a crime boss, springs Nick Mason from prison, but he must become an assassin.",
                Price = 19.99m,
                Cost = 3.20m,
                ReorderPoint = 2,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2016-05-21 00:00:00")
            };
            b238.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b238);

            Book b239 = new Book()
            {
                BookNumber = 222239,
                Title = "The Weekenders",
                Authors = "Mary Kay Andrews",
                Description = "On the North Carolina island of Belle Isle, a woman investigates her husband’s shady financial affairs after his mysterious death.",
                Price = 20.95m,
                Cost = 12.78m,
                ReorderPoint = 9,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2016-05-21 00:00:00")
            };
            b239.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b239);

            Book b240 = new Book()
            {
                BookNumber = 222240,
                Title = "The Emperor's Revenge",
                Authors = "Clive Cussler and Boyd Morrison",
                Description = "Juan Cabrillo teams up with a former C.I.A. colleague to thwart a plan involving the death of millions and international economic meltdown.",
                Price = 27.99m,
                Cost = 20.43m,
                ReorderPoint = 1,
                InventoryQuantity = 3,
                PublishDate = DateTime.Parse("2016-06-04 00:00:00")
            };
            b240.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b240);

            Book b241 = new Book()
            {
                BookNumber = 222241,
                Title = "Homegoing",
                Authors = "Yaa Gyasi",
                Description = "This Ghanaian-American writer’s first novel traces the lives in West Africa and America of seven generations of the descendants of two half sisters.",
                Price = 26.95m,
                Cost = 2.70m,
                ReorderPoint = 4,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2016-06-11 00:00:00")
            };
            b241.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b241);

            Book b242 = new Book()
            {
                BookNumber = 222242,
                Title = "Here's To Us",
                Authors = "Elin Hilderbrand",
                Description = "Sparks fly as a celebrity chef’s ex-wives pile into a small cabin in Nantucket to join his widow for the reading of his will.",
                Price = 26.95m,
                Cost = 8.62m,
                ReorderPoint = 9,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2016-06-18 00:00:00")
            };
            b242.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b242);

            Book b243 = new Book()
            {
                BookNumber = 222243,
                Title = "The Pursuit",
                Authors = "Janet Evanovich and Lee Goldberg",
                Description = "The F.B.I. agent Kate O’Hare and her con man partner, Nick Fox, face off against a dangerous ex-Serbian military officer.",
                Price = 25.99m,
                Cost = 18.45m,
                ReorderPoint = 5,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2016-06-25 00:00:00")
            };
            b243.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b243);

            Book b244 = new Book()
            {
                BookNumber = 222244,
                Title = "Among The Wicked",
                Authors = "Linda Castillo",
                Description = "Chief of Police Kate Burkholder goes undercover as a widow in a reclusive Amish community to investigate a girl's death.",
                Price = 24.00m,
                Cost = 6.72m,
                ReorderPoint = 9,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2016-07-16 00:00:00")
            };
            b244.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b244);

            Book b245 = new Book()
            {
                BookNumber = 222245,
                Title = "The Woman In Cabin 10",
                Authors = "Ruth Ware",
                Description = "A travel writer on a cruise is certain she has heard a body thrown overboard, but no one believes her.",
                Price = 32.00m,
                Cost = 3.52m,
                ReorderPoint = 7,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2016-07-23 00:00:00")
            };
            b245.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b245);

            Book b246 = new Book()
            {
                BookNumber = 222246,
                Title = "Truly Madly Guilty",
                Authors = "Liane Moriarty",
                Description = "Tense turning points for three couples at a backyard barbecue gone wrong.",
                Price = 14.99m,
                Cost = 10.04m,
                ReorderPoint = 6,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2016-07-30 00:00:00")
            };
            b246.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b246);

            Book b247 = new Book()
            {
                BookNumber = 222247,
                Title = "The Underground Railroad",
                Authors = "Colson Whitehead",
                Description = "A slave girl heads toward freedom on the network, envisioned as actual tracks and tunnels.",
                Price = 32.00m,
                Cost = 3.20m,
                ReorderPoint = 10,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2016-08-06 00:00:00")
            };
            b247.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b247);

            Book b248 = new Book()
            {
                BookNumber = 222248,
                Title = "Dragonmark",
                Authors = "Sherrilyn Kenyon",
                Description = "The first book of a new trilogy featuring Illarion, a dragon made into a human  against his will. A Dark-Hunter novel.",
                Price = 29.95m,
                Cost = 3.29m,
                ReorderPoint = 7,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2016-08-06 00:00:00")
            };
            b248.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b248);

            Book b249 = new Book()
            {
                BookNumber = 222249,
                Title = "Another Brooklyn",
                Authors = "Jacqueline Woodson",
                Description = "An adult novel by an award-winning children's book author centers on memories of growing up and the close friendship of four girls.",
                Price = 36.00m,
                Cost = 9.72m,
                ReorderPoint = 10,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2016-08-13 00:00:00")
            };
            b249.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b249);

            Book b250 = new Book()
            {
                BookNumber = 222250,
                Title = "Sting",
                Authors = "Sandra Brown",
                Description = "A hired killer and a woman he kidnapped join forces to elude the F.B.I. agents and others who are searching for her corrupt brother.",
                Price = 27.00m,
                Cost = 8.91m,
                ReorderPoint = 4,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2016-08-20 00:00:00")
            };
            b250.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b250);

            Book b251 = new Book()
            {
                BookNumber = 222251,
                Title = "The Kept Woman",
                Authors = "Karin Slaughter",
                Description = "Will Trent of the Georgia Bureau of Investigation and his lover, the medical examiner Sara Linton, pursue a case involving a dirty Atlanta cop.",
                Price = 16.95m,
                Cost = 15.26m,
                ReorderPoint = 2,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2016-09-24 00:00:00")
            };
            b251.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b251);

            Book b252 = new Book()
            {
                BookNumber = 222252,
                Title = "Twelve Days Of Christmas",
                Authors = "Debbie Macomber",
                Description = "A woman starts a blog about her attempt to reach out to a grumpy neighbor at Christmastime, and finds herself falling for him.",
                Price = 25.99m,
                Cost = 23.13m,
                ReorderPoint = 10,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2016-10-08 00:00:00")
            };
            b252.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b252);

            Book b253 = new Book()
            {
                BookNumber = 222253,
                Title = "Winter Storms",
                Authors = "Elin Hilderbrand",
                Description = "In the final book of the Winter Street trilogy, a huge snowstorm bearing down on Nantucket threatens the Quinn family’s Christmas, after a year of significant events.",
                Price = 29.00m,
                Cost = 24.94m,
                ReorderPoint = 4,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2016-10-08 00:00:00")
            };
            b253.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b253);

            Book b254 = new Book()
            {
                BookNumber = 222254,
                Title = "Vince Flynn: Order To Kill",
                Authors = "Kyle Mills",
                Description = "Flynn’s character, the C.I.A. operative Mitch Rapp, uncovers a dangerous Russian plot. Flynn died in 2013.",
                Price = 16.95m,
                Cost = 13.73m,
                ReorderPoint = 8,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2016-10-15 00:00:00")
            };
            b254.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b254);

            Book b255 = new Book()
            {
                BookNumber = 222255,
                Title = "Crimson Death",
                Authors = "Laurell K Hamilton",
                Description = "The vampire hunter Anita Blake, her friend Edward and her servant Damian travel to Ireland to battle an unusual vampire infestation.",
                Price = 16.99m,
                Cost = 7.65m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2016-10-15 00:00:00")
            };
            b255.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b255);

            Book b256 = new Book()
            {
                BookNumber = 222256,
                Title = "The Obsidian Chamber",
                Authors = "Douglas Preston and Lincoln Child",
                Description = "While the F.B.I. agent Aloysius Pendergast is believed dead, his ward is kidnapped.",
                Price = 17.00m,
                Cost = 3.57m,
                ReorderPoint = 10,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2016-10-22 00:00:00")
            };
            b256.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b256);

            Book b257 = new Book()
            {
                BookNumber = 222257,
                Title = "Escape Clause",
                Authors = "John Sandford",
                Description = "Virgil Flowers of the Minnesota Bureau of Criminal Apprehension must deal with the theft of tigers from the local zoo.",
                Price = 35.95m,
                Cost = 7.19m,
                ReorderPoint = 4,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2016-10-22 00:00:00")
            };
            b257.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b257);

            Book b258 = new Book()
            {
                BookNumber = 222258,
                Title = "The Whistler",
                Authors = "John Grisham",
                Description = "A whistleblower alerts a Florida investigator to judicial corruption involving the Mob and Indian casinos.",
                Price = 26.95m,
                Cost = 13.48m,
                ReorderPoint = 8,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2016-10-29 00:00:00")
            };
            b258.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b258);

            Book b259 = new Book()
            {
                BookNumber = 222259,
                Title = "The Whole Town's Talking",
                Authors = "Fannie Flagg",
                Description = "A century of life in small-town Elmwood Springs, Mo.",
                Price = 31.99m,
                Cost = 21.11m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2016-12-03 00:00:00")
            };
            b259.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b259);

            Book b260 = new Book()
            {
                BookNumber = 222260,
                Title = "Rogue One: A Star Wars Story",
                Authors = "Alexander Freed",
                Description = "A novelization of the new movie, including additional scenes.",
                Price = 33.95m,
                Cost = 23.77m,
                ReorderPoint = 6,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2016-12-24 00:00:00")
            };
            b260.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b260);

            Book b261 = new Book()
            {
                BookNumber = 222261,
                Title = "The Mistress",
                Authors = "Danielle Steel",
                Description = "The beautiful mistress of a Russian oligarch falls in love with an artist and yearns for freedom.",
                Price = 36.95m,
                Cost = 15.52m,
                ReorderPoint = 4,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2017-01-07 00:00:00")
            };
            b261.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b261);

            Book b262 = new Book()
            {
                BookNumber = 222262,
                Title = "Ring Of Fire",
                Authors = "Brad Taylor",
                Description = "Pike Logan, a member of a secret counterterrorist unit called the Taskforce, investigates a Saudi-backed Moroccan terrorist cell.",
                Price = 22.00m,
                Cost = 19.58m,
                ReorderPoint = 4,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2017-01-14 00:00:00")
            };
            b262.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b262);

            Book b263 = new Book()
            {
                BookNumber = 222263,
                Title = "Death's Mistress",
                Authors = "Terry Goodkind",
                Description = "The first book of a new series, the Nicci Chronicles, centers on a character from the Sword of Truth fantasy series.",
                Price = 20.00m,
                Cost = 12.00m,
                ReorderPoint = 7,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2017-01-28 00:00:00")
            };
            b263.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b263);

            Book b264 = new Book()
            {
                BookNumber = 222264,
                Title = "4 3 2 1",
                Authors = "Paul Auster",
                Description = "Four versions of the formative years of a Jewish boy born in Newark in 1947.",
                Price = 20.95m,
                Cost = 5.87m,
                ReorderPoint = 8,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2017-02-04 00:00:00")
            };
            b264.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b264);

            Book b265 = new Book()
            {
                BookNumber = 222265,
                Title = "Gunmetal Gray",
                Authors = "Mark Greaney",
                Description = "Court Gentry, now working for the C.I.A., pursues a Chinese hacker who is on the run.",
                Price = 21.95m,
                Cost = 16.24m,
                ReorderPoint = 8,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2017-02-18 00:00:00")
            };
            b265.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b265);

            Book b266 = new Book()
            {
                BookNumber = 222266,
                Title = "Banana Cream Pie Murder",
                Authors = "Joanne Fluke",
                Description = "Hannah Swensen, the bakery owner and amateur sleuth of Lake Eden, Minn., returns from her honeymoon to confront an actress’s mysterious death.",
                Price = 36.95m,
                Cost = 14.41m,
                ReorderPoint = 5,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2017-03-04 00:00:00")
            };
            b266.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b266);

            Book b267 = new Book()
            {
                BookNumber = 222267,
                Title = "Silence Fallen",
                Authors = "Patricia Briggs",
                Description = "The shape-shifter Mercy Thompson finds herself in the clutches of the world’s most powerful vampire.",
                Price = 36.00m,
                Cost = 10.08m,
                ReorderPoint = 7,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2017-03-11 00:00:00")
            };
            b267.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b267);

            Book b268 = new Book()
            {
                BookNumber = 222268,
                Title = "Without Warning",
                Authors = "Joel C Rosenberg",
                Description = "A journalist pursues the head of ISIS after an attack on the Capitol when the administration fails to take action.",
                Price = 27.95m,
                Cost = 12.02m,
                ReorderPoint = 7,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2017-03-18 00:00:00")
            };
            b268.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b268);

            Book b269 = new Book()
            {
                BookNumber = 222269,
                Title = "Song Of The Lion",
                Authors = "Anne Hillerman",
                Description = "The third Southwestern mystery featuring the Navajo police officer Bernadette Manuelito and her husband, Jim Chee.",
                Price = 31.99m,
                Cost = 24.63m,
                ReorderPoint = 6,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2017-04-15 00:00:00")
            };
            b269.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b269);

            Book b270 = new Book()
            {
                BookNumber = 222270,
                Title = "The Burial Hour",
                Authors = "Jeffery Deaver",
                Description = "Lincoln Rhyme travels to Italy to investigate a case.",
                Price = 16.00m,
                Cost = 1.60m,
                ReorderPoint = 5,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2017-04-15 00:00:00")
            };
            b270.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b270);

            Book b271 = new Book()
            {
                BookNumber = 222271,
                Title = "Nighthawk",
                Authors = "Clive Cussler and Graham Brown",
                Description = "The NUMA crew races the Russians and Chinese in a hunt for a missing American aircraft.",
                Price = 30.00m,
                Cost = 21.60m,
                ReorderPoint = 1,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2017-06-03 00:00:00")
            };
            b271.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b271);

            Book b272 = new Book()
            {
                BookNumber = 222272,
                Title = "The Identicals",
                Authors = "Elin Hilderbrand",
                Description = "Complications in the lives of identical twins who were raised by their divorced parents, one on Nantucket, one on Martha’s Vineyard.",
                Price = 33.95m,
                Cost = 4.41m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2017-06-17 00:00:00")
            };
            b272.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b272);

            Book b273 = new Book()
            {
                BookNumber = 222273,
                Title = "House Of Spies",
                Authors = "Daniel Silva",
                Description = "Gabriel Allon, the Israeli art restorer and spy, now the head of Israel’s secret intelligence service, pursues an ISIS mastermind.",
                Price = 33.95m,
                Cost = 17.31m,
                ReorderPoint = 5,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2017-07-15 00:00:00")
            };
            b273.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b273);

            Book b274 = new Book()
            {
                BookNumber = 222274,
                Title = "Two Nights",
                Authors = "Kathy Reichs",
                Description = "Sunday Night, the heroine of a new series from the creator of Temperance Brennan, searches for a girl who may have been kidnapped by a cult.",
                Price = 17.95m,
                Cost = 15.98m,
                ReorderPoint = 9,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2017-07-15 00:00:00")
            };
            b274.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b274);

            Book b275 = new Book()
            {
                BookNumber = 222275,
                Title = "Meddling Kids",
                Authors = "Edgar Cantero",
                Description = "Four old friends return to the site of their teenage adventures.",
                Price = 30.95m,
                Cost = 3.71m,
                ReorderPoint = 3,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2017-07-22 00:00:00")
            };
            b275.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b275);

            Book b276 = new Book()
            {
                BookNumber = 222276,
                Title = "Watch Me Disappear",
                Authors = "Janelle Brown",
                Description = "When a Berkeley woman vanishes after a hiking trip, her husband and daughter discover disturbing secrets.",
                Price = 32.95m,
                Cost = 30.64m,
                ReorderPoint = 4,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2017-07-22 00:00:00")
            };
            b276.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b276);

            Book b277 = new Book()
            {
                BookNumber = 222277,
                Title = "The Store",
                Authors = "James Patterson and Richard DiLallo",
                Description = "Two New York writers go undercover to expose the secrets of a powerful retailer.",
                Price = 31.00m,
                Cost = 15.19m,
                ReorderPoint = 2,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2017-08-19 00:00:00")
            };
            b277.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b277);

            Book b278 = new Book()
            {
                BookNumber = 222278,
                Title = "I Know A Secret",
                Authors = "Tess Gerritsen",
                Description = "Rizzoli and Isles investigate two separate homicides and uncover other dangerous mysteries.",
                Price = 32.95m,
                Cost = 26.36m,
                ReorderPoint = 3,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2017-08-19 00:00:00")
            };
            b278.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b278);

            Book b279 = new Book()
            {
                BookNumber = 222279,
                Title = "Sulfur Springs",
                Authors = "William Kent Krueger",
                Description = "A newly married couple search for the wife's missing son, which leads them to a border town in the middle of a drug war.",
                Price = 32.95m,
                Cost = 17.79m,
                ReorderPoint = 10,
                InventoryQuantity = 15,
                PublishDate = DateTime.Parse("2017-08-26 00:00:00")
            };
            b279.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b279);

            Book b280 = new Book()
            {
                BookNumber = 222280,
                Title = "Enemy Of The State",
                Authors = "Kyle Mills",
                Description = "Vince Flynn's character Mitch Rapp leaves the C.I.A. to go on a manhunt when the nephew of a Saudi King finances a terrorist group.",
                Price = 20.95m,
                Cost = 4.19m,
                ReorderPoint = 8,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2017-09-09 00:00:00")
            };
            b280.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b280);

            Book b281 = new Book()
            {
                BookNumber = 222281,
                Title = "Little Fires Everywhere",
                Authors = "Celeste Ng",
                Description = "An artist with a mysterious past and a disregard for the status quo upends a quiet town outside Cleveland.",
                Price = 16.00m,
                Cost = 12.00m,
                ReorderPoint = 8,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2017-09-16 00:00:00")
            };
            b281.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b281);

            Book b282 = new Book()
            {
                BookNumber = 222282,
                Title = "Twin Peaks: The Final Dossier",
                Authors = "Mark Frost",
                Description = "Updated profiles on the residents of Twin Peaks are assembled by special agent Tamara Preston.",
                Price = 27.95m,
                Cost = 8.66m,
                ReorderPoint = 1,
                InventoryQuantity = 2,
                PublishDate = DateTime.Parse("2017-11-04 00:00:00")
            };
            b282.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b282);

            Book b283 = new Book()
            {
                BookNumber = 222283,
                Title = "The House Of Unexpected Sisters",
                Authors = "Alexander McCall Smith",
                Description = "During an investigation, Precious Ramotswe encounters a man from her past and a nurse who has her last name.",
                Price = 29.95m,
                Cost = 16.47m,
                ReorderPoint = 1,
                InventoryQuantity = 1,
                PublishDate = DateTime.Parse("2017-11-11 00:00:00")
            };
            b283.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b283);

            Book b284 = new Book()
            {
                BookNumber = 222284,
                Title = "Artemis",
                Authors = "Andy Weir",
                Description = "A small-time smuggler living in a lunar colony schemes to pay off an old debt by pulling off a challenging heist.",
                Price = 31.00m,
                Cost = 18.91m,
                ReorderPoint = 6,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2017-11-18 00:00:00")
            };
            b284.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b284);

            Book b285 = new Book()
            {
                BookNumber = 222285,
                Title = "Robicheaux",
                Authors = "James Lee Burke",
                Description = "A bereaved detective confronts his past and works to clear his name when he becomes a suspect during an investigation into the murder of the man who killed his wife.",
                Price = 17.95m,
                Cost = 15.98m,
                ReorderPoint = 5,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2018-01-06 00:00:00")
            };
            b285.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            AllBooks.Add(b285);

            Book b286 = new Book()
            {
                BookNumber = 222286,
                Title = "Unbound",
                Authors = "Stuart Woods",
                Description = "The 44th book in the Stone Barrington series.",
                Price = 16.00m,
                Cost = 11.36m,
                ReorderPoint = 3,
                InventoryQuantity = 8,
                PublishDate = DateTime.Parse("2018-01-06 00:00:00")
            };
            b286.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b286);

            Book b287 = new Book()
            {
                BookNumber = 222287,
                Title = "The Immortalists",
                Authors = "Chloe Benjamin",
                Description = "Four adolescents learn the dates of their deaths from a psychic and their lives go on different courses.",
                Price = 31.00m,
                Cost = 22.32m,
                ReorderPoint = 6,
                InventoryQuantity = 9,
                PublishDate = DateTime.Parse("2018-01-13 00:00:00")
            };
            b287.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b287);

            Book b288 = new Book()
            {
                BookNumber = 222288,
                Title = "Blood Fury",
                Authors = "JR Ward",
                Description = "The third book in the Black Dagger Legacy series.",
                Price = 30.95m,
                Cost = 21.05m,
                ReorderPoint = 10,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2018-01-13 00:00:00")
            };
            b288.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            AllBooks.Add(b288);

            Book b289 = new Book()
            {
                BookNumber = 222289,
                Title = "The Grave's A Fine And Private Place",
                Authors = "Alan Bradley",
                Description = "Flavia de Luce, a young British sleuth, gets involved in solving a murder after experiencing a family tragedy.",
                Price = 26.95m,
                Cost = 21.83m,
                ReorderPoint = 5,
                InventoryQuantity = 7,
                PublishDate = DateTime.Parse("2018-02-03 00:00:00")
            };
            b289.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b289);

            Book b290 = new Book()
            {
                BookNumber = 222290,
                Title = "An American Marriage",
                Authors = "Tayari Jones",
                Description = "A newlywed couple's relationship is tested when the husband is sentenced to 12 years in prison.",
                Price = 22.95m,
                Cost = 12.16m,
                ReorderPoint = 9,
                InventoryQuantity = 11,
                PublishDate = DateTime.Parse("2018-02-10 00:00:00")
            };
            b290.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b290);

            Book b291 = new Book()
            {
                BookNumber = 222291,
                Title = "Fifty Fifty",
                Authors = "James Patterson and Candice Fox",
                Description = "Detective Harriet Blue tries to clear her brother's name and save a small Australian town from being massacred.",
                Price = 35.99m,
                Cost = 28.07m,
                ReorderPoint = 7,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2018-02-24 00:00:00")
            };
            b291.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b291);

            Book b292 = new Book()
            {
                BookNumber = 222292,
                Title = "Star Wars: The Last Jedi",
                Authors = "Jason Fry",
                Description = "An adaptation of the film, written with input from its director, Rian Johnson, which includes scenes from alternate versions of the script.",
                Price = 28.99m,
                Cost = 24.64m,
                ReorderPoint = 2,
                InventoryQuantity = 4,
                PublishDate = DateTime.Parse("2018-03-10 00:00:00")
            };
            b292.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            AllBooks.Add(b292);

            Book b293 = new Book()
            {
                BookNumber = 222293,
                Title = "Caribbean Rim",
                Authors = "Randy Wayne White",
                Description = "The 25th book in the Doc Ford series. The marine biologist searches for a state agency official and rare Spanish coins.",
                Price = 15.00m,
                Cost = 9.45m,
                ReorderPoint = 8,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2018-03-17 00:00:00")
            };
            b293.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b293);

            Book b294 = new Book()
            {
                BookNumber = 222294,
                Title = "To Die But Once",
                Authors = "Jacqueline Winspear",
                Description = "In 1940, months after Britain declared war on Germany, Maisie Dobbs investigates the disappearance of an apprentice working on a government contract.",
                Price = 24.95m,
                Cost = 19.21m,
                ReorderPoint = 1,
                InventoryQuantity = 5,
                PublishDate = DateTime.Parse("2018-03-31 00:00:00")
            };
            b294.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            AllBooks.Add(b294);

            Book b295 = new Book()
            {
                BookNumber = 222295,
                Title = "Macbeth",
                Authors = "Jo Nesbo",
                Description = "In this adaptation of Shakespeare's tragedy, police in a 1970s industrial town take on a pair of drug lords.",
                Price = 28.95m,
                Cost = 7.53m,
                ReorderPoint = 7,
                InventoryQuantity = 12,
                PublishDate = DateTime.Parse("2018-04-14 00:00:00")
            };
            b295.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Shakespeare");
            AllBooks.Add(b295);

            Book b296 = new Book()
            {
                BookNumber = 222296,
                Title = "The High Tide Club",
                Authors = "Mary Kay Andrews",
                Description = "An eccentric millionaire enlists the attorney Brooke Trappnell to fix old wrongs, which sets up a potential scandal and murder.",
                Price = 23.95m,
                Cost = 14.13m,
                ReorderPoint = 10,
                InventoryQuantity = 14,
                PublishDate = DateTime.Parse("2018-05-12 00:00:00")
            };
            b296.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b296);

            Book b297 = new Book()
            {
                BookNumber = 222297,
                Title = "Warlight",
                Authors = "Michael Ondaatje",
                Description = "In Britain after World War II, a pair of teenage siblings are taken under the tutelage of a mysterious man and his cronies who served during the war.",
                Price = 26.00m,
                Cost = 20.28m,
                ReorderPoint = 6,
                InventoryQuantity = 10,
                PublishDate = DateTime.Parse("2018-05-12 00:00:00")
            };
            b297.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            AllBooks.Add(b297);

            Book b298 = new Book()
            {
                BookNumber = 222298,
                Title = "The Cast",
                Authors = "Danielle Steel",
                Description = "A magazine columnist meets an array of Hollywood professionals when a producer turns a story about her grandmother into a TV series.",
                Price = 21.95m,
                Cost = 12.95m,
                ReorderPoint = 10,
                InventoryQuantity = 15,
                PublishDate = DateTime.Parse("2018-05-19 00:00:00")
            };
            b298.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            AllBooks.Add(b298);

            Book b299 = new Book()
            {
                BookNumber = 222299,
                Title = "Beach House Reunion",
                Authors = "Mary Alice Monroe",
                Description = "Three generations of a family gather one summer in South Carolina.",
                Price = 32.95m,
                Cost = 6.59m,
                ReorderPoint = 3,
                InventoryQuantity = 6,
                PublishDate = DateTime.Parse("2018-05-26 00:00:00")
            };
            b299.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            AllBooks.Add(b299);

            Book b300 = new Book()
            {
                BookNumber = 222300,
                Title = "Turbulence",
                Authors = "Stuart Woods",
                Description = "The 46th book in the Stone Barrington series.",
                Price = 15.95m,
                Cost = 6.06m,
                ReorderPoint = 10,
                InventoryQuantity = 13,
                PublishDate = DateTime.Parse("2018-06-09 00:00:00")
            };
            b300.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            AllBooks.Add(b300);
            db.Books.AddRange(AllBooks);
            db.SaveChanges();
        }
    }
}
