using MediatR;

namespace SmellIt.Application.Features.WebsiteTexts.Queries.GetWebsiteTextByKey
{
    public class GetWebsiteTextByKeyQuery : IRequest<WebsiteTextDto>
    {
        public string Key { get; set; }
        public string LanguageCode { get; set; }

        public GetWebsiteTextByKeyQuery(string key, string languageCode)
        {
            Key = key;
            LanguageCode = languageCode;
        }
    }
}
