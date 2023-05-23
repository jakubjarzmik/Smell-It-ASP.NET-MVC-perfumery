using MediatR;
using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.Products.Queries.GetProductsByCategoryEncodedName
{
    public class GetProductsByCategoryEncodedNameQuery : IRequest<IEnumerable<ProductDto>>
    {
        public string EncodedName { get; set; }

        public GetProductsByCategoryEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
