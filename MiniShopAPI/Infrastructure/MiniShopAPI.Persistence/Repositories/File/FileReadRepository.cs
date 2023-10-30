using System;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Persistence.Contexts;

namespace MiniShopAPI.Persistence.Repositories
{
    public class FileReadRepository : ReadRepository<MiniShopAPI.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(MiniShopAPIDbContext context) : base(context)
        {
        }
    }
}

