using LabFortyMS.Common.Data.Models.Interfaces;
using LabFortyMS.Orders.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LabFortyMS.Orders.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
           : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Ticker> Tickers { get; set; }

        public DbSet<Price> Prices { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ApplyBaseRules();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(order =>
            {
                order
                    .HasOne(o => o.Ticker)
                    .WithMany(t => t.Orders)
                    .HasForeignKey(o => o.TickerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                order
                    .HasOne(o => o.Price)
                    .WithMany(t => t.Orders)
                    .HasForeignKey(o => o.PriceId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Ticker>(ticker =>
            {
                ticker
                    .HasOne(o => o.Price)
                    .WithMany(t => t.Tickers)
                    .HasForeignKey(o => o.PriceId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });
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
