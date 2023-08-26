using System;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Domain.Entities;

namespace MiniShopAPI.Application.Repositories
{
	public interface ICustomerWriteRepository :  IWriteRepository<Customer>
	{
	}
}

