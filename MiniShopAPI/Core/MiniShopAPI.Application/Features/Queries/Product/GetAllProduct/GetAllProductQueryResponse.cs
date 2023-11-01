using System;
namespace MiniShopAPI.Application.Features.Queries.Product.GetAllProduct
{
	public class GetAllProductQueryResponse
	{
		public int TotalCount { get; set; }
		public object Products { get; set; }
	}
}

