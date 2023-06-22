using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.ProductMapping;
public class SoldAmountResolver<T> : IValueResolver<Product, T, decimal?>
{
    private readonly IOrderItemRepository _orderItemRepository;

    public SoldAmountResolver(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }
    public decimal? Resolve(Product source, T destination, decimal? destMember, ResolutionContext context)
    {
        return _orderItemRepository.GetAsync(source).Result?.Sum(oi=>oi.Quantity);
    }
}
