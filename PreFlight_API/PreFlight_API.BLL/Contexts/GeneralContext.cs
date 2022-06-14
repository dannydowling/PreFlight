using Microsoft.EntityFrameworkCore;
using PreFlight_API.BLL.Models;

namespace PreFlight_API.BLL.Contexts
{
    public class GeneralDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Weather> Weathers { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
           @"Server=(localdb)\mssqllocaldb;Database=PreFlightAI;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Ignore(c => c.ProfilePicture)
                .Ignore(d => d.Password);

            modelBuilder.Entity<Employee>()
              .Ignore(c => c.ProfilePicture)
              .Ignore(d => d.Password);

            modelBuilder.Entity<Location>()
             .Ignore(c => c.Latitude)
             .Ignore(c => c.Longitude);


            base.OnModelCreating(modelBuilder);
        }
    }
}
