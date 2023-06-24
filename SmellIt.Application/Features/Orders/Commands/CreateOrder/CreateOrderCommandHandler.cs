using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Commands.CreateOrder;
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        this._deliveryRepository = deliveryRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request);

        order!.TotalPrice = order.OrderItems!.Sum(oi => oi.TotalPrice) + _deliveryRepository.GetAsync(order.DeliveryId).Result!.Price;

        await _orderRepository.CreateAsync(order);

        return Unit.Value;
    }
}