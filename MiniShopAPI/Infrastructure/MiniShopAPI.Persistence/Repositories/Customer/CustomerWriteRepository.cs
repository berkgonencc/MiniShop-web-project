using System;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Domain.Entities;
using MiniShopAPI.Persistence.Contexts;

namespace MiniShopAPI.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(MiniShopAPIDbContext context) : base(context)
        {
        }
    }
}

