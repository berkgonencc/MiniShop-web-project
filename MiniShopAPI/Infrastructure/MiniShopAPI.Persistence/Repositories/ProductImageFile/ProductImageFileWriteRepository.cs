using System;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Domain.Entities;
using MiniShopAPI.Persistence.Contexts;

namespace MiniShopAPI.Persistence.Repositories
{
    public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(MiniShopAPIDbContext context) : base(context)
        {
        }
    }
}

