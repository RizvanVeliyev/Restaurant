using Azure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;

namespace Restaurant.DAL.DataContexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<AvailableTimeSlotModel> AvailableTimeSlotModels { get; set; }
       

    }
}
