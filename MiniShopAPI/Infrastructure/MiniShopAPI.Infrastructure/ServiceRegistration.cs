using System;
using Microsoft.Extensions.DependencyInjection;
using MiniShopAPI.Application.Services;
using MiniShopAPI.Infrastructure.Services;

namespace MiniShopAPI.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IFileService, FileService>();
		}
	}
}

