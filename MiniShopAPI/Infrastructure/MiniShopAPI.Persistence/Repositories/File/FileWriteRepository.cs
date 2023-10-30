using System;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Persistence.Contexts;

namespace MiniShopAPI.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<MiniShopAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(MiniShopAPIDbContext context) : base(context)
        {
        }
    }
}

