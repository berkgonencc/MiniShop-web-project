using System;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Persistence.Contexts;
using MiniShopAPI.Domain.Entities;

namespace MiniShopAPI.Persistence.Repositories
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(MiniShopAPIDbContext context) : base(context)
        {
        }
    }
}

