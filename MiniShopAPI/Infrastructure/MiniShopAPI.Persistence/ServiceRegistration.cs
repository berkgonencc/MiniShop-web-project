using System;
using Microsoft.Extensions.DependencyInjection;
using MiniShopAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Persistence.Repositories;
using MiniShopAPI.Application.Repositories;

namespace MiniShopAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<MiniShopAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}

