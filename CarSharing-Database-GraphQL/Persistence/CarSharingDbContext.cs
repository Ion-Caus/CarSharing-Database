using System.Threading;
using CarSharing_Database_GraphQL.ModelData;
using Microsoft.EntityFrameworkCore;

namespace CarSharing_Database_GraphQL.Persistence
{
    public class CarSharingDbContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

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