using MediatR;
using SmellIt.Application.Features.Deliveries.DTOs;

namespace SmellIt.Application.Features.Deliveries.Queries.GetAllDeliveriesForWebsite;

public class GetAllDeliveriesForWebsiteQuery : IRequest<IEnumerable<WebsiteDeliveryDto>>
{
    public string LanguageCode { get; private set; }

    public GetAllDeliveriesForWebsiteQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}