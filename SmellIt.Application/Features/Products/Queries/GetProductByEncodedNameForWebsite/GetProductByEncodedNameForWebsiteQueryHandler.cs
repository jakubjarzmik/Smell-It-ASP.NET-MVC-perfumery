using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetProductByEncodedNameForWebsite;

public class GetProductByEncodedNameForWebsiteQueryHandler : IRequestHandler<GetProductByEncodedNameForWebsiteQuery, WebsiteProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public GetProductByEncodedNameForWebsiteQueryHandler(IProductRepository productRepository, IOrderStatusRepository orderStatusRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _orderStatusRepository = orderStatusRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }
    public async Task<WebsiteProductDto> Handle(GetProductByEncodedNameForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.EncodedName);
        var canceledOrderStatus = await _orderStatusRepository.GetByNameAsync("Canceled");

        var dto = _mapper.Map<WebsiteProductDto>(product, opt => { opt.Items["LanguageCode"] = request.LanguageCode; });
        dto.SoldAmount = (await _orderItemRepository.GetAsync(product!))?.Where(oi => oi.Order.OrderStatus != canceledOrderStatus).Sum(oi => oi.Quantity);

        return dto;
    }
}