using MediatR;

namespace SmellIt.Application.SmellIt.Products.Queries.GetProductByEncodedNameForWebsite
{
    public class GetProductByEncodedNameForWebsiteQuery : IRequest<WebsiteProductDto>
    {
        public string EncodedName { get; set; }
        public string LanguageCode { get; set; }

        public GetProductByEncodedNameForWebsiteQuery(string encodedName, string languageCode)
        {
            EncodedName = encodedName;
            LanguageCode = languageCode;
        }
    }
}
