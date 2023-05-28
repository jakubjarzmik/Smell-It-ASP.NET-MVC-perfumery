using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetFilteredProductsForWebsite;

public class GetFilteredProductsForWebsiteQueryHandler : IRequestHandler<GetFilteredProductsForWebsiteQuery, IEnumerable<WebsiteProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetFilteredProductsForWebsiteQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WebsiteProductDto>> Handle(GetFilteredProductsForWebsiteQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = new List<Product>();

        if (request.CategoryEncodedName != null)
            products = await _productRepository.GetProductsByCategoryEncodedNameAsync(request.CategoryEncodedName);
        else
            products = await _productRepository.GetAllAsync();

        if (request.BrandEncodedName != null)
            products = products.Where(p => p.Brand?.EncodedName == request.BrandEncodedName);
        if (request.FragranceCategoryEncodedName != null)
            products = products.Where(p => p.FragranceCategory?.EncodedName == request.FragranceCategoryEncodedName);
        if (request.GenderEncodedName != null)
            products = products.Where(p => p.Gender?.EncodedName == request.GenderEncodedName);


        var dtos = _mapper.Map<IEnumerable<WebsiteProductDto>>(products, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });

        switch (request.SortType)
        {
            case SortType.oldest:
                dtos = dtos.OrderBy(p => p.CreatedAt);
                break;
            case SortType.price_ascending:
                dtos = dtos.OrderBy(p => p.Price.Value);
                break;
            case SortType.price_descending:
                dtos = dtos.OrderByDescending(p => p.Price.Value);
                break;
            default:
                dtos = dtos.OrderByDescending(p => p.CreatedAt);
                break;
        }

        return dtos;
    }
}