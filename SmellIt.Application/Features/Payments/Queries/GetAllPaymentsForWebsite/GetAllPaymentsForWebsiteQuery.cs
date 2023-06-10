using MediatR;
using SmellIt.Application.Features.Payments.DTOs;

namespace SmellIt.Application.Features.Payments.Queries.GetAllPaymentsForWebsite;

public class GetAllPaymentsForWebsiteQuery : IRequest<IEnumerable<WebsitePaymentDto>>
{
    public string LanguageCode { get; private set; }

    public GetAllPaymentsForWebsiteQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}