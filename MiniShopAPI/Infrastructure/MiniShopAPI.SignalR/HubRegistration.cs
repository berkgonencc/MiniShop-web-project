using System;
using Microsoft.AspNetCore.Builder;
using MiniShopAPI.SignalR.Hubs;

namespace MiniShopAPI.SignalR
{
	public static class HubRegistration
	{
		public static void MapHubs(this WebApplication webApplication)
		{
			webApplication.MapHub<ProductHub>("/products-hub");
		}
	}
}

