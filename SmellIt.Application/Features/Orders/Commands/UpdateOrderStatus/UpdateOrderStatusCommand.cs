using MediatR;

namespace SmellIt.Application.Features.Orders.Commands.UpdateOrderStatus;
public class UpdateOrderStatusCommand : IRequest
{
    public int OrderId { get; set; }
    public int OrderStatusId { get; set; }

    public UpdateOrderStatusCommand(int orderId, int orderStatusId)
    {
        OrderId = orderId;
        OrderStatusId = orderStatusId;
    }
}
