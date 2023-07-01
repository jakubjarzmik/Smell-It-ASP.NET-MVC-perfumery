using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Commands.CreateOrder;
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IUserContext _userContext;
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IDeliveryRepository _deliveryRepository;

    public CreateOrderCommandHandler(IUserContext userContext, IOrderRepository orderRepository, IDeliveryRepository deliveryRepository, IUserRepository userRepository, IAddressRepository addressRepository, IOrderStatusRepository orderStatusRepository, ICartItemRepository cartItemRepository)
    {

        _orderRepository = orderRepository;
        _deliveryRepository = deliveryRepository;
        _userRepository = userRepository;
        _addressRepository = addressRepository;
        _orderStatusRepository = orderStatusRepository;
        _cartItemRepository = cartItemRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();
        if (currentUser == null)
        {
            return Unit.Value;
        }

        var user = await _userRepository.GetByEmailAsync(currentUser.Email);
        var address = await _addressRepository.GetAddressAsync(request.FullName, request.FirstLine, request.SecondLine, request.PostalCode, request.City);
        var orderStatus = await _orderStatusRepository.GetByNameAsync("Received");
        var cartItems = await _cartItemRepository.GetByUserAsync(user!.Id);

        var order = CreateOrder(request, user, address, orderStatus!);

        PopulateOrderItems(cartItems, order, user);

        await CalculateTotalPrice(order);

        await _orderRepository.CreateAsync(order);

        return Unit.Value;
    }

    private static Order CreateOrder(CreateOrderCommand request, IdentityUser user, Address address, OrderStatus orderStatus)
    {
        return new Order
        {
            OrderDate = DateTime.Now,
            Notes = request.Notes,
            PhoneNumber = request.PhoneNumber,
            User = user,
            Address = address,
            DeliveryId = request.DeliveryId,
            PaymentId = request.PaymentId,
            OrderStatus = orderStatus!,
            OrderItems = new List<OrderItem>()
        };
    }

    private void PopulateOrderItems(IEnumerable<CartItem> cartItems, Order order, IdentityUser user)
    {
        foreach (var cartItem in cartItems)
        {
            var unitPrice = CalculateUnitPrice(cartItem);
            var orderItem = new OrderItem
            {
                Quantity = cartItem.Quantity,
                UnitPrice = unitPrice,
                TotalPrice = unitPrice * cartItem.Quantity,
                Product = cartItem.Product,
                Order = order,
                CreatedById = user.Id,
            };
            order.OrderItems!.Add(orderItem);
            cartItem.IsActive = false;
        }
    }

    private async Task CalculateTotalPrice(Order order)
    {
        order!.TotalPrice = order.OrderItems!.Sum(oi => oi.TotalPrice) + (await _deliveryRepository.GetAsync(order.DeliveryId))!.Price;
    }
    private static decimal CalculateUnitPrice(CartItem cartItem)
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