using System;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Domain.Entities;
using MiniShopAPI.Persistence.Contexts;

namespace MiniShopAPI.Persistence.Repositories
{
    public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(MiniShopAPIDbContext context) : base(context)
        {
        }
    }
}

