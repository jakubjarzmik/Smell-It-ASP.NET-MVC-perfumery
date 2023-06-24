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
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetHomeDataQueryHandler(IProductRepository productRepository, IOrderRepository orderRepository, IUserRepository userRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
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
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

        var viewModel = new HomeViewModel
        {
            ProductsCount = await _productRepository.CountAsync(),
            MonthlyPurchases = await _orderRepository.CountLastMonthAsync(),
            MonthlyEarnings = (int)await _orderRepository.CountMonthlyEarningsAsync(),
            UsersCount = await _userRepository.CountAsync(),
            RecentOrders = orderDtos,
            MostPopularProducts = productDtos.OrderByDescending(p=>p.SoldAmount)
        };

        return viewModel;
    }
}
