using System;
using MiniShopAPI.Domain.Entities.Common;

namespace MiniShopAPI.Domain.Entities
{
	public class Customer : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}

