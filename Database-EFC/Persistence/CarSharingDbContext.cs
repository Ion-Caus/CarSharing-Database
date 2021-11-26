using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var changed = ChangeTracker.Entries();
            if (changed == null) return base.SaveChangesAsync(cancellationToken);
            
            foreach (var entry in changed.Where(e => e.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
                if (entry.Entity is ISoftDeletable deletable)
                {
                    deletable.IsDeleted = true;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}