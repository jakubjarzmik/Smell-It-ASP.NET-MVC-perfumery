using MediatR;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetAllWebsiteTexts
{
    public class GetAllWebsiteTextsQuery : IRequest<IEnumerable<WebsiteTextDto>>
    {
    }
}
