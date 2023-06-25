using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Commands.CancelOrder;
public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IUserContext _userContext;

    public CancelOrderCommandHandler(IOrderRepository orderRepository,IOrderStatusRepository orderStatusRepository, IUserContext userContext)
    {
        _orderRepository = orderRepository;
        _orderStatusRepository = orderStatusRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null)
        {
            return Unit.Value;
        }
        var order = await _orderRepository.GetAsync(request.OrderId);

        if (order == null)
            return Unit.Value;

        order.OrderStatusId = (await _orderStatusRepository.GetByNameAsync("Canceled"))!.Id;
        order.ModifiedAt = DateTime.Now;
        order.ModifiedById = currentUser.Id;

        await _orderRepository.CommitAsync();

        return Unit.Value;
    }
}