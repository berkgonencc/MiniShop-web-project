using System;
using MiniShopAPI.Domain.Entities;

namespace MiniShopAPI.Application.Features.Queries.Product.GeyByIdProduct
{
	public class GetByIdProductQueryResponse
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}

