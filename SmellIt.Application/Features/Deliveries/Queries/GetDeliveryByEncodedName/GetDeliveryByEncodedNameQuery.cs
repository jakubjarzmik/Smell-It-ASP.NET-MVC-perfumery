using MediatR;
using SmellIt.Application.Features.Deliveries.DTOs;

namespace SmellIt.Application.Features.Deliveries.Queries.GetDeliveryByEncodedName;

public class GetDeliveryByEncodedNameQuery : IRequest<DeliveryDto>
{
    public string EncodedName { get; set; }

    public GetDeliveryByEncodedNameQuery(string encodedName)
    {
        EncodedName = encodedName;
    }
}