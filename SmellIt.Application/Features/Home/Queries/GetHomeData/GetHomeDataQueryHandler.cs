using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Home.Queries.GetHomeData;
public class GetHomeDataQueryHandler : IRequestHandler<GetHomeDataQuery, HomeViewModel>
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetHomeDataQueryHandler(IProductRepository productRepository, IOrderRepository orderRepository, IOrderStatusRepository orderStatusRepository, IOrderItemRepository orderItemRepository, IUserRepository userRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
        _orderStatusRepository = orderStatusRepository;
        _orderItemRepository = orderItemRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<HomeViewModel> Handle(GetHomeDataQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetLatestListAsync(3);
        var products = await _productRepository.GetMostPopularProductsAsync(3);

        var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });

        var canceledOrderStatus = await _orderStatusRepository.GetByNameAsync("Canceled");

        var dtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var dto = _mapper.Map<ProductDto>(product);
            dto.SoldAmount = (await _orderItemRepository.GetAsync(product))
                ?.Where(oi => oi.Order.OrderStatus != canceledOrderStatus).Sum(oi => oi.Quantity);
            dtos.Add(dto);
        }

        var viewModel = new HomeViewModel
        {
            ProductsCount = await _productRepository.CountAsync(),
            MonthlyPurchases = await _orderRepository.CountLastMonthAsync(),
            MonthlyEarnings = (int)await _orderRepository.CountMonthlyEarningsAsync(),
            UsersCount = await _userRepository.CountAsync(),
            RecentOrders = orderDtos,
            MostPopularProducts = dtos.OrderByDescending(p=>p.SoldAmount)
        };

        return viewModel;
    }
}
