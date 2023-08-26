using System;
using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Domain.Entities.Common;

namespace MiniShopAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

    }
}

