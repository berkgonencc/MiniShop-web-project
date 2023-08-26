using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MiniShopAPI.Persistence.Contexts;

namespace MiniShopAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MiniShopAPIDbContext>
    {
        public MiniShopAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MiniShopAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

