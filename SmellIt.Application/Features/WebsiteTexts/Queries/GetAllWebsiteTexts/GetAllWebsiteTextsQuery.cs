using MediatR;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetAllWebsiteTexts
{
    public class GetAllWebsiteTextsQuery : IRequest<IEnumerable<WebsiteTextForAdminDto>>
    {
    }
}
