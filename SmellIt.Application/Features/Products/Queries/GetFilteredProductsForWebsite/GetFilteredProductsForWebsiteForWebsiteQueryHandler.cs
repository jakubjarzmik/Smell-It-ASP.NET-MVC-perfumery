using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetFilteredProductsForWebsite;

public class GetFilteredProductsForWebsiteQueryHandler : IRequestHandler<GetFilteredProductsForWebsiteQuery, IEnumerable<WebsiteProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public GetFilteredProductsForWebsiteQueryHandler(IProductRepository productRepository, IOrderStatusRepository orderStatusRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _orderStatusRepository = orderStatusRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WebsiteProductDto>> Handle(GetFilteredProductsForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var products = await FetchProductsAsync(request);
        products = ApplyFilters(request, products);

        var canceledOrderStatus = await _orderStatusRepository.GetByNameAsync("Canceled");

        var dtos = new List<WebsiteProductDto>();
        foreach (var product in products)
        {
            var dto = _mapper.Map<WebsiteProductDto>(product, opt => { opt.Items["LanguageCode"] = request.LanguageCode; });
            dto.SoldAmount = (await _orderItemRepository.GetAsync(product))?.Where(oi => oi.Order.OrderStatus != canceledOrderStatus).Sum(oi => oi.Quantity);
            dtos.Add(dto);
        }

        dtos = SortDtos(request, dtos).ToList();

        return dtos;
    }

    private async Task<IEnumerable<Product>> FetchProductsAsync(GetFilteredProductsForWebsiteQuery request)
    {
        return request.CategoryEncodedName != null
            ? await _productRepository.GetProductsByCategoryEncodedNameAsync(request.CategoryEncodedName)
            : await _productRepository.GetAllAsync();
    }

    private IEnumerable<Product> ApplyFilters(GetFilteredProductsForWebsiteQuery request, IEnumerable<Product> products)
    {
        if (request.BrandEncodedName != null)
            products = products.Where(p => p.Brand?.EncodedName == request.BrandEncodedName);
        if (request.FragranceCategoryEncodedName != null)
            products = products.Where(p => p.FragranceCategory?.EncodedName == request.FragranceCategoryEncodedName);
        if (request.GenderEncodedName != null)
            products = products.Where(p => p.Gender?.EncodedName == request.GenderEncodedName);

        return products;
    }

    private IEnumerable<WebsiteProductDto> SortDtos(GetFilteredProductsForWebsiteQuery request, IEnumerable<WebsiteProductDto> dtos)
    {
        switch (request.SortType)
        {
            case SortType.oldest:
                return dtos.OrderBy(p => p.CreatedAt);
            case SortType.price_ascending:
                return dtos.OrderBy(p => p.Price.Value);
            case SortType.price_descending:
                return dtos.OrderByDescending(p => p.Price.Value);
            default:
                return dtos.OrderByDescending(p => p.CreatedAt);
        }
    }
}
