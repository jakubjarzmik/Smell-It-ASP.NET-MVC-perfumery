using MediatR;
using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.Products.Queries.GetProductByEncodedName;

public class GetProductByEncodedNameQuery : IRequest<ProductDto>
{
    public string EncodedName { get; set; }

    public GetProductByEncodedNameQuery(string encodedName)
    {
        EncodedName = encodedName;
    }
}