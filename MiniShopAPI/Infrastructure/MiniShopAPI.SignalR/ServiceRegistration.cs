using System;
using Microsoft.Extensions.DependencyInjection;
using MiniShopAPI.Application.Abstractions.Hubs;
using MiniShopAPI.SignalR.HubServices;

namespace MiniShopAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddSignalR();
            
        }
    }
}

