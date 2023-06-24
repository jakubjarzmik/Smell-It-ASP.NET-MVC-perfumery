using MediatR;
using SmellIt.Application.Features.OrderStatuses.DTOs;

namespace SmellIt.Application.Features.OrderStatuses.Queries.GetAllOrderStatuses;

public class GetAllOrderStatusesQuery : IRequest<IEnumerable<OrderStatusDto>>
{
    public string LanguageCode { get; set; }

    public GetAllOrderStatusesQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}