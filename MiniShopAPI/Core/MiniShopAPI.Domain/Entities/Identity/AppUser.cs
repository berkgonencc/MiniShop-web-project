using System;
using Microsoft.AspNetCore.Identity;

namespace MiniShopAPI.Domain.Entities.Identity
{
	public class AppUser : IdentityUser<string>
	{
		public string FullName { get; set; }
	}
}

