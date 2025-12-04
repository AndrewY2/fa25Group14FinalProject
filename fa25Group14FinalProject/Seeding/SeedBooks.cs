using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fa25Group14FinalProject.Seeding
{
    public class SeedBooks
    {
        public static void SeedAllBooks(AppDbContext db)
        {
            //Create a counter and a flag so we will know which record is causing problems
            Int32 intBooksAdded = 0;
            String strBookTitle = "Begin";
            List<Book> Books = new List<Book>();

            Book b1 = new Book()
            {
                Title = "The Art Of Racing In The Rain",
                Authors = "Garth Stein",
                BookNumber = 222001,
                Description = "A Lab-terrier mix with great insight into the human condition helps his owner, a struggling race car driver.",
                Price = 23.95m,
                Cost = 10.3m,
                PublishDate = new DateTime(2008, 5, 24),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b1.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b1);

            Book b2 = new Book()
            {
                Title = "The Host",
                Authors = "Stephenie Meyer",
                BookNumber = 222002,
                Description = "Aliens have taken control of the minds and bodies of most humans, but one woman won t surrender.",
                Price = 25.99m,
                Cost = 13.25m,
                PublishDate = new DateTime(2008, 5, 24),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                BookStatus = false
            };
            b2.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b2);

            Book b3 = new Book()
            {
                Title = "Chasing Darkness",
                Authors = "Robert Crais",
                BookNumber = 222003,
                Description = "The Los Angeles private eye Elvis Cole responsible for the release of a serial killer?",
                Price = 25.95m,
                Cost = 9.08m,
                PublishDate = new DateTime(2008, 7, 5),
                InventoryQuantity = 10,
                ReorderPoint = 7,
                BookStatus = false
            };
            b3.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b3);

            Book b4 = new Book()
            {
                Title = "Say Goodbye",
                Authors = "Lisa Gardner",
                BookNumber = 222004,
                Description = "An F.B.I. agent tracks a serial killer who uses spiders as a weapon.",
                Price = 25m,
                Cost = 11.25m,
                PublishDate = new DateTime(2008, 7, 19),
                InventoryQuantity = 5,
                ReorderPoint = 2,
                BookStatus = false
            };
            b4.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b4);

            Book b5 = new Book()
            {
                Title = "The Gargoyle",
                Authors = "Andrew Davidson",
                BookNumber = 222005,
                Description = "A hideously burned man is cared for by a sculptress who claims they were lovers seven centuries ago.",
                Price = 25.95m,
                Cost = 16.09m,
                PublishDate = new DateTime(2008, 8, 9),
                InventoryQuantity = 5,
                ReorderPoint = 3,
                BookStatus = false
            };
            b5.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b5);

            Book b6 = new Book()
            {
                Title = "Foreign Body",
                Authors = "Robin Cook",
                BookNumber = 222006,
                Description = "A medical student investigates a rising number of deaths among medical tourists at foreign hospitals.",
                Price = 25.95m,
                Cost = 24.65m,
                PublishDate = new DateTime(2008, 8, 9),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                BookStatus = false
            };
            b6.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b6);

            Book b7 = new Book()
            {
                Title = "Acheron",
                Authors = "Sherrilyn Kenyon",
                BookNumber = 222007,
                Description = "Book 12 of the Dark-Hunter paranormal series.",
                Price = 24.95m,
                Cost = 13.72m,
                PublishDate = new DateTime(2008, 8, 9),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                BookStatus = false
            };
            b7.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b7);

            Book b8 = new Book()
            {
                Title = "Being Elizabeth",
                Authors = "Barbara Taylor Bradford",
                BookNumber = 222008,
                Description = "A 25-year-old newly in control of her family s corporate empire faces tough choices in business and in love.",
                Price = 27.95m,
                Cost = 21.8m,
                PublishDate = new DateTime(2008, 8, 23),
                InventoryQuantity = 9,
                ReorderPoint = 5,
                BookStatus = false
            };
            b8.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b8);

            Book b9 = new Book()
            {
                Title = "Just Breathe",
                Authors = "Susan Wiggs",
                BookNumber = 222009,
                Description = "Her marriage broken, the author of a syndicated comic strip flees to California, where romance and surprise await.",
                Price = 25.95m,
                Cost = 5.45m,
                PublishDate = new DateTime(2008, 8, 30),
                InventoryQuantity = 8,
                ReorderPoint = 8,
                BookStatus = false
            };
            b9.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b9);

            Book b10 = new Book()
            {
                Title = "The Gypsy Morph",
                Authors = "Terry Brooks",
                BookNumber = 222010,
                Description = "In the third volume of the Genesis of Shannara series, champions of the Word and the Void clash.",
                Price = 27m,
                Cost = 6.75m,
                PublishDate = new DateTime(2008, 8, 30),
                InventoryQuantity = 6,
                ReorderPoint = 6,
                BookStatus = false
            };
            b10.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b10);

            Book b11 = new Book()
            {
                Title = "The Other Queen",
                Authors = "Philippa Gregory",
                BookNumber = 222011,
                Description = "The story of Mary, Queen of Scots, in captivity under Queen Elizabeth.",
                Price = 25.95m,
                Cost = 23.61m,
                PublishDate = new DateTime(2008, 9, 20),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                BookStatus = false
            };
            b11.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b11);

            Book b12 = new Book()
            {
                Title = "One Fifth Avenue",
                Authors = "Candace Bushnell",
                BookNumber = 222012,
                Description = "The worlds of gossip, theater and hedge funds have one address in common.",
                Price = 25.95m,
                Cost = 17.65m,
                PublishDate = new DateTime(2008, 9, 27),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b12.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b12);

            Book b13 = new Book()
            {
                Title = "The Given Day",
                Authors = "Dennis Lehane",
                BookNumber = 222013,
                Description = "A policman, a fugitive and their families persevere in the turbulence of Boston at the end of World War I.",
                Price = 27.95m,
                Cost = 6.99m,
                PublishDate = new DateTime(2008, 9, 27),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                BookStatus = false
            };
            b13.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b13);

            Book b14 = new Book()
            {
                Title = "A Cedar Cove Christmas",
                Authors = "Debbie Macomber",
                BookNumber = 222014,
                Description = "A pregnant woman shows up in Cedar Cove on Christmas Eve and goes into labor in a room above a stable.",
                Price = 16.95m,
                Cost = 4.75m,
                PublishDate = new DateTime(2008, 10, 4),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                BookStatus = false
            };
            b14.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b14);

            Book b15 = new Book()
            {
                Title = "The Pirate King",
                Authors = "R A Salvatore",
                BookNumber = 222015,
                Description = "In Book 2 of the Transitions fantasy series, Drizzt returns to Luskan, a city dominated by dangerous pirates.",
                Price = 27.95m,
                Cost = 14.25m,
                PublishDate = new DateTime(2008, 10, 11),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                BookStatus = false
            };
            b15.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b15);

            Book b16 = new Book()
            {
                Title = "Bones",
                Authors = "Jonathan Kellerman",
                BookNumber = 222016,
                Description = "The psychologist-detective Alex Delaware is called in when women s bodies keep turning up in a Los Angeles marsh.",
                Price = 27m,
                Cost = 14.85m,
                PublishDate = new DateTime(2008, 10, 25),
                InventoryQuantity = 7,
                ReorderPoint = 2,
                BookStatus = false
            };
            b16.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b16);

            Book b17 = new Book()
            {
                Title = "Rough Weather",
                Authors = "Robert B Parker",
                BookNumber = 222017,
                Description = "The Boston private eye Spenser gets involved when a gunman kidnaps the bride from her wedding on a private island.",
                Price = 26.95m,
                Cost = 20.75m,
                PublishDate = new DateTime(2008, 10, 25),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                BookStatus = false
            };
            b17.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b17);

            Book b18 = new Book()
            {
                Title = "Extreme Measures",
                Authors = "Vince Flynn",
                BookNumber = 222018,
                Description = "Mitch Rapp teams up with a C.I.A. colleague to fight a terrorist cell   and the politicians who would rein them in.",
                Price = 27.95m,
                Cost = 15.09m,
                PublishDate = new DateTime(2008, 10, 25),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                BookStatus = false
            };
            b18.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b18);

            Book b19 = new Book()
            {
                Title = "A Good Woman",
                Authors = "Danielle Steel",
                BookNumber = 222019,
                Description = "An American society girl who made a new life as a doctor in World War I France returns to New York.",
                Price = 27m,
                Cost = 10.53m,
                PublishDate = new DateTime(2008, 11, 1),
                InventoryQuantity = 6,
                ReorderPoint = 1,
                BookStatus = false
            };
            b19.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b19);

            Book b20 = new Book()
            {
                Title = "Midnight",
                Authors = "Sister Souljah",
                BookNumber = 222020,
                Description = "A boy from Sudan struggles to protect his mother and sister and remain true to his Islamic principles in a Brooklyn housing project.",
                Price = 26.95m,
                Cost = 21.29m,
                PublishDate = new DateTime(2008, 11, 8),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                BookStatus = false
            };
            b20.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b20);

            Book b21 = new Book()
            {
                Title = "Scarpetta",
                Authors = "Patricia Cornwell",
                BookNumber = 222021,
                Description = "The forensic pathologist Kay Scarpetta takes an assignment in New York City.",
                Price = 27.95m,
                Cost = 13.14m,
                PublishDate = new DateTime(2008, 12, 6),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b21.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b21);

            Book b22 = new Book()
            {
                Title = "A Darker Place",
                Authors = "Jack Higgins",
                BookNumber = 222022,
                Description = "A Russian defector becomes a counterspy.",
                Price = 26.95m,
                Cost = 11.86m,
                PublishDate = new DateTime(2009, 1, 31),
                InventoryQuantity = 11,
                ReorderPoint = 7,
                BookStatus = false
            };
            b22.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b22);

            Book b23 = new Book()
            {
                Title = "Fatally Flaky",
                Authors = "Diane Mott Davidson",
                BookNumber = 222023,
                Description = "The caterer Goldy Schulz tries to outwit a killer on the grounds of an Aspen spa.",
                Price = 25.99m,
                Cost = 22.09m,
                PublishDate = new DateTime(2009, 4, 11),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                BookStatus = false
            };
            b23.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b23);

            Book b24 = new Book()
            {
                Title = "Turn Coat",
                Authors = "Jim Butcher",
                BookNumber = 222024,
                Description = "Book 11 of the Dresden Files series about a wizard detective in Chicago.",
                Price = 25.95m,
                Cost = 9.34m,
                PublishDate = new DateTime(2009, 4, 11),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                BookStatus = false
            };
            b24.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b24);

            Book b25 = new Book()
            {
                Title = "Borderline",
                Authors = "Nevada Barr",
                BookNumber = 222025,
                Description = "Off duty and on vacation in Big Bend National Park, Anna Pigeon rescues a baby and is drawn into cross-border intrigue.",
                Price = 25.95m,
                Cost = 3.11m,
                PublishDate = new DateTime(2009, 4, 11),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                BookStatus = false
            };
            b25.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b25);

            Book b26 = new Book()
            {
                Title = "Summer On Blossom Street",
                Authors = "Debbie Macomber",
                BookNumber = 222026,
                Description = "More stories of life and love from a Seattle knitting class.",
                Price = 24.95m,
                Cost = 7.24m,
                PublishDate = new DateTime(2009, 5, 2),
                InventoryQuantity = 7,
                ReorderPoint = 2,
                BookStatus = false
            };
            b26.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b26);

            Book b27 = new Book()
            {
                Title = "Dead And Gone",
                Authors = "Charlaine Harris",
                BookNumber = 222027,
                Description = "Sookie Stackhouse searches for the killer of a werepanther.",
                Price = 25.95m,
                Cost = 24.65m,
                PublishDate = new DateTime(2009, 5, 9),
                InventoryQuantity = 10,
                ReorderPoint = 5,
                BookStatus = false
            };
            b27.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b27);

            Book b28 = new Book()
            {
                Title = "Brooklyn",
                Authors = "Colm Toibin",
                BookNumber = 222028,
                Description = "An unsophisticated young Irishwoman leaves her home for New York in the 1950s. Originally published in 2009 and the basis of the 2015 movie.",
                Price = 18.95m,
                Cost = 3.6m,
                PublishDate = new DateTime(2009, 5, 9),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                BookStatus = false
            };
            b28.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b28);

            Book b29 = new Book()
            {
                Title = "The Last Child",
                Authors = "John Hart",
                BookNumber = 222029,
                Description = "A teenager searches for his inexplicably vanished twin sister.",
                Price = 24.95m,
                Cost = 15.72m,
                PublishDate = new DateTime(2009, 5, 16),
                InventoryQuantity = 5,
                ReorderPoint = 2,
                BookStatus = false
            };
            b29.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b29);

            Book b30 = new Book()
            {
                Title = "Heartless",
                Authors = "Diana Palmer",
                BookNumber = 222030,
                Description = "A woman s secret makes it hard for her to accept her stepbrother s love.",
                Price = 24.95m,
                Cost = 21.46m,
                PublishDate = new DateTime(2009, 5, 30),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b30.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b30);

            Book b31 = new Book()
            {
                Title = "Shanghai Girls",
                Authors = "Lisa See",
                BookNumber = 222031,
                Description = "Two Chinese sisters in the 1930s are sold as wives to men from California, and leave their war-torn country to join them.",
                Price = 25m,
                Cost = 2.5m,
                PublishDate = new DateTime(2009, 5, 30),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b31.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b31);

            Book b32 = new Book()
            {
                Title = "Skin Trade",
                Authors = "Laurell K Hamilton",
                BookNumber = 222032,
                Description = "Investigating some killings in Las Vegas, the vampire hunter Anita Blake must contend with the power of the weretigers.",
                Price = 26.95m,
                Cost = 2.7m,
                PublishDate = new DateTime(2009, 6, 6),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                BookStatus = false
            };
            b32.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b32);

            Book b33 = new Book()
            {
                Title = "Roadside Crosses",
                Authors = "Jeffery Deaver",
                BookNumber = 222033,
                Description = "A California kinesics expert pursues a killer who stalks victims using information they ve posted online.",
                Price = 26.95m,
                Cost = 7.82m,
                PublishDate = new DateTime(2009, 6, 13),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                BookStatus = false
            };
            b33.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b33);

            Book b34 = new Book()
            {
                Title = "Finger Lickin  Fifteen",
                Authors = "Janet Evanovich",
                BookNumber = 222034,
                Description = "The bounty hunter Stephanie Plum hunts a celebrity chef s killer.",
                Price = 27.95m,
                Cost = 3.63m,
                PublishDate = new DateTime(2009, 6, 27),
                InventoryQuantity = 7,
                ReorderPoint = 4,
                BookStatus = false
            };
            b34.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b34);

            Book b35 = new Book()
            {
                Title = "Return To Sullivans Island",
                Authors = "Dorothea Benton Frank",
                BookNumber = 222035,
                Description = "A recent college graduate returns to her family s home on an island in the South Carolina Lowcountry and wrestles with tragedy and betrayal in the company of her appealing relatives.",
                Price = 25.99m,
                Cost = 13.25m,
                PublishDate = new DateTime(2009, 7, 4),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                BookStatus = false
            };
            b35.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b35);

            Book b36 = new Book()
            {
                Title = "The Castaways",
                Authors = "Elin Hilderbrand",
                BookNumber = 222036,
                Description = "A Nantucket couple drowns, raising questions and precipitating conflicts among their group of friends.",
                Price = 24.99m,
                Cost = 16.99m,
                PublishDate = new DateTime(2009, 7, 11),
                InventoryQuantity = 7,
                ReorderPoint = 2,
                BookStatus = false
            };
            b36.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b36);

            Book b37 = new Book()
            {
                Title = "Rain Gods",
                Authors = "James Lee Burke",
                BookNumber = 222037,
                Description = "A Texas sheriff investigates a mass murder of illegal aliens and tries to find the young Iraq war veteran who may have been involved   before the F.B.I. can.",
                Price = 25.99m,
                Cost = 21.05m,
                PublishDate = new DateTime(2009, 7, 18),
                InventoryQuantity = 6,
                ReorderPoint = 2,
                BookStatus = false
            };
            b37.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b37);

            Book b38 = new Book()
            {
                Title = "Undone",
                Authors = "Karin Slaughter",
                BookNumber = 222038,
                Description = "Dr. Sara Linton works with agents of the Georgia Bureau of Investigation to stop a killer who tortures his victims.",
                Price = 26m,
                Cost = 7.28m,
                PublishDate = new DateTime(2009, 7, 18),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                BookStatus = false
            };
            b38.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b38);

            Book b39 = new Book()
            {
                Title = "Guardian Of Lies",
                Authors = "Steve Martini",
                BookNumber = 222039,
                Description = "The lawyer Paul Madriani unravels a mystery involving gold coins, the C.I.A., and a weapon forgotten since the Cuban missile crisis.",
                Price = 26.99m,
                Cost = 18.62m,
                PublishDate = new DateTime(2009, 7, 18),
                InventoryQuantity = 6,
                ReorderPoint = 2,
                BookStatus = false
            };
            b39.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b39);

            Book b40 = new Book()
            {
                Title = "Dreamfever",
                Authors = "Karen Marie Moning",
                BookNumber = 222040,
                Description = "MacKlaya finds herself under the erotic spell of a Fae master.",
                Price = 26m,
                Cost = 21.06m,
                PublishDate = new DateTime(2009, 8, 22),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                BookStatus = false
            };
            b40.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b40);

            Book b41 = new Book()
            {
                Title = "Resurrecting Midnight",
                Authors = "Eric Jerome Dickey",
                BookNumber = 222041,
                Description = "Gideon, an international assassin, travels to Argentina in pursuit of a dangerous assignment.",
                Price = 26.95m,
                Cost = 14.55m,
                PublishDate = new DateTime(2009, 8, 29),
                InventoryQuantity = 3,
                ReorderPoint = 3,
                BookStatus = false
            };
            b41.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b41);

            Book b42 = new Book()
            {
                Title = "Dexter By Design",
                Authors = "Jeff Lindsay",
                BookNumber = 222042,
                Description = "A serial killer who arranges victims in artful poses challenges the Miami Police Department and its blood splatter analyst, Dexter.",
                Price = 25m,
                Cost = 2.75m,
                PublishDate = new DateTime(2009, 9, 12),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                BookStatus = false
            };
            b42.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b42);

            Book b43 = new Book()
            {
                Title = "The Professional",
                Authors = "Robert B Parker",
                BookNumber = 222043,
                Description = "Rich women are turning up dead, and the Boston P.I. Spenser investigates.",
                Price = 26.95m,
                Cost = 7.01m,
                PublishDate = new DateTime(2009, 10, 10),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                BookStatus = false
            };
            b43.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b43);

            Book b44 = new Book()
            {
                Title = "The Unseen Academicals",
                Authors = "Terry Pratchett",
                BookNumber = 222044,
                Description = "In this Discworld fantasy, the benevolent tyrant of Ankh-Morpork suggests that Unseen University put together a football team.",
                Price = 25.99m,
                Cost = 3.12m,
                PublishDate = new DateTime(2009, 10, 10),
                InventoryQuantity = 14,
                ReorderPoint = 9,
                BookStatus = false
            };
            b44.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b44);

            Book b45 = new Book()
            {
                Title = "Pursuit Of Honor",
                Authors = "Vince Flynn",
                BookNumber = 222045,
                Description = "The counterterrorism operative Mitch Rapp must teach politicians about national security following a new Qaeda attack.",
                Price = 27.99m,
                Cost = 5.04m,
                PublishDate = new DateTime(2009, 10, 17),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b45.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b45);

            Book b46 = new Book()
            {
                Title = "No Less Than Victory",
                Authors = "Jeff Shaara",
                BookNumber = 222046,
                Description = "The final volume of a trilogy of novels about World War II focuses on the final years of the war, including the Battle of the Bulge and the American sweep through Germany.",
                Price = 28m,
                Cost = 20.72m,
                PublishDate = new DateTime(2009, 11, 7),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                BookStatus = false
            };
            b46.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b46);

            Book b47 = new Book()
            {
                Title = "Ford County",
                Authors = "John Grisham",
                BookNumber = 222047,
                Description = "Stories set in rural Mississippi.",
                Price = 24m,
                Cost = 14.88m,
                PublishDate = new DateTime(2009, 11, 7),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                BookStatus = false
            };
            b47.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b47);

            Book b48 = new Book()
            {
                Title = "Wishin' And Hopin'",
                Authors = "Wally Lamb",
                BookNumber = 222048,
                Description = "A fifth-grader in 1964 gets ready for Christmas.",
                Price = 15m,
                Cost = 13.95m,
                PublishDate = new DateTime(2009, 11, 14),
                InventoryQuantity = 3,
                ReorderPoint = 3,
                BookStatus = false
            };
            b48.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Humor");
            Books.Add(b48);

            Book b49 = new Book()
            {
                Title = "First Lord S Fury",
                Authors = "Jim Butcher",
                BookNumber = 222049,
                Description = "With their survival at stake, Alerans prepare for a final battle in the sixth book of the Alera fantasy cycle.",
                Price = 25.95m,
                Cost = 13.23m,
                PublishDate = new DateTime(2009, 11, 28),
                InventoryQuantity = 4,
                ReorderPoint = 1,
                BookStatus = false
            };
            b49.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b49);

            Book b50 = new Book()
            {
                Title = "Altar Of Eden",
                Authors = "James Rollins",
                BookNumber = 222050,
                Description = "A Louisiana veterinarian discovers a wrecked fishing trawler filled with genetically altered animals.",
                Price = 27.99m,
                Cost = 25.75m,
                PublishDate = new DateTime(2010, 1, 2),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                BookStatus = false
            };
            b50.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b50);

            Book b51 = new Book()
            {
                Title = "Deeper Than The Dead",
                Authors = "Tami Hoag",
                BookNumber = 222051,
                Description = "An F.B.I. investigator and a teacher track a series of murders in California in 1985.",
                Price = 26.95m,
                Cost = 9.7m,
                PublishDate = new DateTime(2010, 1, 2),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b51.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b51);

            Book b52 = new Book()
            {
                Title = "Roses",
                Authors = "Leila Meacham",
                BookNumber = 222052,
                Description = "Three generations in a small East Texas town.",
                Price = 24.99m,
                Cost = 20.99m,
                PublishDate = new DateTime(2010, 1, 16),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                BookStatus = false
            };
            b52.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b52);

            Book b53 = new Book()
            {
                Title = "Blood Ties",
                Authors = "Kay Hooper",
                BookNumber = 222053,
                Description = "The F.B.I. agent Noah Bishop and his special crimes unit  pursue a brutal enemy.",
                Price = 26m,
                Cost = 5.2m,
                PublishDate = new DateTime(2010, 1, 30),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                BookStatus = false
            };
            b53.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b53);

            Book b54 = new Book()
            {
                Title = "The Midnight House",
                Authors = "Alex Berenson",
                BookNumber = 222054,
                Description = "Who is killing members of a secret unit that interrogated terrorists? The C.I.A. agent John Wells is on the case.",
                Price = 25.95m,
                Cost = 3.11m,
                PublishDate = new DateTime(2010, 2, 13),
                InventoryQuantity = 5,
                ReorderPoint = 5,
                BookStatus = false
            };
            b54.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b54);

            Book b55 = new Book()
            {
                Title = "Poor Little Bitch Girl",
                Authors = "Jackie Collins",
                BookNumber = 222055,
                Description = "Hollywood murder, three beautiful 20-something high school friends, a hot New York club owner.",
                Price = 26.99m,
                Cost = 17.54m,
                PublishDate = new DateTime(2010, 2, 13),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                BookStatus = false
            };
            b55.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b55);

            Book b56 = new Book()
            {
                Title = "Deep Shadow",
                Authors = "Randy Wayne White",
                BookNumber = 222056,
                Description = "Murderers want Doc Ford to help them dive for the remains of a wrecked plane supposedly laden with Cuban gold.",
                Price = 25.95m,
                Cost = 5.45m,
                PublishDate = new DateTime(2010, 3, 13),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                BookStatus = false
            };
            b56.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b56);

            Book b57 = new Book()
            {
                Title = "Think Twice",
                Authors = "Lisa Scottoline",
                BookNumber = 222057,
                Description = "A woman takes over her twin sister s life.",
                Price = 26.99m,
                Cost = 21.86m,
                PublishDate = new DateTime(2010, 3, 20),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                BookStatus = false
            };
            b57.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b57);

            Book b58 = new Book()
            {
                Title = "The Girl Who Chased The Moon",
                Authors = "Sarah Addison Allen",
                BookNumber = 222058,
                Description = "Mysteries and magic in a quirky North Carolina town.",
                Price = 25m,
                Cost = 11.25m,
                PublishDate = new DateTime(2010, 3, 20),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                BookStatus = false
            };
            b58.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b58);

            Book b59 = new Book()
            {
                Title = "Without Mercy",
                Authors = "Lisa Jackson",
                BookNumber = 222059,
                Description = "Students are dying at an Oregon boarding school for wayward kids, and the concerned new teacher may be the next target.",
                Price = 25m,
                Cost = 4.25m,
                PublishDate = new DateTime(2010, 4, 3),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                BookStatus = false
            };
            b59.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b59);

            Book b60 = new Book()
            {
                Title = "Wrecked",
                Authors = "Carol Higgins Clark",
                BookNumber = 222060,
                Description = "In the 13th mystery in this series, the suspicious disappearance of a neighbor interrupts a romantic weekend on Cape Cod for the P.I. Regan Reilly and her husband.",
                Price = 25m,
                Cost = 18m,
                PublishDate = new DateTime(2010, 4, 17),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                BookStatus = false
            };
            b60.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b60);

            Book b61 = new Book()
            {
                Title = "Reckless",
                Authors = "Andrew Gross",
                BookNumber = 222061,
                Description = "A close friend from the investigator Ty Hauck's past has been brutally murdered, and he will risk everything he loves to avenge her death.",
                Price = 22m,
                Cost = 9.46m,
                PublishDate = new DateTime(2010, 5, 1),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                BookStatus = false
            };
            b61.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b61);

            Book b62 = new Book()
            {
                Title = "Executive Intent",
                Authors = "Dale Brown",
                BookNumber = 222062,
                Description = "With the United States unleashing a missile-launching satellite that can strike anywhere in seconds, China and Russia respond swiftly and brutally.",
                Price = 27.95m,
                Cost = 22.64m,
                PublishDate = new DateTime(2010, 5, 15),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                BookStatus = false
            };
            b62.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b62);

            Book b63 = new Book()
            {
                Title = "Heart Of The Matter",
                Authors = "Emily Giffin",
                BookNumber = 222063,
                Description = "The lives of two women   one married to a pediatric plastic surgeon, the other a lawyer and single mother   converge after an accident involving the lawyer s son.",
                Price = 26.99m,
                Cost = 6.21m,
                PublishDate = new DateTime(2010, 5, 15),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                BookStatus = false
            };
            b63.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b63);

            Book b64 = new Book()
            {
                Title = "That Perfect Someone",
                Authors = "Johanna Lindsey",
                BookNumber = 222064,
                Description = "To avoid falling into a ruthless nobleman's trap, an heiress enters into a risky, intimate charade with a man she was once bound to wed.",
                Price = 25m,
                Cost = 18.25m,
                PublishDate = new DateTime(2010, 6, 19),
                InventoryQuantity = 9,
                ReorderPoint = 9,
                BookStatus = false
            };
            b64.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b64);

            Book b65 = new Book()
            {
                Title = "Mission Of Honor",
                Authors = "David Weber",
                BookNumber = 222065,
                Description = "Honor Harrington defends the Star Kingdom of Manticore as it is besieged by many enemies.",
                Price = 27m,
                Cost = 6.75m,
                PublishDate = new DateTime(2010, 6, 26),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                BookStatus = false
            };
            b65.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b65);

            Book b66 = new Book()
            {
                Title = "Sizzling Sixteen",
                Authors = "Janet Evanovich",
                BookNumber = 222066,
                Description = "The bounty hunter Stephanie Plum comes to the aid of a cousin with gambling debts.",
                Price = 27.99m,
                Cost = 12.32m,
                PublishDate = new DateTime(2010, 6, 26),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b66.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b66);

            Book b67 = new Book()
            {
                Title = "The Thousand Autumns Of Jacob De Zoet",
                Authors = "David Mitchell",
                BookNumber = 222067,
                Description = "Forbidden love in Edo-era Japan.",
                Price = 26m,
                Cost = 9.62m,
                PublishDate = new DateTime(2010, 7, 3),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                BookStatus = false
            };
            b67.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b67);

            Book b68 = new Book()
            {
                Title = "The Search",
                Authors = "Nora Roberts",
                BookNumber = 222068,
                Description = "The only survivor of a serial killer has found peace in the Pacific Northwest, but her life is shaken by the appearance of a new man and a copycat murderer.",
                Price = 26.95m,
                Cost = 8.62m,
                PublishDate = new DateTime(2010, 7, 10),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b68.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b68);

            Book b69 = new Book()
            {
                Title = "Death On The D-List",
                Authors = "Nancy Grace",
                BookNumber = 222069,
                Description = "Fading celebrities who appear on Hailey Dean s TV show are being murdered.",
                Price = 25.99m,
                Cost = 5.98m,
                PublishDate = new DateTime(2010, 8, 14),
                InventoryQuantity = 6,
                ReorderPoint = 1,
                BookStatus = false
            };
            b69.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b69);

            Book b70 = new Book()
            {
                Title = "No Mercy",
                Authors = "Sherrilyn Kenyon",
                BookNumber = 222070,
                Description = "Book 19 of the Dark-Hunter paranormal series.",
                Price = 24.99m,
                Cost = 5.25m,
                PublishDate = new DateTime(2010, 9, 11),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                BookStatus = false
            };
            b70.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b70);

            Book b71 = new Book()
            {
                Title = "The Fall",
                Authors = "Guillermo del Toro and Chuck Hogan",
                BookNumber = 222071,
                Description = "A war erupts between Old and New World vampires. Book 2 of the Strain trilogy.",
                Price = 26.99m,
                Cost = 13.23m,
                PublishDate = new DateTime(2010, 9, 25),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                BookStatus = false
            };
            b71.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b71);

            Book b72 = new Book()
            {
                Title = "Legacy",
                Authors = "Danielle Steel",
                BookNumber = 222072,
                Description = "A writer s stunning family discovery leads to Paris, the French aristocracy and a mysterious Sioux ancestor.",
                Price = 28m,
                Cost = 6.44m,
                PublishDate = new DateTime(2010, 10, 2),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                BookStatus = false
            };
            b72.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b72);

            Book b73 = new Book()
            {
                Title = "Call Me Mrs. Miracle",
                Authors = "Debbie Macomber",
                BookNumber = 222073,
                Description = "Working in the toy section of a department store, Emily Merkle is called upon to engineer some Christmas miracles.",
                Price = 16.95m,
                Cost = 8.31m,
                PublishDate = new DateTime(2010, 10, 2),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                BookStatus = false
            };
            b73.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b73);

            Book b74 = new Book()
            {
                Title = "Promise Me",
                Authors = "Richard Paul Evans",
                BookNumber = 222074,
                Description = "On Christmas Day, a woman with family problems meets a handsome, mysterious stranger.",
                Price = 19.99m,
                Cost = 10.79m,
                PublishDate = new DateTime(2010, 10, 9),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b74.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b74);

            Book b75 = new Book()
            {
                Title = "Crescent Dawn",
                Authors = "Clive Cussler and Dirk Cussler",
                BookNumber = 222075,
                Description = "Dirk Pitt seeks a tie between a trove of ancient Roman artifacts and a series of mosque explosions.",
                Price = 27.95m,
                Cost = 20.12m,
                PublishDate = new DateTime(2010, 11, 20),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                BookStatus = false
            };
            b75.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Adventure");
            Books.Add(b75);

            Book b76 = new Book()
            {
                Title = "An Object Of Beauty",
                Authors = "Steve Martin",
                BookNumber = 222076,
                Description = "A young, beautiful and ambitious woman ruthlessly ascends the heights of the Manhattan art world.",
                Price = 26.99m,
                Cost = 8.91m,
                PublishDate = new DateTime(2010, 11, 27),
                InventoryQuantity = 6,
                ReorderPoint = 6,
                BookStatus = false
            };
            b76.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b76);

            Book b77 = new Book()
            {
                Title = "Dead Or Alive",
                Authors = "Tom Clancy with Grant Blackwood",
                BookNumber = 222077,
                Description = "Many characters from Clancy s previous novels make an appearance as an intelligence group tracks a vicious terrorist called the Emir.",
                Price = 28.95m,
                Cost = 24.03m,
                PublishDate = new DateTime(2010, 12, 11),
                InventoryQuantity = 8,
                ReorderPoint = 8,
                BookStatus = false
            };
            b77.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b77);

            Book b78 = new Book()
            {
                Title = "Damage",
                Authors = "John Lescroart",
                BookNumber = 222078,
                Description = "The San Francisco detective Abe Glitsky faces a scion of wealth who s seeking revenge against those who sent him to prison a decade ago.",
                Price = 26.95m,
                Cost = 24.26m,
                PublishDate = new DateTime(2011, 1, 8),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                BookStatus = false
            };
            b78.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b78);

            Book b79 = new Book()
            {
                Title = "The Inner Circle",
                Authors = "Brad Meltzer",
                BookNumber = 222079,
                Description = "An archivist discovers a book that once belonged to George Washington and conceals a deadly secret.",
                Price = 26.99m,
                Cost = 11.61m,
                PublishDate = new DateTime(2011, 1, 15),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                BookStatus = false
            };
            b79.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b79);

            Book b80 = new Book()
            {
                Title = "Shadowfever",
                Authors = "Karen Marie Moning",
                BookNumber = 222080,
                Description = "Hunting for her sister s murderer, MacKayla Lane is caught up in the struggle between humans and the Fae.",
                Price = 26m,
                Cost = 13.78m,
                PublishDate = new DateTime(2011, 1, 22),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                BookStatus = false
            };
            b80.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b80);

            Book b81 = new Book()
            {
                Title = "Call Me Irresistible",
                Authors = "Susan Elizabeth Phillips",
                BookNumber = 222081,
                Description = "In a small town in Texas, characters from Phillips s earlier novels reappear as a woman persuades a friend to call off her wedding to the town s popular mayor.",
                Price = 25.99m,
                Cost = 11.44m,
                PublishDate = new DateTime(2011, 1, 22),
                InventoryQuantity = 4,
                ReorderPoint = 3,
                BookStatus = false
            };
            b81.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b81);

            Book b82 = new Book()
            {
                Title = "A Discovery Of Witches",
                Authors = "Deborah Harkness",
                BookNumber = 222082,
                Description = "The recovery of a lost ancient manuscript in a library at Oxford sets a fantastical underworld stirring.",
                Price = 28.95m,
                Cost = 3.76m,
                PublishDate = new DateTime(2011, 2, 12),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                BookStatus = false
            };
            b82.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b82);

            Book b83 = new Book()
            {
                Title = "Gideon s Sword",
                Authors = "Douglas Preston and Lincoln Child",
                BookNumber = 222083,
                Description = "Gideon Crew avenges his father s death and is sent on a mission by a government contractor.",
                Price = 26.99m,
                Cost = 19.7m,
                PublishDate = new DateTime(2011, 2, 26),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                BookStatus = false
            };
            b83.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b83);

            Book b84 = new Book()
            {
                Title = "Treachery In Death",
                Authors = "J D Robb",
                BookNumber = 222084,
                Description = "Eve Dallas and her partner, Peabody, investigate a grocer s murder.",
                Price = 26.95m,
                Cost = 5.93m,
                PublishDate = new DateTime(2011, 2, 26),
                InventoryQuantity = 8,
                ReorderPoint = 5,
                BookStatus = false
            };
            b84.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b84);

            Book b85 = new Book()
            {
                Title = "Live Wire",
                Authors = "Harlan Coben",
                BookNumber = 222085,
                Description = "Myron Bolitar s search for a missing rock star leads to questions about his own missing brother.",
                Price = 27.95m,
                Cost = 13.98m,
                PublishDate = new DateTime(2011, 3, 26),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                BookStatus = false
            };
            b85.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b85);

            Book b86 = new Book()
            {
                Title = "A Lesson In Secrets",
                Authors = "Jacqueline Winspear",
                BookNumber = 222086,
                Description = "In the summer of 1932, Maisie Dobbs s first assignment for the British secret service takes her undercover to Cambridge as a professor.",
                Price = 25.99m,
                Cost = 12.22m,
                PublishDate = new DateTime(2011, 3, 26),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                BookStatus = false
            };
            b86.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b86);

            Book b87 = new Book()
            {
                Title = "Crunch Time",
                Authors = "Diane Mott Davidson",
                BookNumber = 222087,
                Description = "The caterer and sleuth Goldy Schulz tries to help a friend whose rental house has been destroyed by arson.",
                Price = 26.99m,
                Cost = 3.78m,
                PublishDate = new DateTime(2011, 4, 9),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                BookStatus = false
            };
            b87.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b87);

            Book b88 = new Book()
            {
                Title = "I Ll Walk Alone",
                Authors = "Mary Higgins Clark",
                BookNumber = 222088,
                Description = "A woman haunted by the disappearance of her young son discovers that someone has stolen her identity.",
                Price = 25.99m,
                Cost = 3.9m,
                PublishDate = new DateTime(2011, 4, 9),
                InventoryQuantity = 14,
                ReorderPoint = 9,
                BookStatus = false
            };
            b88.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b88);

            Book b89 = new Book()
            {
                Title = "The Fifth Witness",
                Authors = "Michael Connelly",
                BookNumber = 222089,
                Description = "The defense lawyer Mickey Haller represents a woman facing home foreclosure who is accused of killing a banker.",
                Price = 27.99m,
                Cost = 6.16m,
                PublishDate = new DateTime(2011, 4, 9),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b89.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b89);

            Book b90 = new Book()
            {
                Title = "Save Me",
                Authors = "Lisa Scottoline",
                BookNumber = 222090,
                Description = "A mother s action during a school emergency causes an uproar in a Philadelphia suburb.",
                Price = 27.99m,
                Cost = 11.2m,
                PublishDate = new DateTime(2011, 4, 16),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                BookStatus = false
            };
            b90.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b90);

            Book b91 = new Book()
            {
                Title = "Quicksilver",
                Authors = "Amanda Quick",
                BookNumber = 222091,
                Description = "In this Arcane Society novel set in Victorian London, two paranormal talents must find a murderer before they become the next victims.",
                Price = 25.95m,
                Cost = 23.1m,
                PublishDate = new DateTime(2011, 4, 23),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                BookStatus = false
            };
            b91.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b91);

            Book b92 = new Book()
            {
                Title = "The Sixth Man",
                Authors = "David Baldacci",
                BookNumber = 222092,
                Description = "The lawyer for an alleged serial killer is murdered, and two former Secret Service agents are on the case.",
                Price = 27.99m,
                Cost = 20.15m,
                PublishDate = new DateTime(2011, 4, 23),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                BookStatus = false
            };
            b92.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b92);

            Book b93 = new Book()
            {
                Title = "Those In Peril",
                Authors = "Wilbur Smith",
                BookNumber = 222093,
                Description = "A private security agent battles pirates who have kidnapped a woman from a yacht in the Indian Ocean.",
                Price = 27.99m,
                Cost = 16.23m,
                PublishDate = new DateTime(2011, 5, 14),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                BookStatus = false
            };
            b93.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b93);

            Book b94 = new Book()
            {
                Title = "The Jefferson Key",
                Authors = "Steve Berry",
                BookNumber = 222094,
                Description = "The former government operative Cotton Malone foils an assassination attempt on the president and finds himself at dangerous odds with a secret society.",
                Price = 26m,
                Cost = 18.2m,
                PublishDate = new DateTime(2011, 5, 21),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                BookStatus = false
            };
            b94.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b94);

            Book b95 = new Book()
            {
                Title = "Summer Rental",
                Authors = "Mary Kay Andrews",
                BookNumber = 222095,
                Description = "Three friends in their mid-30s spend a month on North Carolina s Outer Banks.",
                Price = 25.99m,
                Cost = 9.62m,
                PublishDate = new DateTime(2011, 6, 11),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                BookStatus = false
            };
            b95.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b95);

            Book b96 = new Book()
            {
                Title = "One Summer",
                Authors = "David Baldacci",
                BookNumber = 222096,
                Description = "As Christmas nears, a terminally ill man is preparing his family for his death when another tragedy strikes.",
                Price = 25.99m,
                Cost = 20.01m,
                PublishDate = new DateTime(2011, 6, 18),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                BookStatus = false
            };
            b96.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b96);

            Book b97 = new Book()
            {
                Title = "Before I Go To Sleep",
                Authors = "S J Watson",
                BookNumber = 222097,
                Description = "After a mysterious accident, an amnesiac cannot remember her past or form new memories.",
                Price = 14.99m,
                Cost = 6m,
                PublishDate = new DateTime(2011, 6, 18),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                BookStatus = false
            };
            b97.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b97);

            Book b98 = new Book()
            {
                Title = "Now You See Her",
                Authors = "James Patterson and Michael Ledwidge",
                BookNumber = 222098,
                Description = "Nina Bloom, who years ago changed her identity to save her life, is forced to confront the past and the killer she thought she had escaped.",
                Price = 27.99m,
                Cost = 8.4m,
                PublishDate = new DateTime(2011, 7, 2),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b98.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b98);

            Book b99 = new Book()
            {
                Title = "Full Black",
                Authors = "Brad Thor",
                BookNumber = 222099,
                Description = "The covert counterterrorism operative Scot Harvath has a plan to stop a terrorist group that wants to take down the United States.",
                Price = 26.99m,
                Cost = 5.67m,
                PublishDate = new DateTime(2011, 7, 30),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                BookStatus = false
            };
            b99.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b99);

            Book b100 = new Book()
            {
                Title = "Ghost Story",
                Authors = "Jim Butcher",
                BookNumber = 222100,
                Description = "Harry Dresden, the wizard detective in Chicago, has been murdered. But that doesn t stop him when his friends are in danger.",
                Price = 27.95m,
                Cost = 12.02m,
                PublishDate = new DateTime(2011, 7, 30),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                BookStatus = false
            };
            b100.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b100);

            Book b101 = new Book()
            {
                Title = "Back Of Beyond",
                Authors = "C J Box",
                BookNumber = 222101,
                Description = "Cody Hoyt, a brilliant cop and an alcoholic struggling with two months of sobriety, is determined to find his mentor s killer.",
                Price = 25.99m,
                Cost = 24.69m,
                PublishDate = new DateTime(2011, 8, 6),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b101.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b101);

            Book b102 = new Book()
            {
                Title = "The Omen Machine",
                Authors = "Terry Goodkind",
                BookNumber = 222102,
                Description = "A return to the lives of Richard Rahl and Kahlan Amnell, in a tale of a new threat to their world.",
                Price = 29.99m,
                Cost = 17.69m,
                PublishDate = new DateTime(2011, 8, 20),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                BookStatus = false
            };
            b102.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b102);

            Book b103 = new Book()
            {
                Title = "The Measure Of The Magic",
                Authors = "Terry Brooks",
                BookNumber = 222103,
                Description = "With the land on edge, Panterra is destined to confront a menace who seeks to claim the last black staff, and the life of the one who wields it.",
                Price = 27m,
                Cost = 15.39m,
                PublishDate = new DateTime(2011, 8, 27),
                InventoryQuantity = 7,
                ReorderPoint = 4,
                BookStatus = false
            };
            b103.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b103);

            Book b104 = new Book()
            {
                Title = "How Firm A Foundation",
                Authors = "David Weber",
                BookNumber = 222104,
                Description = "The island empire of Charis fights to survive.",
                Price = 27.99m,
                Cost = 23.79m,
                PublishDate = new DateTime(2011, 9, 17),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                BookStatus = false
            };
            b104.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b104);

            Book b105 = new Book()
            {
                Title = "Reamde",
                Authors = "Neal Stephenson",
                BookNumber = 222105,
                Description = "A virus invades a multiplayer online role-playing game and sets off a violent struggle.",
                Price = 35m,
                Cost = 14.7m,
                PublishDate = new DateTime(2011, 9, 24),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                BookStatus = false
            };
            b105.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b105);

            Book b106 = new Book()
            {
                Title = "Nightwoods",
                Authors = "Charles Frazier",
                BookNumber = 222106,
                Description = "When a young woman inherits her murdered sister s troubled twins, her solitary life becomes filled with mystery and action.",
                Price = 26m,
                Cost = 10.92m,
                PublishDate = new DateTime(2011, 10, 1),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                BookStatus = false
            };
            b106.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b106);

            Book b107 = new Book()
            {
                Title = "The Affair",
                Authors = "Lee Child",
                BookNumber = 222107,
                Description = "For Jack Reacher, an elite military police officer, it all started in 1997. A lonely railroad track. A crime scene. A cover-up.",
                Price = 28m,
                Cost = 8.68m,
                PublishDate = new DateTime(2011, 10, 1),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                BookStatus = false
            };
            b107.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b107);

            Book b108 = new Book()
            {
                Title = "A Lawman's Christmas",
                Authors = "Linda Lael Miller",
                BookNumber = 222108,
                Description = "The death of the town marshal leaves Blue River, Texas, without a lawman, and Dara Rose Nolan without a husband. Clay McKettrick steps in, and when he and Dara Rose agree to a marriage of convenience, the temporary lawman s Christmas wish is to make her his permanent wife.",
                Price = 28m,
                Cost = 15.96m,
                PublishDate = new DateTime(2011, 10, 1),
                InventoryQuantity = 10,
                ReorderPoint = 5,
                BookStatus = false
            };
            b108.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b108);

            Book b109 = new Book()
            {
                Title = "Bonnie",
                Authors = "Iris Johansen",
                BookNumber = 222109,
                Description = "The forensic sculptor Eve Duncan learns more about her daughter s disappearance and the girl s father s possible involvement.",
                Price = 27.99m,
                Cost = 24.07m,
                PublishDate = new DateTime(2011, 10, 22),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                BookStatus = false
            };
            b109.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b109);

            Book b110 = new Book()
            {
                Title = "The Christmas Wedding",
                Authors = "James Patterson and Richard DiLallo",
                BookNumber = 222110,
                Description = "A widow keeps the identity of the new man she is about to marry a secret as her children gather for Christmas.",
                Price = 25.99m,
                Cost = 23.65m,
                PublishDate = new DateTime(2011, 10, 22),
                InventoryQuantity = 3,
                ReorderPoint = 2,
                BookStatus = false
            };
            b110.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b110);

            Book b111 = new Book()
            {
                Title = "Zero Day",
                Authors = "David Baldacci",
                BookNumber = 222111,
                Description = "A military investigator uncovers a conspiracy.",
                Price = 27.99m,
                Cost = 18.47m,
                PublishDate = new DateTime(2011, 11, 5),
                InventoryQuantity = 12,
                ReorderPoint = 9,
                BookStatus = false
            };
            b111.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b111);

            Book b112 = new Book()
            {
                Title = "The Scottish Prisoner",
                Authors = "Diana Gabaldon",
                BookNumber = 222112,
                Description = "Jamie Fraser, a paroled Jacobite prisoner, and Lord John Grey collaborate uneasily on a mission to Ireland.",
                Price = 28m,
                Cost = 24.92m,
                PublishDate = new DateTime(2011, 12, 3),
                InventoryQuantity = 6,
                ReorderPoint = 2,
                BookStatus = false
            };
            b112.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b112);

            Book b113 = new Book()
            {
                Title = "77 Shadow Street",
                Authors = "Dean Koontz",
                BookNumber = 222113,
                Description = "A 19th-century tycoon s mansion has been turned into luxury apartments, but it remains in the grip of evil forces.",
                Price = 28m,
                Cost = 14.56m,
                PublishDate = new DateTime(2011, 12, 31),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                BookStatus = false
            };
            b113.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Horror");
            Books.Add(b113);

            Book b114 = new Book()
            {
                Title = "Love In A Nutshell",
                Authors = "Janet Evanovich and Dorien Kelly",
                BookNumber = 222114,
                Description = "A former magazine editor attempts to turn her parents  summer house into a bed-and-breakfast.",
                Price = 27.99m,
                Cost = 22.95m,
                PublishDate = new DateTime(2012, 1, 7),
                InventoryQuantity = 3,
                ReorderPoint = 3,
                BookStatus = false
            };
            b114.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b114);

            Book b115 = new Book()
            {
                Title = "The Hunter",
                Authors = "John Lescroart",
                BookNumber = 222115,
                Description = "A San Francisco private investigator discovers chilling facts about his birth family.",
                Price = 26.95m,
                Cost = 5.66m,
                PublishDate = new DateTime(2012, 1, 7),
                InventoryQuantity = 7,
                ReorderPoint = 6,
                BookStatus = false
            };
            b115.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b115);

            Book b116 = new Book()
            {
                Title = "Copper Beach",
                Authors = "Jayne Ann Krentz",
                BookNumber = 222116,
                Description = "Amy Radwell, whose psychic talent enables her to understand the paranormal secrets in rare books, becomes the target of a blackmailer. The first book in a new series about rare books and psychic codes.",
                Price = 25.95m,
                Cost = 16.09m,
                PublishDate = new DateTime(2012, 1, 14),
                InventoryQuantity = 5,
                ReorderPoint = 5,
                BookStatus = false
            };
            b116.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b116);

            Book b117 = new Book()
            {
                Title = "Left For Dead",
                Authors = "J A Jance",
                BookNumber = 222117,
                Description = "Ali Reynolds seeks justice for an old friend and an unidentified woman, both victims of brutal attacks.",
                Price = 25.99m,
                Cost = 20.01m,
                PublishDate = new DateTime(2012, 2, 11),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                BookStatus = false
            };
            b117.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b117);

            Book b118 = new Book()
            {
                Title = "Robert Ludlum S The Janson Command",
                Authors = "Paul Garrison",
                BookNumber = 222118,
                Description = "A former American operative builds a network to help him resolve crises without torture or civilian casualties.",
                Price = 27.99m,
                Cost = 7.28m,
                PublishDate = new DateTime(2012, 2, 18),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                BookStatus = false
            };
            b118.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b118);

            Book b119 = new Book()
            {
                Title = "Victims",
                Authors = "Jonathan Kellerman",
                BookNumber = 222119,
                Description = "The Los Angeles psychologist-detective Alex Delaware and the detective Milo Sturgis track down a homicidal maniac.",
                Price = 28m,
                Cost = 16.52m,
                PublishDate = new DateTime(2012, 3, 3),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                BookStatus = false
            };
            b119.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b119);

            Book b120 = new Book()
            {
                Title = "Another Piece Of My Heart",
                Authors = "Jane Green",
                BookNumber = 222120,
                Description = "A woman in her late 30s marries the man of her dreams and reaches out to his daughters by his previous marriage, but one of them is determined to destroy her.",
                Price = 25.99m,
                Cost = 20.27m,
                PublishDate = new DateTime(2012, 3, 17),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                BookStatus = false
            };
            b120.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b120);

            Book b121 = new Book()
            {
                Title = "Unnatural Acts",
                Authors = "Stuart Woods",
                BookNumber = 222121,
                Description = "The New York lawyer Stone Barrington becomes involved in the family problems of a billionaire hedge fund manager.",
                Price = 26.95m,
                Cost = 16.71m,
                PublishDate = new DateTime(2012, 4, 21),
                InventoryQuantity = 8,
                ReorderPoint = 6,
                BookStatus = false
            };
            b121.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b121);

            Book b122 = new Book()
            {
                Title = "Mission To Paris",
                Authors = "Alan Furst",
                BookNumber = 222122,
                Description = "In Paris in 1938, an actor stumbles into the clutches of Nazi conspirators who want to exploit his celebrity.",
                Price = 27m,
                Cost = 19.17m,
                PublishDate = new DateTime(2012, 6, 16),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                BookStatus = false
            };
            b122.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b122);

            Book b123 = new Book()
            {
                Title = "Shadow Of Night",
                Authors = "Deborah Harkness",
                BookNumber = 222123,
                Description = "An Oxford scholar/witch and a vampire geneticist pursue history, secrets and each other in Elizabethan London.",
                Price = 28.95m,
                Cost = 21.13m,
                PublishDate = new DateTime(2012, 7, 14),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                BookStatus = false
            };
            b123.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b123);

            Book b124 = new Book()
            {
                Title = "Where We Belong",
                Authors = "Emily Giffin",
                BookNumber = 222124,
                Description = "A woman s successful life is disrupted by the appearance of an 18-year-old girl with a link to her past.",
                Price = 27.99m,
                Cost = 8.12m,
                PublishDate = new DateTime(2012, 7, 28),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                BookStatus = false
            };
            b124.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b124);

            Book b125 = new Book()
            {
                Title = "Judgment Call",
                Authors = "J A Jance",
                BookNumber = 222125,
                Description = "Joanna Brady, an Arizona sheriff, must function as both a law officer and a mother when her daughter s high school principal is murdered.",
                Price = 25.99m,
                Cost = 8.84m,
                PublishDate = new DateTime(2012, 7, 28),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                BookStatus = false
            };
            b125.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b125);

            Book b126 = new Book()
            {
                Title = "Broken Harbor",
                Authors = "Tana French",
                BookNumber = 222126,
                Description = "In French s fourth Dublin murder squad novel, a detective s investigation of a crime in a seaside town evokes memories of his disturbing childhood there.",
                Price = 27.95m,
                Cost = 24.04m,
                PublishDate = new DateTime(2012, 7, 28),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b126.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b126);

            Book b127 = new Book()
            {
                Title = "Odd Apocalypse",
                Authors = "Dean Koontz",
                BookNumber = 222127,
                Description = "Odd Thomas, who can communicate with the dead, explores the mysteries of an old estate now owned by a billionaire.",
                Price = 28m,
                Cost = 14.28m,
                PublishDate = new DateTime(2012, 8, 4),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                BookStatus = false
            };
            b127.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Horror");
            Books.Add(b127);

            Book b128 = new Book()
            {
                Title = "Haven",
                Authors = "Kay Hooper",
                BookNumber = 222128,
                Description = "The F.B.I. agent Noah Bishop and his special crimes unit help two sisters probe the secrets of a North Carolina town.",
                Price = 26.95m,
                Cost = 14.82m,
                PublishDate = new DateTime(2012, 8, 4),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                BookStatus = false
            };
            b128.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b128);

            Book b129 = new Book()
            {
                Title = "The Inn At Rose Harbor",
                Authors = "Debbie Macomber",
                BookNumber = 222129,
                Description = "A young widow buys a bed-and-breakfast.",
                Price = 26m,
                Cost = 24.18m,
                PublishDate = new DateTime(2012, 8, 18),
                InventoryQuantity = 8,
                ReorderPoint = 5,
                BookStatus = false
            };
            b129.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b129);

            Book b130 = new Book()
            {
                Title = "Wards Of Faerie",
                Authors = "Terry Brooks",
                BookNumber = 222130,
                Description = "In the first book of a new fantasy series, the Dark Legacy of Shannara, Druids, Elves and humans unite to try to capture the Elfstones and rescue the troubled Four Lands.",
                Price = 28m,
                Cost = 4.2m,
                PublishDate = new DateTime(2012, 8, 25),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                BookStatus = false
            };
            b130.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b130);

            Book b131 = new Book()
            {
                Title = "A Sunless Sea",
                Authors = "Anne Perry",
                BookNumber = 222131,
                Description = "A murder case for William Monk of the Thames River Police culminates in a government minister s corruption trial.",
                Price = 26m,
                Cost = 22.62m,
                PublishDate = new DateTime(2012, 9, 1),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                BookStatus = false
            };
            b131.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b131);

            Book b132 = new Book()
            {
                Title = "Last To Die",
                Authors = "Tess Gerritsen",
                BookNumber = 222132,
                Description = "The detective Jane Rizzoli and the medical examiner Maura Isles protect a boy whose family and foster family have all been murdered.",
                Price = 27m,
                Cost = 9.99m,
                PublishDate = new DateTime(2012, 9, 1),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                BookStatus = false
            };
            b132.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b132);

            Book b133 = new Book()
            {
                Title = "Telegraph Avenue",
                Authors = "Michael Chabon",
                BookNumber = 222133,
                Description = "Fathers and sons in Berkeley and Oakland, Calif.",
                Price = 27.99m,
                Cost = 11.2m,
                PublishDate = new DateTime(2012, 9, 15),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                BookStatus = false
            };
            b133.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b133);

            Book b134 = new Book()
            {
                Title = "Midst Toil And Tribulation",
                Authors = "David Weber",
                BookNumber = 222134,
                Description = "In Book 6 of the Safehold science fiction series, the republic of Siddamark descends into chaos.",
                Price = 27.99m,
                Cost = 10.08m,
                PublishDate = new DateTime(2012, 9, 22),
                InventoryQuantity = 8,
                ReorderPoint = 8,
                BookStatus = false
            };
            b134.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b134);

            Book b135 = new Book()
            {
                Title = "Sleep No More",
                Authors = "Iris Johansen",
                BookNumber = 222135,
                Description = "The forensic sculptor Eve Duncan investigates when her mother s friend disappears from a mental hospital.",
                Price = 27.99m,
                Cost = 4.48m,
                PublishDate = new DateTime(2012, 10, 20),
                InventoryQuantity = 4,
                ReorderPoint = 3,
                BookStatus = false
            };
            b135.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b135);

            Book b136 = new Book()
            {
                Title = "Sweet Tooth",
                Authors = "Ian McEwan",
                BookNumber = 222136,
                Description = "A British woman working for MI5 in 1972 falls in love with a writer the service is clandestinely supporting.",
                Price = 26.95m,
                Cost = 16.17m,
                PublishDate = new DateTime(2012, 11, 17),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                BookStatus = false
            };
            b136.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b136);

            Book b137 = new Book()
            {
                Title = "Merry Christmas, Alex Cross",
                Authors = "James Patterson",
                BookNumber = 222137,
                Description = "Detective Alex Cross confronts both a hostage situation and a terrorist act at Christmas.",
                Price = 28.99m,
                Cost = 8.99m,
                PublishDate = new DateTime(2012, 11, 17),
                InventoryQuantity = 10,
                ReorderPoint = 7,
                BookStatus = false
            };
            b137.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b137);

            Book b138 = new Book()
            {
                Title = "Threat Vector",
                Authors = "Tom Clancy with Mark Greaney",
                BookNumber = 222138,
                Description = "As China threatens to invade Taiwan, the covert intelligence expert Jack Ryan Jr. aids his father s administration    but his agency is no longer secret.",
                Price = 28.95m,
                Cost = 10.71m,
                PublishDate = new DateTime(2012, 12, 8),
                InventoryQuantity = 12,
                ReorderPoint = 9,
                BookStatus = false
            };
            b138.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b138);

            Book b139 = new Book()
            {
                Title = "Two Graves",
                Authors = "Douglas Preston and Lincoln Child",
                BookNumber = 222139,
                Description = "Special Agent Aloysius Pendergast pursues a serial killer as well as his abducted wife.",
                Price = 26.99m,
                Cost = 13.23m,
                PublishDate = new DateTime(2012, 12, 15),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b139.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b139);

            Book b140 = new Book()
            {
                Title = "The Husband List",
                Authors = "Janet Evanovich and Dorien Kelly",
                BookNumber = 222140,
                Description = "In New York City in 1894, a wealthy young woman yearns for adventure and the love of an Irish-American with new money, rather than the titled Britons to whom her mother hopes to marry her off.",
                Price = 27.99m,
                Cost = 23.51m,
                PublishDate = new DateTime(2013, 1, 12),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                BookStatus = false
            };
            b140.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b140);

            Book b141 = new Book()
            {
                Title = "Collateral Damage",
                Authors = "Stuart Woods",
                BookNumber = 222141,
                Description = "Back in New York, the lawyer Stone Barrington joins his former partner Holly Barker in pursuing a dangerous case.",
                Price = 26.95m,
                Cost = 19.4m,
                PublishDate = new DateTime(2013, 1, 12),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                BookStatus = false
            };
            b141.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b141);

            Book b142 = new Book()
            {
                Title = "Kinsey And Me",
                Authors = "Sue Grafton",
                BookNumber = 222142,
                Description = "Stories about Grafton s character Kinsey Millhone as well as explorations of Grafton s own past.",
                Price = 27.95m,
                Cost = 25.43m,
                PublishDate = new DateTime(2013, 1, 12),
                InventoryQuantity = 10,
                ReorderPoint = 7,
                BookStatus = false
            };
            b142.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b142);

            Book b143 = new Book()
            {
                Title = "The Third Bullet",
                Authors = "Stephen Hunter",
                BookNumber = 222143,
                Description = "The veteran sniper Bob Lee Swagger investigates the assassination of John F. Kennedy. ",
                Price = 26.99m,
                Cost = 15.11m,
                PublishDate = new DateTime(2013, 1, 19),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                BookStatus = false
            };
            b143.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b143);

            Book b144 = new Book()
            {
                Title = "The Night Ranger",
                Authors = "Alex Berenson",
                BookNumber = 222144,
                Description = "The former C.I.A. operative John Wells pitches in when four young Americans who work at a refugee camp in Somalia are hijacked by bandits. ",
                Price = 27.95m,
                Cost = 6.71m,
                PublishDate = new DateTime(2013, 2, 16),
                InventoryQuantity = 4,
                ReorderPoint = 3,
                BookStatus = false
            };
            b144.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b144);

            Book b145 = new Book()
            {
                Title = "Sweet Tea Revenge",
                Authors = "Laura Childs",
                BookNumber = 222145,
                Description = "Theodosia Browning, owner of Indigo Tea Shop, is a bridesmaid in her friend's wedding. But the bridegroom is found dead on the big day.",
                Price = 29m,
                Cost = 13.92m,
                PublishDate = new DateTime(2013, 3, 9),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                BookStatus = false
            };
            b145.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b145);

            Book b146 = new Book()
            {
                Title = "The Last Threshold",
                Authors = "R A Salvatore",
                BookNumber = 222146,
                Description = "Book 4 of the fantasy Neverwinter Saga.",
                Price = 27.95m,
                Cost = 2.8m,
                PublishDate = new DateTime(2013, 3, 9),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                BookStatus = false
            };
            b146.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b146);

            Book b147 = new Book()
            {
                Title = "The Supremes At Earl's All-You-Can-Eat",
                Authors = "Edward Kelsey Moore",
                BookNumber = 222147,
                Description = "Four decades in the friendship of three middle-class black women in a small  southern Indiana town.",
                Price = 24.95m,
                Cost = 7.49m,
                PublishDate = new DateTime(2013, 3, 16),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                BookStatus = false
            };
            b147.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Humor");
            Books.Add(b147);

            Book b148 = new Book()
            {
                Title = "Lover At Last",
                Authors = "J R Ward",
                BookNumber = 222148,
                Description = "Book 11 of the Black Dagger Brotherhood series.",
                Price = 27.95m,
                Cost = 12.86m,
                PublishDate = new DateTime(2013, 3, 30),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                BookStatus = false
            };
            b148.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b148);

            Book b149 = new Book()
            {
                Title = "Leaving Everything Most Loved",
                Authors = "Jacqueline Winspear",
                BookNumber = 222149,
                Description = "In 1933, the private investigator Maisie Dobbs helps an Indian man whose sister s murder has been ignored by Scotland Yard.",
                Price = 26.99m,
                Cost = 2.97m,
                PublishDate = new DateTime(2013, 3, 30),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b149.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b149);

            Book b150 = new Book()
            {
                Title = "All That Is",
                Authors = "James Salter",
                BookNumber = 222150,
                Description = "A veteran makes a career in publishing in postwar New York and struggles to achieve romantic success.",
                Price = 26.95m,
                Cost = 14.01m,
                PublishDate = new DateTime(2013, 4, 6),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                BookStatus = false
            };
            b150.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b150);

            Book b151 = new Book()
            {
                Title = "Unintended Consequences",
                Authors = "Stuart Woods",
                BookNumber = 222151,
                Description = "The New York lawyer Stone Barrington discovers a shadowy network beneath the world of European wealth.",
                Price = 26.95m,
                Cost = 11.32m,
                PublishDate = new DateTime(2013, 4, 13),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                BookStatus = false
            };
            b151.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b151);

            Book b152 = new Book()
            {
                Title = "Nos4A2",
                Authors = "Joe Hill",
                BookNumber = 222152,
                Description = "In a creepy battle between real and imaginary worlds, a brave biker chick is pitted against a ghoulish villain who lures children to a place where it is always Christmas.",
                Price = 34m,
                Cost = 28.56m,
                PublishDate = new DateTime(2013, 5, 4),
                InventoryQuantity = 14,
                ReorderPoint = 9,
                BookStatus = false
            };
            b152.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b152);

            Book b153 = new Book()
            {
                Title = "Zero Hour",
                Authors = "Clive Cussler and Graham Brown",
                BookNumber = 222153,
                Description = "Kurt Austin, Joe Zavala and the rest of the Numa team search for a physicist's machine, buried in an ocean trench, that can cause deadly earthquakes in the 11th Numa Files novel.",
                Price = 28.95m,
                Cost = 25.19m,
                PublishDate = new DateTime(2013, 6, 1),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b153.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b153);

            Book b154 = new Book()
            {
                Title = "The Son",
                Authors = "Philipp Meyer",
                BookNumber = 222154,
                Description = "More than 150 years in a Texas family, from Comanche raids to the present, and its rise to money and power in the cattle and oil industries.",
                Price = 22m,
                Cost = 19.58m,
                PublishDate = new DateTime(2013, 6, 1),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                BookStatus = false
            };
            b154.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b154);

            Book b155 = new Book()
            {
                Title = "Red Sparrow",
                Authors = "Jason Matthews",
                BookNumber = 222155,
                Description = "A Russian intelligence officer trained in the art of seduction becomes entangled with a young C.I.A. officer.",
                Price = 26.95m,
                Cost = 11.59m,
                PublishDate = new DateTime(2013, 6, 8),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b155.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b155);

            Book b156 = new Book()
            {
                Title = "The Silver Star",
                Authors = "Jeannette Walls",
                BookNumber = 222156,
                Description = "When their irresponsible mother takes off, a 12-year-old California girl and her sister join the rest of their family in Virginia. ",
                Price = 23.95m,
                Cost = 8.38m,
                PublishDate = new DateTime(2013, 6, 15),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                BookStatus = false
            };
            b156.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b156);

            Book b157 = new Book()
            {
                Title = "Sisterland",
                Authors = "Curtis Sittenfeld",
                BookNumber = 222157,
                Description = "Twins with psychic abilities share a devastating secret.",
                Price = 27.99m,
                Cost = 20.71m,
                PublishDate = new DateTime(2013, 6, 29),
                InventoryQuantity = 10,
                ReorderPoint = 10,
                BookStatus = false
            };
            b157.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b157);

            Book b158 = new Book()
            {
                Title = "The English Girl",
                Authors = "Daniel Silva",
                BookNumber = 222158,
                Description = "Gabriel Allon, an art restorer and occasional spy for the Israeli secret service, steps in to help the British prime minister, whose lover has been kidnapped. ",
                Price = 17.95m,
                Cost = 2.33m,
                PublishDate = new DateTime(2013, 7, 20),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                BookStatus = false
            };
            b158.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b158);

            Book b159 = new Book()
            {
                Title = "Hunting Eve",
                Authors = "Iris Johansen",
                BookNumber = 222159,
                Description = "In the second book of a trilogy, the forensic sculptor Eve Duncan struggles to outwit a kidnapper in the Colorado wilderness.",
                Price = 35.99m,
                Cost = 28.07m,
                PublishDate = new DateTime(2013, 7, 20),
                InventoryQuantity = 5,
                ReorderPoint = 3,
                BookStatus = false
            };
            b159.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b159);

            Book b160 = new Book()
            {
                Title = "Light Of The World",
                Authors = "James Lee Burke",
                BookNumber = 222160,
                Description = "A savage killer follows the detective Dave Robicheaux and his family to a Montana ranch. ",
                Price = 32m,
                Cost = 10.88m,
                PublishDate = new DateTime(2013, 7, 27),
                InventoryQuantity = 7,
                ReorderPoint = 5,
                BookStatus = false
            };
            b160.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b160);

            Book b161 = new Book()
            {
                Title = "The Kill List",
                Authors = "Frederick Forsyth",
                BookNumber = 222161,
                Description = "An Arabic-speaking Marine major known as the Tracker pursues a terrorist who radicalizes young Muslims living abroad.",
                Price = 23.95m,
                Cost = 10.78m,
                PublishDate = new DateTime(2013, 8, 24),
                InventoryQuantity = 7,
                ReorderPoint = 2,
                BookStatus = false
            };
            b161.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b161);

            Book b162 = new Book()
            {
                Title = "Songs Of Willow Frost",
                Authors = "Jamie Ford",
                BookNumber = 222162,
                Description = "A 12-year-old Seattle orphan during the Depression becomes convinced that a movie star is really his vanished mother. ",
                Price = 18m,
                Cost = 6.3m,
                PublishDate = new DateTime(2013, 9, 14),
                InventoryQuantity = 10,
                ReorderPoint = 9,
                BookStatus = false
            };
            b162.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b162);

            Book b163 = new Book()
            {
                Title = "W Is For Wasted",
                Authors = "Sue Grafton",
                BookNumber = 222163,
                Description = "A homeless man inexplicably leaves $600,000 to Kinsey Millhone.",
                Price = 16m,
                Cost = 7.04m,
                PublishDate = new DateTime(2013, 9, 14),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                BookStatus = false
            };
            b163.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b163);

            Book b164 = new Book()
            {
                Title = "Deadly Heat",
                Authors = "Richard Castle",
                BookNumber = 222164,
                Description = "The N.Y.P.D. homicide detective Nikki Heat and the journalist Jameson Rook search for the former C.I.A. station chief who ordered her mother s execution.\nThe N.Y.P.D. homicide detective Nikki Heat and the journalist Jameson Rook search for the former C.I.A. station chief who ordered her mother s execution.",
                Price = 16m,
                Cost = 3.36m,
                PublishDate = new DateTime(2013, 9, 21),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b164.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b164);

            Book b165 = new Book()
            {
                Title = "Deadline",
                Authors = "Sandra Brown",
                BookNumber = 222165,
                Description = "A journalist who pursues a story about a former marine, the son of terrorists from 40 years ago,becomes a suspect in the death of his ex-wife.",
                Price = 16m,
                Cost = 4.48m,
                PublishDate = new DateTime(2013, 9, 28),
                InventoryQuantity = 7,
                ReorderPoint = 6,
                BookStatus = false
            };
            b165.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b165);

            Book b166 = new Book()
            {
                Title = "Silencing Eve",
                Authors = "Iris Johansen",
                BookNumber = 222166,
                Description = "The final book of a trilogy about the forensic sculptor Eve Duncan. ",
                Price = 19m,
                Cost = 7.03m,
                PublishDate = new DateTime(2013, 10, 5),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                BookStatus = false
            };
            b166.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b166);

            Book b167 = new Book()
            {
                Title = "Starry Night",
                Authors = "Debbie Macomber",
                BookNumber = 222167,
                Description = "At Christmastime, a big-city columnist sets out to interview a reclusive author in Alaska. ",
                Price = 24.95m,
                Cost = 17.96m,
                PublishDate = new DateTime(2013, 10, 12),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                BookStatus = false
            };
            b167.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b167);

            Book b168 = new Book()
            {
                Title = "Bridget Jones: Mad About The Boy",
                Authors = "Helen Fielding",
                BookNumber = 222168,
                Description = "Bridget, now 51 and a mother and widow, is once again looking for love.",
                Price = 29.95m,
                Cost = 18.57m,
                PublishDate = new DateTime(2013, 10, 19),
                InventoryQuantity = 6,
                ReorderPoint = 1,
                BookStatus = false
            };
            b168.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b168);

            Book b169 = new Book()
            {
                Title = "The Last Dark",
                Authors = "Stephen R Donaldson",
                BookNumber = 222169,
                Description = "The 10th and final installment of the sprawling fantasy series about Thomas Covenant the Unbeliever.",
                Price = 16m,
                Cost = 10.88m,
                PublishDate = new DateTime(2013, 10, 19),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                BookStatus = false
            };
            b169.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b169);

            Book b170 = new Book()
            {
                Title = "Aimless Love",
                Authors = "Billy Collins",
                BookNumber = 222170,
                Description = "More than 50 new poems as well as selections from previous books from the two-term poet laureate of the Untied States.",
                Price = 30.99m,
                Cost = 25.41m,
                PublishDate = new DateTime(2013, 10, 26),
                InventoryQuantity = 11,
                ReorderPoint = 7,
                BookStatus = false
            };
            b170.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Poetry");
            Books.Add(b170);

            Book b171 = new Book()
            {
                Title = "Tatiana",
                Authors = "Martin Cruz Smith",
                BookNumber = 222171,
                Description = "A dead translator s coded notebook may hold the key to the murders of a muckraking journalist and an oligarch in the former Soviet Union. Arkady Renko, a senior investigator in the Moscow prosecutor s office, is on the case.",
                Price = 20.99m,
                Cost = 18.68m,
                PublishDate = new DateTime(2013, 11, 16),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                BookStatus = false
            };
            b171.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b171);

            Book b172 = new Book()
            {
                Title = "Dust",
                Authors = "Patricia Cornwell",
                BookNumber = 222172,
                Description = "The murder of a computer engineer at M.I.T. leads the Massachusetts Chief Medical Examiner Kay Scarpetta in unexpected directions.",
                Price = 23.99m,
                Cost = 18.23m,
                PublishDate = new DateTime(2013, 11, 16),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b172.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b172);

            Book b173 = new Book()
            {
                Title = "The Supreme Macaroni Company",
                Authors = "Adriana Trigiani",
                BookNumber = 222173,
                Description = "Tensions arise when Valentine Roncalli, a Greenwich Village shoe designer, marries a handsome Italian, and the two must balance careers, countries and families. The final book in the Valentine trilogy. ",
                Price = 34.99m,
                Cost = 7m,
                PublishDate = new DateTime(2013, 11, 30),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                BookStatus = false
            };
            b173.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b173);

            Book b174 = new Book()
            {
                Title = "Innocence",
                Authors = "Dean Koontz",
                BookNumber = 222174,
                Description = "A grotesque man living in exile beneath the city encounters a teenage girl hiding from dangerous enemies.",
                Price = 21m,
                Cost = 13.44m,
                PublishDate = new DateTime(2013, 12, 14),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                BookStatus = false
            };
            b174.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Horror");
            Books.Add(b174);

            Book b175 = new Book()
            {
                Title = "Hunting Shadows",
                Authors = "Charles Todd",
                BookNumber = 222175,
                Description = "In the aftermath of World War I, a Scotland Yard detective with a heavy burden of guilt, investigates two murders in Cambridgeshire that may be linked.",
                Price = 32.99m,
                Cost = 18.47m,
                PublishDate = new DateTime(2014, 1, 25),
                InventoryQuantity = 7,
                ReorderPoint = 4,
                BookStatus = false
            };
            b175.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b175);

            Book b176 = new Book()
            {
                Title = "Confessions Of A Wild Child",
                Authors = "Jackie Collins",
                BookNumber = 222176,
                Description = "The early years of Collins s recurring character Lucky Santangelo.",
                Price = 30.95m,
                Cost = 17.95m,
                PublishDate = new DateTime(2014, 2, 8),
                InventoryQuantity = 10,
                ReorderPoint = 10,
                BookStatus = false
            };
            b176.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b176);

            Book b177 = new Book()
            {
                Title = "The Counterfeit Agent",
                Authors = "Alex Berenson",
                BookNumber = 222177,
                Description = "John Wells is sent on a mission to find the truth about a mysterious Iranian package said to be bound for the United States.",
                Price = 16.99m,
                Cost = 9.68m,
                PublishDate = new DateTime(2014, 2, 15),
                InventoryQuantity = 8,
                ReorderPoint = 8,
                BookStatus = false
            };
            b177.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b177);

            Book b178 = new Book()
            {
                Title = "Like A Mighty Army",
                Authors = "David Weber",
                BookNumber = 222178,
                Description = "In Book 7 of the Safehold science fiction series, the empire of Charis fights for self-determination. ",
                Price = 22m,
                Cost = 17.6m,
                PublishDate = new DateTime(2014, 2, 22),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                BookStatus = false
            };
            b178.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b178);

            Book b179 = new Book()
            {
                Title = "Cavendon Hall",
                Authors = "Barbara Taylor Bradford",
                BookNumber = 222179,
                Description = "In Edwardian England, an aristocratic family and the family who serve them share an ancestral home. ",
                Price = 26m,
                Cost = 8.06m,
                PublishDate = new DateTime(2014, 4, 5),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                BookStatus = false
            };
            b179.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b179);

            Book b180 = new Book()
            {
                Title = "Frog Music",
                Authors = "Emma Donoghue",
                BookNumber = 222180,
                Description = "A murder mystery set in San Francisco in 1876, when the city is in the grip of a smallpox epidemic and a heat wave.",
                Price = 16.95m,
                Cost = 4.92m,
                PublishDate = new DateTime(2014, 4, 5),
                InventoryQuantity = 10,
                ReorderPoint = 5,
                BookStatus = false
            };
            b180.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b180);

            Book b181 = new Book()
            {
                Title = "Destroyer Angel",
                Authors = "Nevada Barr",
                BookNumber = 222181,
                Description = "The National Park Service Ranger Anna Pigeon must rescue friends who are kidnapped while camping in Minnesota.",
                Price = 32m,
                Cost = 3.52m,
                PublishDate = new DateTime(2014, 4, 5),
                InventoryQuantity = 5,
                ReorderPoint = 3,
                BookStatus = false
            };
            b181.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b181);

            Book b182 = new Book()
            {
                Title = "Warriors",
                Authors = "Ted Bell",
                BookNumber = 222182,
                Description = "The counterspy Alex Hawke must rescue a kidnapped scientist. ",
                Price = 33.99m,
                Cost = 5.44m,
                PublishDate = new DateTime(2014, 4, 5),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                BookStatus = false
            };
            b182.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b182);

            Book b183 = new Book()
            {
                Title = "Live To See Tomorrow",
                Authors = "Iris Johansen",
                BookNumber = 222183,
                Description = "The C.I.A. operative Catherine Ling must spearhead the rescue of an American journalist kidnapped in Tibet. ",
                Price = 34m,
                Cost = 6.46m,
                PublishDate = new DateTime(2014, 5, 3),
                InventoryQuantity = 9,
                ReorderPoint = 5,
                BookStatus = false
            };
            b183.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b183);

            Book b184 = new Book()
            {
                Title = "All The Light We Cannot See",
                Authors = "Anthony Doerr",
                BookNumber = 222184,
                Description = "The lives of a blind French girl and a gadget-obsessed German boy before and during World War II, when their paths eventually cross. ",
                Price = 23.95m,
                Cost = 10.3m,
                PublishDate = new DateTime(2014, 5, 10),
                InventoryQuantity = 8,
                ReorderPoint = 6,
                BookStatus = false
            };
            b184.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b184);

            Book b185 = new Book()
            {
                Title = "The Kraken Project",
                Authors = "Douglas Preston",
                BookNumber = 222185,
                Description = "The former C.I.A. agent Wyman Ford must stop Dorothy, a powerful artificial intelligence that has gone rogue.",
                Price = 35m,
                Cost = 28m,
                PublishDate = new DateTime(2014, 5, 17),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b185.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b185);

            Book b186 = new Book()
            {
                Title = "The Vacationers",
                Authors = "Emma Straub",
                BookNumber = 222186,
                Description = "Well-heeled New Yorkers and their friends spend two weeks in Majorca, a time when rivalries and secrets come to light.",
                Price = 33m,
                Cost = 5.94m,
                PublishDate = new DateTime(2014, 5, 31),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b186.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b186);

            Book b187 = new Book()
            {
                Title = "The Hurricane Sisters",
                Authors = "Dorothea Benton Frank",
                BookNumber = 222187,
                Description = "Three generations of women endure a stormy summer in South Carolina's Lowcountry.",
                Price = 16m,
                Cost = 9.6m,
                PublishDate = new DateTime(2014, 6, 7),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                BookStatus = false
            };
            b187.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b187);

            Book b188 = new Book()
            {
                Title = "The Matchmaker",
                Authors = "Elin Hilderbrand",
                BookNumber = 222188,
                Description = "A Nantucket resident s life is shaken by a diagnosis and the return to the island of her high school sweetheart. ",
                Price = 25m,
                Cost = 11m,
                PublishDate = new DateTime(2014, 6, 14),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b188.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b188);

            Book b189 = new Book()
            {
                Title = "Terminal City",
                Authors = "Linda Fairstein",
                BookNumber = 222189,
                Description = "Alexandra Cooper, a Manhattan assistant district attorney, hunts for a killer in Grand Central s underground tunnels.",
                Price = 32.95m,
                Cost = 16.48m,
                PublishDate = new DateTime(2014, 6, 21),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                BookStatus = false
            };
            b189.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b189);

            Book b190 = new Book()
            {
                Title = "Landline",
                Authors = "Rainbow Rowell",
                BookNumber = 222190,
                Description = "A woman in a troubled marriage finds a way to communicate with her husband in the past. ",
                Price = 29m,
                Cost = 5.8m,
                PublishDate = new DateTime(2014, 7, 12),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                BookStatus = false
            };
            b190.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b190);

            Book b191 = new Book()
            {
                Title = "The Book Of Life",
                Authors = "Deborah Harkness",
                BookNumber = 222191,
                Description = "In the conclusion to the All Souls trilogy, the Oxford scholar/witch Diana Bishop and the vampire geneticist Matthew Clairmont return from Elizabethan London to the present.",
                Price = 27.95m,
                Cost = 8.66m,
                PublishDate = new DateTime(2014, 7, 19),
                InventoryQuantity = 9,
                ReorderPoint = 9,
                BookStatus = false
            };
            b191.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b191);

            Book b192 = new Book()
            {
                Title = "Magic Breaks",
                Authors = "Ilona Andrews",
                BookNumber = 222192,
                Description = "In the seventh Kate Daniels novel, Kate deals with paranormal politics in Atlanta as she prepares the Pack for an attack.",
                Price = 32m,
                Cost = 16.96m,
                PublishDate = new DateTime(2014, 8, 2),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                BookStatus = false
            };
            b192.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b192);

            Book b193 = new Book()
            {
                Title = "Big Little Lies",
                Authors = "Liane Moriarty",
                BookNumber = 222193,
                Description = "Who will end up dead, and how, when three mothers with children in the same school become friends?",
                Price = 17m,
                Cost = 5.1m,
                PublishDate = new DateTime(2014, 8, 2),
                InventoryQuantity = 11,
                ReorderPoint = 7,
                BookStatus = false
            };
            b193.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b193);

            Book b194 = new Book()
            {
                Title = "Dark Skye",
                Authors = "Kresley Cole",
                BookNumber = 222194,
                Description = "Will a scarred warrior and the beautiful sorceress with the power to heal him overcome the challenges of their warring families and the chaotic battles around them? Book 15 in the Immortals After Dark series.",
                Price = 20m,
                Cost = 4m,
                PublishDate = new DateTime(2014, 8, 9),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b194.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b194);

            Book b195 = new Book()
            {
                Title = "The Magician's Land",
                Authors = "Lev Grossman",
                BookNumber = 222195,
                Description = "Quentin, an exiled magician, tries a risky heist in the final installment of a trilogy.",
                Price = 28.95m,
                Cost = 5.5m,
                PublishDate = new DateTime(2014, 8, 9),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                BookStatus = false
            };
            b195.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b195);

            Book b196 = new Book()
            {
                Title = "Mean Streak",
                Authors = "Sandra Brown",
                BookNumber = 222196,
                Description = "A North Carolina pediatrician is held captive by a mysterious man who forces her to question her life. ",
                Price = 29.95m,
                Cost = 26.66m,
                PublishDate = new DateTime(2014, 8, 23),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                BookStatus = false
            };
            b196.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b196);

            Book b197 = new Book()
            {
                Title = "The King's Curse",
                Authors = "Philippa Gregory",
                BookNumber = 222197,
                Description = "As chief lady-in-waiting to Katherine of Aragon, Margaret Pole is torn between the queen and her husband, Henry VIII.",
                Price = 18.99m,
                Cost = 3.99m,
                PublishDate = new DateTime(2014, 9, 13),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b197.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b197);

            Book b198 = new Book()
            {
                Title = "Bones Never Lie",
                Authors = "Kathy Reichs",
                BookNumber = 222198,
                Description = "A child murderer who eluded capture years ago has resurfaced, giving the forensic anthropologist Temperance Brennan another chance to stop her.",
                Price = 14.95m,
                Cost = 9.42m,
                PublishDate = new DateTime(2014, 9, 27),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                BookStatus = false
            };
            b198.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b198);

            Book b199 = new Book()
            {
                Title = "Nora Webster",
                Authors = "Colm Toibin",
                BookNumber = 222199,
                Description = "In the 1970s, an Irish widow struggles to find her identity.",
                Price = 30.99m,
                Cost = 4.65m,
                PublishDate = new DateTime(2014, 10, 11),
                InventoryQuantity = 3,
                ReorderPoint = 2,
                BookStatus = false
            };
            b199.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b199);

            Book b200 = new Book()
            {
                Title = "Winter Street",
                Authors = "Elin Hilderbrand",
                BookNumber = 222200,
                Description = "Complications ensue when the owner of Nantucket s Winter Street Inn gathers his four children and their families for Christmas.",
                Price = 20.95m,
                Cost = 2.3m,
                PublishDate = new DateTime(2014, 10, 18),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                BookStatus = false
            };
            b200.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b200);

            Book b201 = new Book()
            {
                Title = "The Narrow Road To The Deep North",
                Authors = "Richard Flanagan",
                BookNumber = 222201,
                Description = "The hero of the Man Booker Prize-winning novel about love, good and evil is a P.O.W. working on the Thai-Burma Death Railway during World War II.",
                Price = 34m,
                Cost = 20.74m,
                PublishDate = new DateTime(2014, 10, 18),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                BookStatus = false
            };
            b201.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b201);

            Book b202 = new Book()
            {
                Title = "The Handsome Man's De Luxe Caf ",
                Authors = "Alexander McCall Smith",
                BookNumber = 222202,
                Description = "The 15th book in the No. 1 Ladies  Detective Agency series.",
                Price = 25.95m,
                Cost = 17.91m,
                PublishDate = new DateTime(2014, 11, 1),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                BookStatus = false
            };
            b202.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b202);

            Book b203 = new Book()
            {
                Title = "The Burning Room",
                Authors = "Michael Connelly",
                BookNumber = 222203,
                Description = "The Los Angeles detective Harry Bosch and his new partner investigate two long-unsolved cases.",
                Price = 36.99m,
                Cost = 17.39m,
                PublishDate = new DateTime(2014, 11, 8),
                InventoryQuantity = 9,
                ReorderPoint = 7,
                BookStatus = false
            };
            b203.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b203);

            Book b204 = new Book()
            {
                Title = "The Job",
                Authors = "Janet Evanovich and Lee Goldberg",
                BookNumber = 222204,
                Description = "The F.B.I. special agent Kate O Hare works with Nicolas Fox, a handsome con man, to pursue a drug kingpin.",
                Price = 28.95m,
                Cost = 20.27m,
                PublishDate = new DateTime(2014, 11, 22),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b204.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b204);

            Book b205 = new Book()
            {
                Title = "The Cinderella Murder",
                Authors = "Mary Higgins Clark and Alafair Burke",
                BookNumber = 222205,
                Description = "A  TV producer plans a show about a cold case   the murder of a U.C.L.A. student who was found with one shoe missing.",
                Price = 25.95m,
                Cost = 5.97m,
                PublishDate = new DateTime(2014, 11, 22),
                InventoryQuantity = 4,
                ReorderPoint = 1,
                BookStatus = false
            };
            b205.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b205);

            Book b206 = new Book()
            {
                Title = "The Mistletoe Promise",
                Authors = "Richard Paul Evans",
                BookNumber = 222206,
                Description = "A divorced woman enters into a contract with a strange man to pretend to be a couple until Christmas.",
                Price = 23.99m,
                Cost = 12.23m,
                PublishDate = new DateTime(2014, 11, 22),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                BookStatus = false
            };
            b206.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b206);

            Book b207 = new Book()
            {
                Title = "Hope To Die",
                Authors = "James Patterson",
                BookNumber = 222207,
                Description = "Detective Alex Cross s family is kidnapped by a madman who wants to turn Cross into a perfect killer.",
                Price = 31.95m,
                Cost = 3.51m,
                PublishDate = new DateTime(2014, 11, 29),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                BookStatus = false
            };
            b207.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b207);

            Book b208 = new Book()
            {
                Title = "Trust No One",
                Authors = "Jayne Ann Krentz",
                BookNumber = 222208,
                Description = "A woman who is being stalked is aided by an unlikely ally.",
                Price = 17.95m,
                Cost = 12.39m,
                PublishDate = new DateTime(2015, 1, 10),
                InventoryQuantity = 10,
                ReorderPoint = 9,
                BookStatus = false
            };
            b208.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b208);

            Book b209 = new Book()
            {
                Title = "Private Vegas",
                Authors = "James Patterson and Maxine Paetro",
                BookNumber = 222209,
                Description = "Jack Morgan, the head of an investigative firm, uncovers a murder ring in Las Vegas.",
                Price = 32m,
                Cost = 25.92m,
                PublishDate = new DateTime(2015, 1, 31),
                InventoryQuantity = 11,
                ReorderPoint = 8,
                BookStatus = false
            };
            b209.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b209);

            Book b210 = new Book()
            {
                Title = "Trigger Warning",
                Authors = "Neil Gaiman",
                BookNumber = 222210,
                Description = "Stories and poems about the power of imagination.",
                Price = 17.95m,
                Cost = 10.41m,
                PublishDate = new DateTime(2015, 2, 7),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                BookStatus = false
            };
            b210.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Poetry");
            Books.Add(b210);

            Book b211 = new Book()
            {
                Title = "Twelve Days",
                Authors = "Alex Berenson",
                BookNumber = 222211,
                Description = "The former C.I.A. operative John Wells discovers a plot to trick the president into invading Iran.",
                Price = 25m,
                Cost = 18.5m,
                PublishDate = new DateTime(2015, 2, 14),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                BookStatus = false
            };
            b211.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b211);

            Book b212 = new Book()
            {
                Title = "A Spool Of Blue Thread",
                Authors = "Anne Tyler",
                BookNumber = 222212,
                Description = "Four generations of a family are drawn to a house in the Baltimore suburbs.",
                Price = 15.95m,
                Cost = 1.75m,
                PublishDate = new DateTime(2015, 2, 14),
                InventoryQuantity = 10,
                ReorderPoint = 10,
                BookStatus = false
            };
            b212.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b212);

            Book b213 = new Book()
            {
                Title = "Holy Cow",
                Authors = "David Duchovny",
                BookNumber = 222213,
                Description = "A light-hearted fable by the actor.",
                Price = 19.99m,
                Cost = 11.79m,
                PublishDate = new DateTime(2015, 2, 14),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                BookStatus = false
            };
            b213.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Humor");
            Books.Add(b213);

            Book b214 = new Book()
            {
                Title = "Prodigal Son",
                Authors = "Danielle Steel",
                BookNumber = 222214,
                Description = "Twins, one good and one bad, reunite after 20 years when one of them returns to their hometown. But it is no longer clear who the good and who the bad one is.",
                Price = 18.95m,
                Cost = 9.1m,
                PublishDate = new DateTime(2015, 2, 28),
                InventoryQuantity = 3,
                ReorderPoint = 2,
                BookStatus = false
            };
            b214.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b214);

            Book b215 = new Book()
            {
                Title = "Last One Home",
                Authors = "Debbie Macomber",
                BookNumber = 222215,
                Description = "Three estranged sisters work to resolve their differences",
                Price = 20m,
                Cost = 15.6m,
                PublishDate = new DateTime(2015, 3, 14),
                InventoryQuantity = 5,
                ReorderPoint = 5,
                BookStatus = false
            };
            b215.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b215);

            Book b216 = new Book()
            {
                Title = "The Lady From Zagreb",
                Authors = "Philip Kerr",
                BookNumber = 222216,
                Description = "The former Berlin homicide detective Bernie Gunther is sent to Croatia by Joseph Goebbels to persuade a film star to appear in a movie.",
                Price = 20.95m,
                Cost = 19.27m,
                PublishDate = new DateTime(2015, 4, 11),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                BookStatus = false
            };
            b216.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b216);

            Book b217 = new Book()
            {
                Title = "14Th Deadly Sin",
                Authors = "James Patterson and Maxine Paetro",
                BookNumber = 222217,
                Description = "A video of a shocking crime surfaces, casting suspicion on a San Francisco detective's colleagues.",
                Price = 24.99m,
                Cost = 6.25m,
                PublishDate = new DateTime(2015, 5, 9),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b217.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b217);

            Book b218 = new Book()
            {
                Title = "The Fateful Lightning",
                Authors = "Jeff Shaara",
                BookNumber = 222218,
                Description = "The fourth and final volume in a series of Civil War novels describes the war's last months through multiple perspectives.",
                Price = 28.95m,
                Cost = 5.5m,
                PublishDate = new DateTime(2015, 6, 6),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                BookStatus = false
            };
            b218.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b218);

            Book b219 = new Book()
            {
                Title = "In The Unlikely Event",
                Authors = "Judy Blume",
                BookNumber = 222219,
                Description = "Secrets are revealed and love stories play out against the backdrop of a series of panic-inducing plane crashes in 1950s New Jersey.",
                Price = 18.95m,
                Cost = 16.87m,
                PublishDate = new DateTime(2015, 6, 6),
                InventoryQuantity = 12,
                ReorderPoint = 9,
                BookStatus = false
            };
            b219.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b219);

            Book b220 = new Book()
            {
                Title = "The Little Paris Bookshop",
                Authors = "Nina George",
                BookNumber = 222220,
                Description = "A bookseller with a knack for finding just the right book for making others feel better embarks on a journey in pursuit of his own happiness.",
                Price = 34m,
                Cost = 5.78m,
                PublishDate = new DateTime(2015, 7, 4),
                InventoryQuantity = 11,
                ReorderPoint = 6,
                BookStatus = false
            };
            b220.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b220);

            Book b221 = new Book()
            {
                Title = "Friction",
                Authors = "Sandra Brown",
                BookNumber = 222221,
                Description = "A Texas Ranger fights for custody of his daughter amid complications stemming from his attraction to the judge.",
                Price = 18.99m,
                Cost = 2.85m,
                PublishDate = new DateTime(2015, 8, 22),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                BookStatus = false
            };
            b221.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b221);

            Book b222 = new Book()
            {
                Title = "The Solomon Curse",
                Authors = "Clive Cussler and Russell Blake",
                BookNumber = 222222,
                Description = "The wealthy couple Sam and Remi Fargo investigate a dangerous legend in the Solomon Islands.",
                Price = 26.95m,
                Cost = 18.06m,
                PublishDate = new DateTime(2015, 9, 5),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                BookStatus = false
            };
            b222.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b222);

            Book b223 = new Book()
            {
                Title = "One Year After",
                Authors = "William R Forstchen",
                BookNumber = 222223,
                Description = "A New Regime imposes tyranny in the aftermath of a nuclear attack.",
                Price = 23.95m,
                Cost = 3.59m,
                PublishDate = new DateTime(2015, 9, 19),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                BookStatus = false
            };
            b223.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b223);

            Book b224 = new Book()
            {
                Title = "The Murder House",
                Authors = "James Patterson and David Ellis",
                BookNumber = 222224,
                Description = "When bodies are found at a Hamptons estate where a series of grisly murders once occurred, a local detective and former New York City cop investigates.",
                Price = 23.95m,
                Cost = 17.72m,
                PublishDate = new DateTime(2015, 10, 3),
                InventoryQuantity = 6,
                ReorderPoint = 6,
                BookStatus = false
            };
            b224.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b224);

            Book b225 = new Book()
            {
                Title = "All The Stars In The Heavens",
                Authors = "Adriana Trigiani",
                BookNumber = 222225,
                Description = "A fictional treatment of the life of the actress Loretta Young focuses on her rumored affair with the married Clark Gable and her subsequent pregnancy.",
                Price = 26.95m,
                Cost = 19.94m,
                PublishDate = new DateTime(2015, 10, 17),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                BookStatus = false
            };
            b225.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b225);

            Book b226 = new Book()
            {
                Title = "The Lake House",
                Authors = "Kate Morton",
                BookNumber = 222226,
                Description = "A London detective investigating a missing-persons case becomes curious about an unsolved 1933 kidnapping in Cornwall.",
                Price = 16.95m,
                Cost = 10.17m,
                PublishDate = new DateTime(2015, 10, 24),
                InventoryQuantity = 12,
                ReorderPoint = 8,
                BookStatus = false
            };
            b226.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b226);

            Book b227 = new Book()
            {
                Title = "The Japanese Lover",
                Authors = "Isabel Allende",
                BookNumber = 222227,
                Description = "A young refugee from the Nazis and the son of her family s Japanese gardener must hide their love, although it lasts a lifetime.",
                Price = 33.99m,
                Cost = 8.16m,
                PublishDate = new DateTime(2015, 11, 7),
                InventoryQuantity = 7,
                ReorderPoint = 3,
                BookStatus = false
            };
            b227.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b227);

            Book b228 = new Book()
            {
                Title = "The Promise",
                Authors = "Robert Crais",
                BookNumber = 222228,
                Description = "The Los Angeles P.I. Elvis Cole joins forces with the K-9 officer Scott James of the L.A.P.D. and his German shepherd, Maggie, as well as his partner, Joe Pike, to foil a criminal mastermind.",
                Price = 27.95m,
                Cost = 18.73m,
                PublishDate = new DateTime(2015, 11, 14),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                BookStatus = false
            };
            b228.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b228);

            Book b229 = new Book()
            {
                Title = "The Pharaoh's Secret",
                Authors = "Clive Cussler and Graham Brown",
                BookNumber = 222229,
                Description = "Kurt Austin and Joe Zavala must save the NUMA crew from a mysterious toxin deployed by a villain who wants to build a new Egyptian empire.",
                Price = 31.95m,
                Cost = 12.46m,
                PublishDate = new DateTime(2015, 11, 21),
                InventoryQuantity = 3,
                ReorderPoint = 2,
                BookStatus = false
            };
            b229.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b229);

            Book b230 = new Book()
            {
                Title = "The Guilty",
                Authors = "David Baldacci",
                BookNumber = 222230,
                Description = "The government hit man Will Robie investigates murder charges against his estranged father in their Mississippi hometown.",
                Price = 19.95m,
                Cost = 17.16m,
                PublishDate = new DateTime(2015, 11, 21),
                InventoryQuantity = 3,
                ReorderPoint = 3,
                BookStatus = false
            };
            b230.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b230);

            Book b231 = new Book()
            {
                Title = "The Mistletoe Inn",
                Authors = "Richard Paul Evans",
                BookNumber = 222231,
                Description = "An aspiring romance writer with a broken heart meets a complicated man at a Christmas writers  retreat.",
                Price = 36.95m,
                Cost = 11.09m,
                PublishDate = new DateTime(2015, 11, 21),
                InventoryQuantity = 10,
                ReorderPoint = 10,
                BookStatus = false
            };
            b231.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b231);

            Book b232 = new Book()
            {
                Title = "Find Her",
                Authors = "Lisa Gardner",
                BookNumber = 222232,
                Description = "The Boston detective D.D. Warren hunts for a missing woman who was kidnapped and abused as a college student and may have become a vigilante.",
                Price = 28.95m,
                Cost = 10.71m,
                PublishDate = new DateTime(2016, 2, 13),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b232.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b232);

            Book b233 = new Book()
            {
                Title = "Wedding Cake Murder",
                Authors = "Joanne Fluke",
                BookNumber = 222233,
                Description = "The Lake Eden, Minn., baker Hannah Swensen is about to get married, but first she must solve the murder of a visiting celebrity chef. Recipes included.",
                Price = 23.95m,
                Cost = 17.72m,
                PublishDate = new DateTime(2016, 2, 27),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b233.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b233);

            Book b234 = new Book()
            {
                Title = "The Gangster",
                Authors = "Clive Cussler and Justin Scott",
                BookNumber = 222234,
                Description = "n the ninth book in this series, set in 1906, the New York detective Isaac Bell contends with a crime boss passing as a respectable businessman and a tycoon s plot against President Theodore Roosevelt.",
                Price = 30.95m,
                Cost = 7.12m,
                PublishDate = new DateTime(2016, 3, 5),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                BookStatus = false
            };
            b234.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b234);

            Book b235 = new Book()
            {
                Title = "Fool Me Once",
                Authors = "Harlan Coben",
                BookNumber = 222235,
                Description = "A retired Army helicopter pilot faces combat-related nightmares and mysteries concerning the deaths of her husband and sister.",
                Price = 24.95m,
                Cost = 12.72m,
                PublishDate = new DateTime(2016, 3, 26),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                BookStatus = false
            };
            b235.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b235);

            Book b236 = new Book()
            {
                Title = "Robert B. Parker's Slow Burn",
                Authors = "Ace Atkins",
                BookNumber = 222236,
                Description = "Spenser is back, leaving a trail of antagonism as he investigates a series of suspicious Boston fires.",
                Price = 22.99m,
                Cost = 10.58m,
                PublishDate = new DateTime(2016, 5, 7),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b236.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b236);

            Book b237 = new Book()
            {
                Title = "Zero K",
                Authors = "Don DeLillo",
                BookNumber = 222237,
                Description = "A billionaire and his son meet at a remote desert compound dedicated to preserving bodies until they can be returned to life in the future.",
                Price = 20m,
                Cost = 15.2m,
                PublishDate = new DateTime(2016, 5, 7),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                BookStatus = false
            };
            b237.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b237);

            Book b238 = new Book()
            {
                Title = "The Second Life Of Nick Mason",
                Authors = "Steve Hamilton",
                BookNumber = 222238,
                Description = "A deal with a fellow inmate, a crime boss, springs Nick Mason from prison, but he must become an assassin.",
                Price = 19.99m,
                Cost = 3.2m,
                PublishDate = new DateTime(2016, 5, 21),
                InventoryQuantity = 5,
                ReorderPoint = 2,
                BookStatus = false
            };
            b238.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b238);

            Book b239 = new Book()
            {
                Title = "The Weekenders",
                Authors = "Mary Kay Andrews",
                BookNumber = 222239,
                Description = "On the North Carolina island of Belle Isle, a woman investigates her husband s shady financial affairs after his mysterious death.",
                Price = 20.95m,
                Cost = 12.78m,
                PublishDate = new DateTime(2016, 5, 21),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                BookStatus = false
            };
            b239.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b239);

            Book b240 = new Book()
            {
                Title = "The Emperor's Revenge",
                Authors = "Clive Cussler and Boyd Morrison",
                BookNumber = 222240,
                Description = "Juan Cabrillo teams up with a former C.I.A. colleague to thwart a plan involving the death of millions and international economic meltdown.",
                Price = 27.99m,
                Cost = 20.43m,
                PublishDate = new DateTime(2016, 6, 4),
                InventoryQuantity = 3,
                ReorderPoint = 1,
                BookStatus = false
            };
            b240.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b240);

            Book b241 = new Book()
            {
                Title = "Homegoing",
                Authors = "Yaa Gyasi",
                BookNumber = 222241,
                Description = "This Ghanaian-American writer s first novel traces the lives in West Africa and America of seven generations of the descendants of two half sisters.",
                Price = 26.95m,
                Cost = 2.7m,
                PublishDate = new DateTime(2016, 6, 11),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                BookStatus = false
            };
            b241.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b241);

            Book b242 = new Book()
            {
                Title = "Here's To Us",
                Authors = "Elin Hilderbrand",
                BookNumber = 222242,
                Description = "Sparks fly as a celebrity chef s ex-wives pile into a small cabin in Nantucket to join his widow for the reading of his will.",
                Price = 26.95m,
                Cost = 8.62m,
                PublishDate = new DateTime(2016, 6, 18),
                InventoryQuantity = 13,
                ReorderPoint = 9,
                BookStatus = false
            };
            b242.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b242);

            Book b243 = new Book()
            {
                Title = "The Pursuit",
                Authors = "Janet Evanovich and Lee Goldberg",
                BookNumber = 222243,
                Description = "The F.B.I. agent Kate O Hare and her con man partner, Nick Fox, face off against a dangerous ex-Serbian military officer.",
                Price = 25.99m,
                Cost = 18.45m,
                PublishDate = new DateTime(2016, 6, 25),
                InventoryQuantity = 8,
                ReorderPoint = 5,
                BookStatus = false
            };
            b243.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b243);

            Book b244 = new Book()
            {
                Title = "Among The Wicked",
                Authors = "Linda Castillo",
                BookNumber = 222244,
                Description = "Chief of Police Kate Burkholder goes undercover as a widow in a reclusive Amish community to investigate a girl's death.",
                Price = 24m,
                Cost = 6.72m,
                PublishDate = new DateTime(2016, 7, 16),
                InventoryQuantity = 10,
                ReorderPoint = 9,
                BookStatus = false
            };
            b244.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b244);

            Book b245 = new Book()
            {
                Title = "The Woman In Cabin 10",
                Authors = "Ruth Ware",
                BookNumber = 222245,
                Description = "A travel writer on a cruise is certain she has heard a body thrown overboard, but no one believes her.",
                Price = 32m,
                Cost = 3.52m,
                PublishDate = new DateTime(2016, 7, 23),
                InventoryQuantity = 9,
                ReorderPoint = 7,
                BookStatus = false
            };
            b245.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b245);

            Book b246 = new Book()
            {
                Title = "Truly Madly Guilty",
                Authors = "Liane Moriarty",
                BookNumber = 222246,
                Description = "Tense turning points for three couples at a backyard barbecue gone wrong.",
                Price = 14.99m,
                Cost = 10.04m,
                PublishDate = new DateTime(2016, 7, 30),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                BookStatus = false
            };
            b246.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b246);

            Book b247 = new Book()
            {
                Title = "The Underground Railroad",
                Authors = "Colson Whitehead",
                BookNumber = 222247,
                Description = "A slave girl heads toward freedom on the network, envisioned as actual tracks and tunnels.",
                Price = 32m,
                Cost = 3.2m,
                PublishDate = new DateTime(2016, 8, 6),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                BookStatus = false
            };
            b247.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b247);

            Book b248 = new Book()
            {
                Title = "Dragonmark",
                Authors = "Sherrilyn Kenyon",
                BookNumber = 222248,
                Description = "The first book of a new trilogy featuring Illarion, a dragon made into a human  against his will. A Dark-Hunter novel.",
                Price = 29.95m,
                Cost = 3.29m,
                PublishDate = new DateTime(2016, 8, 6),
                InventoryQuantity = 10,
                ReorderPoint = 7,
                BookStatus = false
            };
            b248.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b248);

            Book b249 = new Book()
            {
                Title = "Another Brooklyn",
                Authors = "Jacqueline Woodson",
                BookNumber = 222249,
                Description = "An adult novel by an award-winning children's book author centers on memories of growing up and the close friendship of four girls.",
                Price = 36m,
                Cost = 9.72m,
                PublishDate = new DateTime(2016, 8, 13),
                InventoryQuantity = 12,
                ReorderPoint = 10,
                BookStatus = false
            };
            b249.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b249);

            Book b250 = new Book()
            {
                Title = "Sting",
                Authors = "Sandra Brown",
                BookNumber = 222250,
                Description = "A hired killer and a woman he kidnapped join forces to elude the F.B.I. agents and others who are searching for her corrupt brother.",
                Price = 27m,
                Cost = 8.91m,
                PublishDate = new DateTime(2016, 8, 20),
                InventoryQuantity = 9,
                ReorderPoint = 4,
                BookStatus = false
            };
            b250.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b250);

            Book b251 = new Book()
            {
                Title = "The Kept Woman",
                Authors = "Karin Slaughter",
                BookNumber = 222251,
                Description = "Will Trent of the Georgia Bureau of Investigation and his lover, the medical examiner Sara Linton, pursue a case involving a dirty Atlanta cop.",
                Price = 16.95m,
                Cost = 15.26m,
                PublishDate = new DateTime(2016, 9, 24),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                BookStatus = false
            };
            b251.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b251);

            Book b252 = new Book()
            {
                Title = "Twelve Days Of Christmas",
                Authors = "Debbie Macomber",
                BookNumber = 222252,
                Description = "A woman starts a blog about her attempt to reach out to a grumpy neighbor at Christmastime, and finds herself falling for him.",
                Price = 25.99m,
                Cost = 23.13m,
                PublishDate = new DateTime(2016, 10, 8),
                InventoryQuantity = 11,
                ReorderPoint = 10,
                BookStatus = false
            };
            b252.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b252);

            Book b253 = new Book()
            {
                Title = "Winter Storms",
                Authors = "Elin Hilderbrand",
                BookNumber = 222253,
                Description = "In the final book of the Winter Street trilogy, a huge snowstorm bearing down on Nantucket threatens the Quinn family s Christmas, after a year of significant events.",
                Price = 29m,
                Cost = 24.94m,
                PublishDate = new DateTime(2016, 10, 8),
                InventoryQuantity = 7,
                ReorderPoint = 4,
                BookStatus = false
            };
            b253.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b253);

            Book b254 = new Book()
            {
                Title = "Vince Flynn: Order To Kill",
                Authors = "Kyle Mills",
                BookNumber = 222254,
                Description = "Flynn s character, the C.I.A. operative Mitch Rapp, uncovers a dangerous Russian plot. Flynn died in 2013.",
                Price = 16.95m,
                Cost = 13.73m,
                PublishDate = new DateTime(2016, 10, 15),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                BookStatus = false
            };
            b254.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b254);

            Book b255 = new Book()
            {
                Title = "Crimson Death",
                Authors = "Laurell K Hamilton",
                BookNumber = 222255,
                Description = "The vampire hunter Anita Blake, her friend Edward and her servant Damian travel to Ireland to battle an unusual vampire infestation.",
                Price = 16.99m,
                Cost = 7.65m,
                PublishDate = new DateTime(2016, 10, 15),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b255.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b255);

            Book b256 = new Book()
            {
                Title = "The Obsidian Chamber",
                Authors = "Douglas Preston and Lincoln Child",
                BookNumber = 222256,
                Description = "While the F.B.I. agent Aloysius Pendergast is believed dead, his ward is kidnapped.",
                Price = 17m,
                Cost = 3.57m,
                PublishDate = new DateTime(2016, 10, 22),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                BookStatus = false
            };
            b256.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b256);

            Book b257 = new Book()
            {
                Title = "Escape Clause",
                Authors = "John Sandford",
                BookNumber = 222257,
                Description = "Virgil Flowers of the Minnesota Bureau of Criminal Apprehension must deal with the theft of tigers from the local zoo.",
                Price = 35.95m,
                Cost = 7.19m,
                PublishDate = new DateTime(2016, 10, 22),
                InventoryQuantity = 5,
                ReorderPoint = 4,
                BookStatus = false
            };
            b257.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b257);

            Book b258 = new Book()
            {
                Title = "The Whistler",
                Authors = "John Grisham",
                BookNumber = 222258,
                Description = "A whistleblower alerts a Florida investigator to judicial corruption involving the Mob and Indian casinos.",
                Price = 26.95m,
                Cost = 13.48m,
                PublishDate = new DateTime(2016, 10, 29),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                BookStatus = false
            };
            b258.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b258);

            Book b259 = new Book()
            {
                Title = "The Whole Town's Talking",
                Authors = "Fannie Flagg",
                BookNumber = 222259,
                Description = "A century of life in small-town Elmwood Springs, Mo.",
                Price = 31.99m,
                Cost = 21.11m,
                PublishDate = new DateTime(2016, 12, 3),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b259.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b259);

            Book b260 = new Book()
            {
                Title = "Rogue One: A Star Wars Story",
                Authors = "Alexander Freed",
                BookNumber = 222260,
                Description = "A novelization of the new movie, including additional scenes.",
                Price = 33.95m,
                Cost = 23.77m,
                PublishDate = new DateTime(2016, 12, 24),
                InventoryQuantity = 7,
                ReorderPoint = 6,
                BookStatus = false
            };
            b260.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b260);

            Book b261 = new Book()
            {
                Title = "The Mistress",
                Authors = "Danielle Steel",
                BookNumber = 222261,
                Description = "The beautiful mistress of a Russian oligarch falls in love with an artist and yearns for freedom.",
                Price = 36.95m,
                Cost = 15.52m,
                PublishDate = new DateTime(2017, 1, 7),
                InventoryQuantity = 8,
                ReorderPoint = 4,
                BookStatus = false
            };
            b261.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b261);

            Book b262 = new Book()
            {
                Title = "Ring Of Fire",
                Authors = "Brad Taylor",
                BookNumber = 222262,
                Description = "Pike Logan, a member of a secret counterterrorist unit called the Taskforce, investigates a Saudi-backed Moroccan terrorist cell.",
                Price = 22m,
                Cost = 19.58m,
                PublishDate = new DateTime(2017, 1, 14),
                InventoryQuantity = 6,
                ReorderPoint = 4,
                BookStatus = false
            };
            b262.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b262);

            Book b263 = new Book()
            {
                Title = "Death's Mistress",
                Authors = "Terry Goodkind",
                BookNumber = 222263,
                Description = "The first book of a new series, the Nicci Chronicles, centers on a character from the Sword of Truth fantasy series.",
                Price = 20m,
                Cost = 12m,
                PublishDate = new DateTime(2017, 1, 28),
                InventoryQuantity = 8,
                ReorderPoint = 7,
                BookStatus = false
            };
            b263.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b263);

            Book b264 = new Book()
            {
                Title = "4 3 2 1",
                Authors = "Paul Auster",
                BookNumber = 222264,
                Description = "Four versions of the formative years of a Jewish boy born in Newark in 1947.",
                Price = 20.95m,
                Cost = 5.87m,
                PublishDate = new DateTime(2017, 2, 4),
                InventoryQuantity = 9,
                ReorderPoint = 8,
                BookStatus = false
            };
            b264.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b264);

            Book b265 = new Book()
            {
                Title = "Gunmetal Gray",
                Authors = "Mark Greaney",
                BookNumber = 222265,
                Description = "Court Gentry, now working for the C.I.A., pursues a Chinese hacker who is on the run.",
                Price = 21.95m,
                Cost = 16.24m,
                PublishDate = new DateTime(2017, 2, 18),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                BookStatus = false
            };
            b265.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b265);

            Book b266 = new Book()
            {
                Title = "Banana Cream Pie Murder",
                Authors = "Joanne Fluke",
                BookNumber = 222266,
                Description = "Hannah Swensen, the bakery owner and amateur sleuth of Lake Eden, Minn., returns from her honeymoon to confront an actress s mysterious death.",
                Price = 36.95m,
                Cost = 14.41m,
                PublishDate = new DateTime(2017, 3, 4),
                InventoryQuantity = 7,
                ReorderPoint = 5,
                BookStatus = false
            };
            b266.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b266);

            Book b267 = new Book()
            {
                Title = "Silence Fallen",
                Authors = "Patricia Briggs",
                BookNumber = 222267,
                Description = "The shape-shifter Mercy Thompson finds herself in the clutches of the world s most powerful vampire.",
                Price = 36m,
                Cost = 10.08m,
                PublishDate = new DateTime(2017, 3, 11),
                InventoryQuantity = 7,
                ReorderPoint = 7,
                BookStatus = false
            };
            b267.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b267);

            Book b268 = new Book()
            {
                Title = "Without Warning",
                Authors = "Joel C Rosenberg",
                BookNumber = 222268,
                Description = "A journalist pursues the head of ISIS after an attack on the Capitol when the administration fails to take action.",
                Price = 27.95m,
                Cost = 12.02m,
                PublishDate = new DateTime(2017, 3, 18),
                InventoryQuantity = 11,
                ReorderPoint = 7,
                BookStatus = false
            };
            b268.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b268);

            Book b269 = new Book()
            {
                Title = "Song Of The Lion",
                Authors = "Anne Hillerman",
                BookNumber = 222269,
                Description = "The third Southwestern mystery featuring the Navajo police officer Bernadette Manuelito and her husband, Jim Chee.",
                Price = 31.99m,
                Cost = 24.63m,
                PublishDate = new DateTime(2017, 4, 15),
                InventoryQuantity = 8,
                ReorderPoint = 6,
                BookStatus = false
            };
            b269.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b269);

            Book b270 = new Book()
            {
                Title = "The Burial Hour",
                Authors = "Jeffery Deaver",
                BookNumber = 222270,
                Description = "Lincoln Rhyme travels to Italy to investigate a case.",
                Price = 16m,
                Cost = 1.6m,
                PublishDate = new DateTime(2017, 4, 15),
                InventoryQuantity = 5,
                ReorderPoint = 5,
                BookStatus = false
            };
            b270.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b270);

            Book b271 = new Book()
            {
                Title = "Nighthawk",
                Authors = "Clive Cussler and Graham Brown",
                BookNumber = 222271,
                Description = "The NUMA crew races the Russians and Chinese in a hunt for a missing American aircraft.",
                Price = 30m,
                Cost = 21.6m,
                PublishDate = new DateTime(2017, 6, 3),
                InventoryQuantity = 6,
                ReorderPoint = 1,
                BookStatus = false
            };
            b271.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b271);

            Book b272 = new Book()
            {
                Title = "The Identicals",
                Authors = "Elin Hilderbrand",
                BookNumber = 222272,
                Description = "Complications in the lives of identical twins who were raised by their divorced parents, one on Nantucket, one on Martha s Vineyard.",
                Price = 33.95m,
                Cost = 4.41m,
                PublishDate = new DateTime(2017, 6, 17),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b272.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b272);

            Book b273 = new Book()
            {
                Title = "House Of Spies",
                Authors = "Daniel Silva",
                BookNumber = 222273,
                Description = "Gabriel Allon, the Israeli art restorer and spy, now the head of Israel s secret intelligence service, pursues an ISIS mastermind.",
                Price = 33.95m,
                Cost = 17.31m,
                PublishDate = new DateTime(2017, 7, 15),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                BookStatus = false
            };
            b273.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b273);

            Book b274 = new Book()
            {
                Title = "Two Nights",
                Authors = "Kathy Reichs",
                BookNumber = 222274,
                Description = "Sunday Night, the heroine of a new series from the creator of Temperance Brennan, searches for a girl who may have been kidnapped by a cult.",
                Price = 17.95m,
                Cost = 15.98m,
                PublishDate = new DateTime(2017, 7, 15),
                InventoryQuantity = 10,
                ReorderPoint = 9,
                BookStatus = false
            };
            b274.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b274);

            Book b275 = new Book()
            {
                Title = "Meddling Kids",
                Authors = "Edgar Cantero",
                BookNumber = 222275,
                Description = "Four old friends return to the site of their teenage adventures.",
                Price = 30.95m,
                Cost = 3.71m,
                PublishDate = new DateTime(2017, 7, 22),
                InventoryQuantity = 4,
                ReorderPoint = 3,
                BookStatus = false
            };
            b275.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b275);

            Book b276 = new Book()
            {
                Title = "Watch Me Disappear",
                Authors = "Janelle Brown",
                BookNumber = 222276,
                Description = "When a Berkeley woman vanishes after a hiking trip, her husband and daughter discover disturbing secrets.",
                Price = 32.95m,
                Cost = 30.64m,
                PublishDate = new DateTime(2017, 7, 22),
                InventoryQuantity = 4,
                ReorderPoint = 4,
                BookStatus = false
            };
            b276.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b276);

            Book b277 = new Book()
            {
                Title = "The Store",
                Authors = "James Patterson and Richard DiLallo",
                BookNumber = 222277,
                Description = "Two New York writers go undercover to expose the secrets of a powerful retailer.",
                Price = 31m,
                Cost = 15.19m,
                PublishDate = new DateTime(2017, 8, 19),
                InventoryQuantity = 2,
                ReorderPoint = 2,
                BookStatus = false
            };
            b277.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b277);

            Book b278 = new Book()
            {
                Title = "I Know A Secret",
                Authors = "Tess Gerritsen",
                BookNumber = 222278,
                Description = "Rizzoli and Isles investigate two separate homicides and uncover other dangerous mysteries.",
                Price = 32.95m,
                Cost = 26.36m,
                PublishDate = new DateTime(2017, 8, 19),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                BookStatus = false
            };
            b278.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b278);

            Book b279 = new Book()
            {
                Title = "Sulfur Springs",
                Authors = "William Kent Krueger",
                BookNumber = 222279,
                Description = "A newly married couple search for the wife's missing son, which leads them to a border town in the middle of a drug war.",
                Price = 32.95m,
                Cost = 17.79m,
                PublishDate = new DateTime(2017, 8, 26),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                BookStatus = false
            };
            b279.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b279);

            Book b280 = new Book()
            {
                Title = "Enemy Of The State",
                Authors = "Kyle Mills",
                BookNumber = 222280,
                Description = "Vince Flynn's character Mitch Rapp leaves the C.I.A. to go on a manhunt when the nephew of a Saudi King finances a terrorist group.",
                Price = 20.95m,
                Cost = 4.19m,
                PublishDate = new DateTime(2017, 9, 9),
                InventoryQuantity = 13,
                ReorderPoint = 8,
                BookStatus = false
            };
            b280.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b280);

            Book b281 = new Book()
            {
                Title = "Little Fires Everywhere",
                Authors = "Celeste Ng",
                BookNumber = 222281,
                Description = "An artist with a mysterious past and a disregard for the status quo upends a quiet town outside Cleveland.",
                Price = 16m,
                Cost = 12m,
                PublishDate = new DateTime(2017, 9, 16),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                BookStatus = false
            };
            b281.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b281);

            Book b282 = new Book()
            {
                Title = "Twin Peaks: The Final Dossier",
                Authors = "Mark Frost",
                BookNumber = 222282,
                Description = "Updated profiles on the residents of Twin Peaks are assembled by special agent Tamara Preston.",
                Price = 27.95m,
                Cost = 8.66m,
                PublishDate = new DateTime(2017, 11, 4),
                InventoryQuantity = 2,
                ReorderPoint = 1,
                BookStatus = false
            };
            b282.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b282);

            Book b283 = new Book()
            {
                Title = "The House Of Unexpected Sisters",
                Authors = "Alexander McCall Smith",
                BookNumber = 222283,
                Description = "During an investigation, Precious Ramotswe encounters a man from her past and a nurse who has her last name.",
                Price = 29.95m,
                Cost = 16.47m,
                PublishDate = new DateTime(2017, 11, 11),
                InventoryQuantity = 1,
                ReorderPoint = 1,
                BookStatus = false
            };
            b283.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b283);

            Book b284 = new Book()
            {
                Title = "Artemis",
                Authors = "Andy Weir",
                BookNumber = 222284,
                Description = "A small-time smuggler living in a lunar colony schemes to pay off an old debt by pulling off a challenging heist.",
                Price = 31m,
                Cost = 18.91m,
                PublishDate = new DateTime(2017, 11, 18),
                InventoryQuantity = 8,
                ReorderPoint = 6,
                BookStatus = false
            };
            b284.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b284);

            Book b285 = new Book()
            {
                Title = "Robicheaux",
                Authors = "James Lee Burke",
                BookNumber = 222285,
                Description = "A bereaved detective confronts his past and works to clear his name when he becomes a suspect during an investigation into the murder of the man who killed his wife.",
                Price = 17.95m,
                Cost = 15.98m,
                PublishDate = new DateTime(2018, 1, 6),
                InventoryQuantity = 6,
                ReorderPoint = 5,
                BookStatus = false
            };
            b285.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Thriller");
            Books.Add(b285);

            Book b286 = new Book()
            {
                Title = "Unbound",
                Authors = "Stuart Woods",
                BookNumber = 222286,
                Description = "The 44th book in the Stone Barrington series.",
                Price = 16m,
                Cost = 11.36m,
                PublishDate = new DateTime(2018, 1, 6),
                InventoryQuantity = 8,
                ReorderPoint = 3,
                BookStatus = false
            };
            b286.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b286);

            Book b287 = new Book()
            {
                Title = "The Immortalists",
                Authors = "Chloe Benjamin",
                BookNumber = 222287,
                Description = "Four adolescents learn the dates of their deaths from a psychic and their lives go on different courses.",
                Price = 31m,
                Cost = 22.32m,
                PublishDate = new DateTime(2018, 1, 13),
                InventoryQuantity = 9,
                ReorderPoint = 6,
                BookStatus = false
            };
            b287.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b287);

            Book b288 = new Book()
            {
                Title = "Blood Fury",
                Authors = "JR Ward",
                BookNumber = 222288,
                Description = "The third book in the Black Dagger Legacy series.",
                Price = 30.95m,
                Cost = 21.05m,
                PublishDate = new DateTime(2018, 1, 13),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                BookStatus = false
            };
            b288.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Fantasy");
            Books.Add(b288);

            Book b289 = new Book()
            {
                Title = "The Grave's A Fine And Private Place",
                Authors = "Alan Bradley",
                BookNumber = 222289,
                Description = "Flavia de Luce, a young British sleuth, gets involved in solving a murder after experiencing a family tragedy.",
                Price = 26.95m,
                Cost = 21.83m,
                PublishDate = new DateTime(2018, 2, 3),
                InventoryQuantity = 7,
                ReorderPoint = 5,
                BookStatus = false
            };
            b289.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b289);

            Book b290 = new Book()
            {
                Title = "An American Marriage",
                Authors = "Tayari Jones",
                BookNumber = 222290,
                Description = "A newlywed couple's relationship is tested when the husband is sentenced to 12 years in prison.",
                Price = 22.95m,
                Cost = 12.16m,
                PublishDate = new DateTime(2018, 2, 10),
                InventoryQuantity = 11,
                ReorderPoint = 9,
                BookStatus = false
            };
            b290.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b290);

            Book b291 = new Book()
            {
                Title = "Fifty Fifty",
                Authors = "James Patterson and Candice Fox",
                BookNumber = 222291,
                Description = "Detective Harriet Blue tries to clear her brother's name and save a small Australian town from being massacred.",
                Price = 35.99m,
                Cost = 28.07m,
                PublishDate = new DateTime(2018, 2, 24),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                BookStatus = false
            };
            b291.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b291);

            Book b292 = new Book()
            {
                Title = "Star Wars: The Last Jedi",
                Authors = "Jason Fry",
                BookNumber = 222292,
                Description = "An adaptation of the film, written with input from its director, Rian Johnson, which includes scenes from alternate versions of the script.",
                Price = 28.99m,
                Cost = 24.64m,
                PublishDate = new DateTime(2018, 3, 10),
                InventoryQuantity = 4,
                ReorderPoint = 2,
                BookStatus = false
            };
            b292.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Science Fiction");
            Books.Add(b292);

            Book b293 = new Book()
            {
                Title = "Caribbean Rim",
                Authors = "Randy Wayne White",
                BookNumber = 222293,
                Description = "The 25th book in the Doc Ford series. The marine biologist searches for a state agency official and rare Spanish coins.",
                Price = 15m,
                Cost = 9.45m,
                PublishDate = new DateTime(2018, 3, 17),
                InventoryQuantity = 10,
                ReorderPoint = 8,
                BookStatus = false
            };
            b293.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b293);

            Book b294 = new Book()
            {
                Title = "To Die But Once",
                Authors = "Jacqueline Winspear",
                BookNumber = 222294,
                Description = "In 1940, months after Britain declared war on Germany, Maisie Dobbs investigates the disappearance of an apprentice working on a government contract.",
                Price = 24.95m,
                Cost = 19.21m,
                PublishDate = new DateTime(2018, 3, 31),
                InventoryQuantity = 5,
                ReorderPoint = 1,
                BookStatus = false
            };
            b294.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Suspense");
            Books.Add(b294);

            Book b295 = new Book()
            {
                Title = "Macbeth",
                Authors = "Jo Nesbo",
                BookNumber = 222295,
                Description = "In this adaptation of Shakespeare's tragedy, police in a 1970s industrial town take on a pair of drug lords.",
                Price = 28.95m,
                Cost = 7.53m,
                PublishDate = new DateTime(2018, 4, 14),
                InventoryQuantity = 12,
                ReorderPoint = 7,
                BookStatus = false
            };
            b295.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Shakespeare");
            Books.Add(b295);

            Book b296 = new Book()
            {
                Title = "The High Tide Club",
                Authors = "Mary Kay Andrews",
                BookNumber = 222296,
                Description = "An eccentric millionaire enlists the attorney Brooke Trappnell to fix old wrongs, which sets up a potential scandal and murder.",
                Price = 23.95m,
                Cost = 14.13m,
                PublishDate = new DateTime(2018, 5, 12),
                InventoryQuantity = 14,
                ReorderPoint = 10,
                BookStatus = false
            };
            b296.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b296);

            Book b297 = new Book()
            {
                Title = "Warlight",
                Authors = "Michael Ondaatje",
                BookNumber = 222297,
                Description = "In Britain after World War II, a pair of teenage siblings are taken under the tutelage of a mysterious man and his cronies who served during the war.",
                Price = 26m,
                Cost = 20.28m,
                PublishDate = new DateTime(2018, 5, 12),
                InventoryQuantity = 10,
                ReorderPoint = 6,
                BookStatus = false
            };
            b297.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Historical Fiction");
            Books.Add(b297);

            Book b298 = new Book()
            {
                Title = "The Cast",
                Authors = "Danielle Steel",
                BookNumber = 222298,
                Description = "A magazine columnist meets an array of Hollywood professionals when a producer turns a story about her grandmother into a TV series.",
                Price = 21.95m,
                Cost = 12.95m,
                PublishDate = new DateTime(2018, 5, 19),
                InventoryQuantity = 15,
                ReorderPoint = 10,
                BookStatus = false
            };
            b298.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Romance");
            Books.Add(b298);

            Book b299 = new Book()
            {
                Title = "Beach House Reunion",
                Authors = "Mary Alice Monroe",
                BookNumber = 222299,
                Description = "Three generations of a family gather one summer in South Carolina.",
                Price = 32.95m,
                Cost = 6.59m,
                PublishDate = new DateTime(2018, 5, 26),
                InventoryQuantity = 6,
                ReorderPoint = 3,
                BookStatus = false
            };
            b299.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Contemporary Fiction");
            Books.Add(b299);

            Book b300 = new Book()
            {
                Title = "Turbulence",
                Authors = "Stuart Woods",
                BookNumber = 222300,
                Description = "The 46th book in the Stone Barrington series.",
                Price = 15.95m,
                Cost = 6.06m,
                PublishDate = new DateTime(2018, 6, 9),
                InventoryQuantity = 13,
                ReorderPoint = 10,
                BookStatus = false
            };
            b300.Genre = db.Genres.FirstOrDefault(g => g.GenreName == "Mystery");
            Books.Add(b300);


            try  //attempt to add or update the book
            {
                //loop through each of the books in the list
                foreach (Book bookToAdd in Books)
                {
                    //set the flag to the current title to help with debugging
                    strBookTitle = bookToAdd.Title;

                    //look to see if the book is in the database - this assumes that no
                    //two books have the same title
                    Book dbBook = db.Books.FirstOrDefault(b => b.Title == bookToAdd.Title);

                    //if the dbBook is null, this title is not in the database
                    if (dbBook == null)
                    {
                        //add the book to the database and save changes
                        db.Books.Add(bookToAdd);
                        db.SaveChanges();

                        //update the counter to help with debugging
                        intBooksAdded += 1;
                    }
                    else //dbBook is not null - this title *is* in the database
                    {
                        //update all of the book's properties
                        dbBook.Title = bookToAdd.Title;
                        dbBook.Authors = bookToAdd.Authors;
                        dbBook.PublishDate = bookToAdd.PublishDate;
                        dbBook.Description = bookToAdd.Description;
                        dbBook.Price = bookToAdd.Price;

                        //since we found the correct genre object in a previous step,
                        //this update is easy - both dbBook and bookToAdd have a Genre 
                        //object for this property
                        dbBook.Genre = bookToAdd.Genre;

                        //update the database and save the changes
                        db.Update(dbBook);
                        db.SaveChanges();

                        //update the counter to help with debugging
                        intBooksAdded += 1;
                    }
                }
            }

            catch (Exception ex)//something went wrong with adding or updating
            {
                //Build a messsage using the flags we created
                String msg = "  Repositories added:" + intBooksAdded + "; Error on " + strBookTitle;

                //throw the exception with the new message
                throw new InvalidOperationException(ex.Message + msg);
            }
        }
    }
}
