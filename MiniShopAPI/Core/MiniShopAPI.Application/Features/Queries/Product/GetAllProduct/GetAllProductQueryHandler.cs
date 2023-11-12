using System;
using MediatR;
using Microsoft.Extensions.Logging;
using MiniShopAPI.Application.Repositories;
using MiniShopAPI.Application.RequestParameters;

namespace MiniShopAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly ILogger<GetAllProductQueryHandler> _logger;
        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, ILogger<GetAllProductQueryHandler> logger)
        {
            _productReadRepository = productReadRepository;
            _logger = logger;
        }

        public Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get all products");
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();
            var response = new GetAllProductQueryResponse { Products = products, TotalCount = totalCount };

            return Task.FromResult(response);
        }
    }
}

