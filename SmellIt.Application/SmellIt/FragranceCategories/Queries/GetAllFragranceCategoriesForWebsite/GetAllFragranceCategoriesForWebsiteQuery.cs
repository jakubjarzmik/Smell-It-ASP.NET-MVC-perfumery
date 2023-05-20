using MediatR;

namespace SmellIt.Application.SmellIt.FragranceCategories.Queries.GetAllFragranceCategoriesForWebsite
{
    public class GetAllFragranceCategoriesForWebsiteQuery : IRequest<IEnumerable<WebsiteFragranceCategoryDto>>
    {
        public string LanguageCode { get; private set; }

        public GetAllFragranceCategoriesForWebsiteQuery(string languageCode)
        {
            LanguageCode = languageCode;
        }
    }
}
