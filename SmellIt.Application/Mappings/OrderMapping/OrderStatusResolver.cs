using AutoMapper;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.OrderMapping;
public class OrderStatusResolver : IValueResolver<OrderCreateDto, Order, OrderStatus>
{
    private readonly IOrderStatusRepository _orderStatusRepository;

    public OrderStatusResolver(IOrderStatusRepository orderStatusRepository)
    {
        _orderStatusRepository = orderStatusRepository;
    }

    public OrderStatus Resolve(OrderCreateDto source, Order destination, OrderStatus destMember, ResolutionContext context)
    {
        return _orderStatusRepository.GetByName("Received").Result!;
    }
}