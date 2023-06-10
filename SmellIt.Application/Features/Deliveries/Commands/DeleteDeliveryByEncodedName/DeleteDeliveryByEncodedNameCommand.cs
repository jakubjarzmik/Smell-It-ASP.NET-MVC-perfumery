using MediatR;

namespace SmellIt.Application.Features.Deliveries.Commands.DeleteDeliveryByEncodedName;

public class DeleteDeliveryByEncodedNameCommand : IRequest
{
    public string EncodedName { get; set; }

    public DeleteDeliveryByEncodedNameCommand(string encodedName)
    {
        EncodedName = encodedName;
    }
}