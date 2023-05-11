using MediatR;

namespace SmellIt.Application.SmellIt.Products.Queries.GetProductsByCategoryEncodedName
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
