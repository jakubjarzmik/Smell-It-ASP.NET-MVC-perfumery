using MediatR;

namespace SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByEncodedName
{
    public class GetWebsiteTextByEncodedNameQuery : IRequest<WebsiteTextDto>
    {
        public string EncodedName { get; set; }

        public GetWebsiteTextByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
