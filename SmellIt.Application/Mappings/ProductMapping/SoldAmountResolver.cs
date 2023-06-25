using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.ProductMapping;
public class SoldAmountResolver<T> : IValueResolver<Product, T, decimal?>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;

    public SoldAmountResolver(IOrderItemRepository orderItemRepository, IOrderStatusRepository orderStatusRepository)
    {
        _orderItemRepository = orderItemRepository;
        _orderStatusRepository = orderStatusRepository;
    }
    public decimal? Resolve(Product source, T destination, decimal? destMember, ResolutionContext context)
    {
        var canceledOrderStatus = _orderStatusRepository.GetByNameAsync("Canceled").Result;
        return _orderItemRepository.GetAsync(source).Result?.Where(oi=>oi.Order.OrderStatus != canceledOrderStatus).Sum(oi=>oi.Quantity);
    }
}
