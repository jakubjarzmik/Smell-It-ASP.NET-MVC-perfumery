using AutoMapper;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.OrderMapping;
public class OrderItemsResolver : IValueResolver<OrderCreateDto, Order, ICollection<OrderItem>?>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IUserContext _userContext;

    public OrderItemsResolver(IOrderItemRepository orderItemRepository, ICartItemRepository cartItemRepository, IUserContext userContext)
    {
        _orderItemRepository = orderItemRepository;
        _cartItemRepository = cartItemRepository;
        _userContext = userContext;
    }

    public ICollection<OrderItem>? Resolve(OrderCreateDto source, Order destination, ICollection<OrderItem>? destMember, ResolutionContext context)
    {
        var cartItems = _cartItemRepository.GetByUserAsync(_userContext.GetCurrentUser()!.Id).Result;
        List<OrderItem> orderItems = new();
        foreach (var cartItem in cartItems)
        {
            var unitPrice = CalculateUnitPrice(cartItem);
            var orderItem = new OrderItem
            {
                Quantity = cartItem.Quantity,
                UnitPrice = unitPrice,
                TotalPrice = unitPrice * cartItem.Quantity,
                Product = cartItem.Product,
                Order = destination,
                CreatedById = _userContext.GetCurrentUser()?.Id
            };
            orderItems.Add(orderItem);
            cartItem.IsActive = false;
        }
        
        return orderItems;
    }

    private decimal CalculateUnitPrice(CartItem cartItem)
    {
        var price = cartItem.Product.ProductPrices
            .Where(pp =>
                pp.IsActive && !pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now) &&
                pp.StartDateTime <= DateTime.Now).MaxBy(pp => pp.StartDateTime)!.Value;
        var promotionalPrice = cartItem.Product.ProductPrices
            .Where(pp =>
                pp.IsActive && pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now) &&
                pp.StartDateTime <= DateTime.Now).MaxBy(pp => pp.StartDateTime)?.Value;
        return promotionalPrice ?? price;
    }
}