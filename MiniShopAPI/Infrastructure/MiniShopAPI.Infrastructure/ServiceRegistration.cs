using Microsoft.Extensions.DependencyInjection;
using MiniShopAPI.Application.Abstractions.Storage;
using MiniShopAPI.Application.Abstractions.Token;
using MiniShopAPI.Infrastructure.Enums;
using MiniShopAPI.Infrastructure.Services.Storage;
using MiniShopAPI.Infrastructure.Services.Storage.Azure;
using MiniShopAPI.Infrastructure.Services.Storage.Local;
using MiniShopAPI.Infrastructure.Services.Token;

namespace MiniShopAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler,TokenHandler>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}

