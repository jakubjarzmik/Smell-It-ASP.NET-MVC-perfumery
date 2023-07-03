using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetAllProducts;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IOrderStatusRepository orderStatusRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _orderStatusRepository = orderStatusRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var canceledOrderStatus = await _orderStatusRepository.GetByNameAsync("Canceled");
        var products = await _productRepository.GetAllAsync();

        var dtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var dto = _mapper.Map<ProductDto>(product);
            dto.SoldAmount = (await _orderItemRepository.GetAsync(product))?.Where(oi => oi.Order.OrderStatus != canceledOrderStatus).Sum(oi => oi.Quantity);
            dtos.Add(dto);
        }

        return dtos;
    }
}
