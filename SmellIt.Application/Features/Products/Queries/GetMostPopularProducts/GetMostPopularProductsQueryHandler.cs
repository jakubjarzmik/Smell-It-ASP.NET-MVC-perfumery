using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetMostPopularProducts;
public class GetMostPopularProductsQueryHandler : IRequestHandler<GetMostPopularProductsQuery, IEnumerable<WebsiteProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetMostPopularProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteProductDto>> Handle(GetMostPopularProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetMostPopularProductsAsync(3);

        var productDtos = _mapper.Map<IEnumerable<WebsiteProductDto>>(products, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });

        return productDtos;
    }
}
