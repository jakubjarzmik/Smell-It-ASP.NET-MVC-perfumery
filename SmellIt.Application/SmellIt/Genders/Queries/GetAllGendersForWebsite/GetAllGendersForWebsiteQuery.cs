using MediatR;

namespace SmellIt.Application.SmellIt.Genders.Queries.GetAllGendersForWebsite
{
    public class GetAllGendersForWebsiteQuery : IRequest<IEnumerable<WebsiteGenderDto>>
    {
        public string LanguageCode { get; private set; }

        public GetAllGendersForWebsiteQuery(string languageCode)
        {
            LanguageCode = languageCode;
        }
    }
}
