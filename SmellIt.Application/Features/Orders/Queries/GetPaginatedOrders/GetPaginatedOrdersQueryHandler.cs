using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Queries.GetPaginatedOrders;
public class GetPaginatedOrdersQueryHandler : IRequestHandler<GetPaginatedOrdersQuery, OrdersViewModel>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetPaginatedOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<OrdersViewModel> Handle(GetPaginatedOrdersQuery request, CancellationToken cancellationToken)
    {
        var totalOrders = await _orderRepository.CountAsync();
        var orders = await _orderRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });

        var viewModel = new OrdersViewModel(orderDtos, totalOrders, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
