using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fa25Group14FinalProject.Seeding
{
    public static class SeedReviews
    {
        public static void SeedAllReviews(AppDbContext db)
        {
            // If reviews already exist, don't reseed
            if (db.Reviews.Any())
            {
                return;
            }

            // ----- Look up books -----
            Book sayGoodbye = db.Books.FirstOrDefault(b => b.Title == "Say Goodbye");
            Book chasingDarkness = db.Books.FirstOrDefault(b => b.Title == "Chasing Darkness");
            Book theProfessional = db.Books.FirstOrDefault(b => b.Title == "The Professional");
            Book theOtherQueen = db.Books.FirstOrDefault(b => b.Title == "The Other Queen");
            Book wrecked = db.Books.FirstOrDefault(b => b.Title == "Wrecked");
            Book reckless = db.Books.FirstOrDefault(b => b.Title == "Reckless");

            // ----- Look up reviewers -----
            AppUser christopherBaker = db.Users.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker");
            AppUser wendyChang = db.Users.FirstOrDefault(u => u.FirstName == "Wendy" && u.LastName == "Chang");
            AppUser limChou = db.Users.FirstOrDefault(u => u.FirstName == "Lim" && u.LastName == "Chou");
            AppUser jeffreyHampton = db.Users.FirstOrDefault(u => u.FirstName == "Jeffrey" && u.LastName == "Hampton");
            AppUser charlesMiller = db.Users.FirstOrDefault(u => u.FirstName == "Charles" && u.LastName == "Miller");
            AppUser ernestLowe = db.Users.FirstOrDefault(u => u.FirstName == "Ernest" && u.LastName == "Lowe");

            // ----- Look up approvers -----
            AppUser susanBarnes = db.Users.FirstOrDefault(u => u.FirstName == "Susan" && u.LastName == "Barnes");
            AppUser jackMason = db.Users.FirstOrDefault(u => u.FirstName == "Jack" && u.LastName == "Mason");
            AppUser cindySilva = db.Users.FirstOrDefault(u => u.FirstName == "Cindy" && u.LastName == "Silva");
            AppUser ericStuart = db.Users.FirstOrDefault(u => u.FirstName == "Eric" && u.LastName == "Stuart");
            AppUser allenRogers = db.Users.FirstOrDefault(u => u.FirstName == "Allen" && u.LastName == "Rogers");
            AppUser hectorGarcia = db.Users.FirstOrDefault(u => u.FirstName == "Hector" && u.LastName == "Garcia");

            // Quick sanity check: if any critical lookup failed, bail with a clear error
            if (sayGoodbye == null || chasingDarkness == null || theProfessional == null ||
                theOtherQueen == null || wrecked == null || reckless == null)
            {
                throw new InvalidOperationException("SeedReviews: One or more required Books were not found. Check titles against SeedBooks.");
            }

            if (christopherBaker == null || wendyChang == null || limChou == null ||
                jeffreyHampton == null || charlesMiller == null || ernestLowe == null ||
                susanBarnes == null || jackMason == null || cindySilva == null ||
                ericStuart == null || allenRogers == null || hectorGarcia == null)
            {
                throw new InvalidOperationException("SeedReviews: One or more required Users were not found. Check SeedUsers names.");
            }

            List<Review> allReviews = new List<Review>();

            // 1. Christopher Baker – Say Goodbye – Susan Barnes
            allReviews.Add(new Review
            {
                Reviewer = christopherBaker,
                Book = sayGoodbye,
                Approver = susanBarnes,
                Rating = 5,
                ReviewText = "Incredible pacing and tension throughout—couldn't stop reading!",
                DisputeStatus = DisputeStatus.Approve
            });

            // 2. Christopher Baker – Chasing Darkness – Jack Mason
            allReviews.Add(new Review
            {
                Reviewer = christopherBaker,
                Book = chasingDarkness,
                Approver = jackMason,
                Rating = 4,
                ReviewText = "Tight mystery with solid twists; a bit slow in the middle.",
                DisputeStatus = DisputeStatus.Reject
            });

            // 3. Wendy Chang – The Professional – Cindy Silva
            allReviews.Add(new Review
            {
                Reviewer = wendyChang,
                Book = theProfessional,
                Approver = cindySilva,
                Rating = 4,
                ReviewText = "Classic Spenser. Sharp dialogue and old-school charm.",
                DisputeStatus = DisputeStatus.Approve
            });

            // 4. Lim Chou – The Other Queen – Eric Stuart
            allReviews.Add(new Review
            {
                Reviewer = limChou,
                Book = theOtherQueen,
                Approver = ericStuart,
                Rating = 3,
                ReviewText = "Rich historical detail, but pacing drags at times.",
                DisputeStatus = DisputeStatus.Approve
            });

            // 5. Lim Chou – Wrecked – Allen Rogers
            allReviews.Add(new Review
            {
                Reviewer = limChou,
                Book = wrecked,
                Approver = allenRogers,
                Rating = 5,
                ReviewText = "Fast-moving and witty. Loved the Cape Cod setting.",
                DisputeStatus = DisputeStatus.Approve
            });

            // 6. Lim Chou – Reckless – Hector Garcia
            allReviews.Add(new Review
            {
                Reviewer = limChou,
                Book = reckless,
                Approver = hectorGarcia,
                Rating = 4,
                ReviewText = "Emotional and thrilling. Hauck's motives feel real.",
                DisputeStatus = DisputeStatus.Approve
            });

            // 7. Jeffrey Hampton – The Professional – Cindy Silva
            allReviews.Add(new Review
            {
                Reviewer = jeffreyHampton,
                Book = theProfessional,
                Approver = cindySilva,
                Rating = 5,
                ReviewText = "Lean, witty Spenser case—couldn't put it down.",
                DisputeStatus = DisputeStatus.Approve
            });

            // 8. Charles Miller – Say Goodbye – Allen Rogers
            allReviews.Add(new Review
            {
                Reviewer = charlesMiller,
                Book = sayGoodbye,
                Approver = allenRogers,
                Rating = 4,
                ReviewText = "Creepy, clever, and tightly plotted.",
                DisputeStatus = DisputeStatus.Reject
            });

            // 9. Ernest Lowe – Wrecked – Eric Stuart
            allReviews.Add(new Review
            {
                Reviewer = ernestLowe,
                Book = wrecked,
                Approver = ericStuart,
                Rating = 4,
                ReviewText = "Light, fun mystery with brisk pacing.",
                DisputeStatus = DisputeStatus.Approve
            });

            // 10. Ernest Lowe – Reckless – Eric Stuart
            allReviews.Add(new Review
            {
                Reviewer = ernestLowe,
                Book = reckless,
                Approver = ericStuart,
                Rating = 3,
                ReviewText = "Gritty and tense, but a bit uneven.",
                DisputeStatus = DisputeStatus.Approve
            });

            // Super simple: table is empty, so just insert them
            db.Reviews.AddRange(allReviews);
            db.SaveChanges();
        }
    }
}
