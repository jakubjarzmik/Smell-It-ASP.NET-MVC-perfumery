using MediatR;
using SmellIt.Application.Features.ProductCategories.DTOs;

namespace SmellIt.Application.Features.ProductCategories.Queries.GetAllProductCategoriesForWebsite;
public class GetAllProductCategoriesForWebsiteQuery : IRequest<IEnumerable<WebsiteProductCategoryDto>>
{
    public string LanguageCode { get; set; }
    public GetAllProductCategoriesForWebsiteQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}
