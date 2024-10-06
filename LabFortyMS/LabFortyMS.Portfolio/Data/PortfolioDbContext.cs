using LabFortyMS.Common.Data.Models.Interfaces;
using LabFortyMS.Portfolio.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LabFortyMS.Portfolio.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
           : base(options)
        {
        }

        public DbSet<Models.Portfolio> Portfolios { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity
                    .HasOne(o => o.Portfolio)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(o => o.PortfolioId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ApplyBaseRules();
            return await base.SaveChangesAsync(cancellationToken);
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
