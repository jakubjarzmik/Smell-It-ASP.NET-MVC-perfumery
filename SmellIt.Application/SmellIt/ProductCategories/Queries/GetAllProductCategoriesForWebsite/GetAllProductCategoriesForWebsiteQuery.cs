using MediatR;

namespace SmellIt.Application.SmellIt.ProductCategories.Queries.GetAllProductCategoriesForWebsite;
public class GetAllProductCategoriesForWebsiteQuery : IRequest<IEnumerable<WebsiteProductCategoryDto>>
{
    public string LanguageCode { get; set; }
    public GetAllProductCategoriesForWebsiteQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}
