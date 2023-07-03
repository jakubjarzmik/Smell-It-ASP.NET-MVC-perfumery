using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetProductByEncodedName;

public class GetProductByEncodedNameQueryHandler : IRequestHandler<GetProductByEncodedNameQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public GetProductByEncodedNameQueryHandler(IProductRepository productRepository, IOrderStatusRepository orderStatusRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _orderStatusRepository = orderStatusRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }
    public async Task<ProductDto> Handle(GetProductByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.EncodedName);
        var canceledOrderStatus = await _orderStatusRepository.GetByNameAsync("Canceled");
        
        var dto = _mapper.Map<ProductDto>(product);
        dto.SoldAmount = (await _orderItemRepository.GetAsync(product!))?.Where(oi => oi.Order.OrderStatus != canceledOrderStatus).Sum(oi => oi.Quantity);
        
        return dto;
    }
}