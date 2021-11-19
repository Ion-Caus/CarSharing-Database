using Entity.ModelData;
using Microsoft.EntityFrameworkCore;

namespace Database_EFC.Persistence
{
    public class CarSharingDbContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=abul.db.elephantsql.com;" +
                "Database=bsovfjmv;" +
                "Username=bsovfjmv;" +
                "Password=31tBntzmwwOtrEMeGqAPJKk6VBGFI7CH;"
            );
        }
    }
}