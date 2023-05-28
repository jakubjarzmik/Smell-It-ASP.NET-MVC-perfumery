using MediatR;
using SmellIt.Application.Features.FragranceCategories.DTOs;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategoriesForWebsite;

public class GetAllFragranceCategoriesForWebsiteQuery : IRequest<IEnumerable<WebsiteFragranceCategoryDto>>
{
    public string LanguageCode { get; private set; }

    public GetAllFragranceCategoriesForWebsiteQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}