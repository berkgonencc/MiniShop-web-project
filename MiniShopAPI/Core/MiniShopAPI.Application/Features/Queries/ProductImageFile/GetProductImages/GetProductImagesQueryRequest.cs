using System;
using MediatR;

namespace MiniShopAPI.Application.Features.Queries.ProductImageFile.GetProductImages
{
	public class GetProductImagesQueryRequest: IRequest<List<GetProductImagesQueryResponse>>
	{
		public string Id { get; set; }
	}
}

