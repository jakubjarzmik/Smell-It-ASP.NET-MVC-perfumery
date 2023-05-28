using MediatR;
using SmellIt.Application.Features.Genders.DTOs;

namespace SmellIt.Application.Features.Genders.Queries.GetAllGendersForWebsite;

public class GetAllGendersForWebsiteQuery : IRequest<IEnumerable<WebsiteGenderDto>>
{
    public string LanguageCode { get; private set; }

    public GetAllGendersForWebsiteQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}