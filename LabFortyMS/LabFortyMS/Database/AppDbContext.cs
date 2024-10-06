using LabFortyMS.Entities;
using LabFortyMS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LabFortyMS.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Price> Prices { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ApplyBaseRules();
            return base.SaveChangesAsync();
        }

        private void ApplyBaseRules()
        {
            foreach (var entityToAdd in this.ChangeTracker.Entries()
                .Where(x => x.Entity is IHasCreationDate && (x.State == EntityState.Added)))
            {
                var currentEntity = (IHasCreationDate)entityToAdd.Entity;
                if (entityToAdd.State == EntityState.Added && currentEntity.CreatedOn == default(DateTime))
                {
                    currentEntity.CreatedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
