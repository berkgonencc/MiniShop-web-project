using System;
using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Domain.Entities;
using MiniShopAPI.Domain.Entities.Common;

namespace MiniShopAPI.Persistence.Contexts
{
    public class MiniShopAPIDbContext : DbContext
    {
        public MiniShopAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinde yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar.
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

