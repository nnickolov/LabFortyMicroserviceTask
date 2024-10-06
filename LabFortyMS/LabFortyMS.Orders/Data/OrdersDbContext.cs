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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ApplyBaseRules();
            return await base.SaveChangesAsync();
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
