using MediatR;
using SmellIt.Application.Features.Payments.DTOs;

namespace SmellIt.Application.Features.Payments.Queries.GetPaymentByEncodedName;

public class GetPaymentByEncodedNameQuery : IRequest<PaymentDto>
{
    public string EncodedName { get; set; }

    public GetPaymentByEncodedNameQuery(string encodedName)
    {
        EncodedName = encodedName;
    }
}