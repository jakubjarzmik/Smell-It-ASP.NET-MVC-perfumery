using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Commands.UpdateOrderStatus;
public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserContext _userContext;

    public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository, IUserContext userContext)
    {
        _orderRepository = orderRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !(currentUser.IsInRole("Admin") || currentUser.IsInRole("Employee")))
        {
            return Unit.Value;
        }
        var order = await _orderRepository.GetAsync(request.OrderId);

        if (order == null)
            return Unit.Value;

        order.OrderStatusId = request.OrderStatusId;
        order.ModifiedAt = DateTime.Now;
        order.ModifiedById = currentUser.Id;

        await _orderRepository.CommitAsync();

        return Unit.Value;
    }
}