using MediatR;
using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.Products.Queries.GetProductByEncodedNameForWebsite;

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