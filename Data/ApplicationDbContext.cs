using Microsoft.EntityFrameworkCore;
using FribergCarRentalAB.Models;

namespace FribergCarRentalAB.Data
{
    // Denna klass representerar anslutningen till databasen via Entity Framework
    public class ApplicationDbContext : DbContext
    {
        // Konstruktorn tar in inställningar
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Tabeller i databasen
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
    }
}
