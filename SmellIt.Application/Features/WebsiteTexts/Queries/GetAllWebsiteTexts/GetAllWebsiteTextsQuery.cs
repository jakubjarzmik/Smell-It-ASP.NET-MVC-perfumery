using MediatR;
using SmellIt.Application.Features.WebsiteTexts.DTOs;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetAllWebsiteTexts
{
    public class GetAllWebsiteTextsQuery : IRequest<IEnumerable<WebsiteTextForAdminDto>>
    {
    }
}
