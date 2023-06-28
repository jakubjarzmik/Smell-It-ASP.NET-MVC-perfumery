using MediatR;
using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.Products.Queries.GetMostPopularProducts;

public class GetMostPopularProductsQuery : IRequest<IEnumerable<WebsiteProductDto>>
{
    public string LanguageCode { get; private set; }

    public GetMostPopularProductsQuery(string languageCode)
    {
        LanguageCode = languageCode;
    }
}