using MediatR;
using SmellIt.Application.Features.OrderStatuses.DTOs;

namespace SmellIt.Application.Features.OrderStatuses.Queries.GetCanceledOrderStatus;

public class GetReceivedOrderStatusQuery : IRequest<OrderStatusDto>
{
    public string LanguageCode { get; set; }

    public GetReceivedOrderStatusQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}