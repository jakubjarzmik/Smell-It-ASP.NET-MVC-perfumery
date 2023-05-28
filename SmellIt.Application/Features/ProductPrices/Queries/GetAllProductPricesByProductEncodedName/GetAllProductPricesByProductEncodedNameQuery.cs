using MediatR;
using SmellIt.Application.Features.ProductPrices.DTOs;

namespace SmellIt.Application.Features.ProductPrices.Queries.GetAllProductPricesByProductEncodedName;

public class GetAllProductPricesByProductEncodedNameQuery : IRequest<IEnumerable<ProductPriceDto>>
{
    public string EncodedName { get; set; }

    public GetAllProductPricesByProductEncodedNameQuery(string encodedName)
    {
        EncodedName = encodedName;
    }
}