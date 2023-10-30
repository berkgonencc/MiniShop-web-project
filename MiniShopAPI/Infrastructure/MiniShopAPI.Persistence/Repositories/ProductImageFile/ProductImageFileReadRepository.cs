using System;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Domain.Entities;
using MiniShopAPI.Persistence.Contexts;

namespace MiniShopAPI.Persistence.Repositories
{
    public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(MiniShopAPIDbContext context) : base(context)
        {
        }
    }

}
