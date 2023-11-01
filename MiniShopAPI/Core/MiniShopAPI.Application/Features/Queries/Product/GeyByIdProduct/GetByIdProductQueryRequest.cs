using System;
using MediatR;

namespace MiniShopAPI.Application.Features.Queries.Product.GeyByIdProduct
{
	public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
	{
		public string Id { get; set; }
	}
}

