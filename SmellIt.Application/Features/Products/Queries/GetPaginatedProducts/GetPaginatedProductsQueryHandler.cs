using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetPaginatedProducts;
public class GetPaginatedProductsQueryHandler : IRequestHandler<GetPaginatedProductsQuery, ProductsViewModel>
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public GetPaginatedProductsQueryHandler(IProductRepository productRepository, IOrderStatusRepository orderStatusRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _orderStatusRepository = orderStatusRepository;
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }
    public async Task<ProductsViewModel> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
    {
        var totalProducts = await _productRepository.CountAsync();
        var products = await _productRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var canceledOrderStatus = await _orderStatusRepository.GetByNameAsync("Canceled");

        var dtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var dto = _mapper.Map<ProductDto>(product);
            dto.SoldAmount = (await _orderItemRepository.GetAsync(product))?.Where(oi => oi.Order.OrderStatus != canceledOrderStatus).Sum(oi => oi.Quantity);
            dtos.Add(dto);
        }

        var viewModel = new ProductsViewModel(dtos, totalProducts, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
