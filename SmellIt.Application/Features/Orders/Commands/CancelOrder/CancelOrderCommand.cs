using MediatR;

namespace SmellIt.Application.Features.Orders.Commands.CancelOrder;
public class CancelOrderCommand : IRequest
{
    public int OrderId { get; set; }

    public CancelOrderCommand(int orderId)
    {
        OrderId = orderId;
    }
}
