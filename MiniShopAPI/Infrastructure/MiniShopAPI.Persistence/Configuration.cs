using System;
using Microsoft.Extensions.Configuration;

namespace MiniShopAPI.Persistence
{
	static class Configuration
	{
		static public string ConnectionString
		{
			get
			{
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MiniShopAPI.API"));
                configurationManager.AddJsonFile("appsettings.json");
				return configurationManager.GetConnectionString("PostgreSQL");
            }
		}
	}
}

