using MediatR;

namespace SmellIt.Application.Features.Payments.Commands.DeletePaymentByEncodedName;

public class DeletePaymentByEncodedNameCommand : IRequest
{
    public string EncodedName { get; set; }

    public DeletePaymentByEncodedNameCommand(string encodedName)
    {
        EncodedName = encodedName;
    }
}