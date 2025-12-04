using System;
using Microsoft.EntityFrameworkCore;

//TODO: Update this using statement to include your project name
using fa25Group14FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//TODO: Make this namespace match your project name
namespace fa25Group14FinalProject.DAL
{
    //NOTE: This class definition references the user class for this project.  
    //If your User class is called something other than AppUser, you will need
    //to change it in the line below
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPerformanceLevel("Basic");
            builder.HasServiceTier("Basic");
            base.OnModelCreating(builder);

            // Orders -> Card (prevent cascade delete from Card -> Orders)
            builder.Entity<Order>()
                .HasOne(o => o.Card)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CardID)
                .OnDelete(DeleteBehavior.Restrict);

            // Orders -> Customer (prevent cascade delete from User -> Orders)
            builder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Card -> Customer (prevent cascade delete from User -> Cards)
            builder.Entity<Card>()
                .HasOne(c => c.Customer)
                .WithMany(u => u.Cards)
                .HasForeignKey(c => c.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        //TODO: Add Dbsets here.  Products is included as an example.  
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Reorder> Reorders { get; set; }



    }
}
