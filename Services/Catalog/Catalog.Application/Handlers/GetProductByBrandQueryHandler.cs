using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
  public class GetProductByBrandQueryHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
  {
    private readonly IProductRepository _productRepository;

    public GetProductByBrandQueryHandler(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
    {
      var product = await _productRepository.GetProductsByBrand(request.Brand);
      var productResponseList = ProductMapper.CurrentMap.Map<IList<ProductResponse>>(product);

      return productResponseList;
    }
  }
}