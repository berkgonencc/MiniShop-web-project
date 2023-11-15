using System;
using Microsoft.AspNetCore.SignalR;
using MiniShopAPI.Application.Abstractions.Hubs;
using MiniShopAPI.SignalR.Hubs;

namespace MiniShopAPI.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {
        readonly IHubContext<ProductHub> _hubContext;

        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.ProductAddedMessage, message);

        }
    }
}

