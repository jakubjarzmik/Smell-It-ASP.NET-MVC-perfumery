using MediatR;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByKey
{
    public class GetWebsiteTextByKeyQuery : IRequest<WebsiteTextDto>
    {
        public string Key { get; set; }

        public GetWebsiteTextByKeyQuery(string key)
        {
            Key = key;
        }
    }
}
