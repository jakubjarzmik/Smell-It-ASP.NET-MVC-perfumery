using MediatR;

namespace SmellIt.Application.Features.Brands.Queries.GetAllBrandsForWebsite;
public class GetAllBrandsForWebsiteQuery : IRequest<IEnumerable<WebsiteBrandDto>>
{
    public string LanguageCode { get; private set; }

    public GetAllBrandsForWebsiteQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}