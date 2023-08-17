using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetMostPopularProducts;
public class GetMostPopularProductsQueryHandler : IRequestHandler<GetMostPopularProductsQuery, IEnumerable<WebsiteProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public GetMostPopularProductsQueryHandler(IProductRepository productRepository, IOrderStatusRepository orderStatusRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _orderStatusRepository = orderStatusRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteProductDto>> Handle(GetMostPopularProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetMostPopularProductsAsync(3);
        var canceledOrderStatus = await _orderStatusRepository.GetByNameAsync("Canceled");

        var dtos = new List<WebsiteProductDto>();
        foreach (var product in products)
        {
            var dto = _mapper.Map<WebsiteProductDto>(product, opt => { opt.Items["LanguageCode"] = request.LanguageCode; });
            dto.SoldAmount = (await _orderItemRepository.GetAsync(product))?.Where(oi => oi.Order.OrderStatus != canceledOrderStatus && oi.Order.OrderDate >= DateTime.Now.AddMonths(-1)).Sum(oi => oi.Quantity);
            dtos.Add(dto);
        }

        return dtos.OrderByDescending(p => p.SoldAmount);
    }
}
