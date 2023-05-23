using MediatR;

namespace SmellIt.Application.Features.ProductCategories.Queries.GetProductCategoryByEncodedName
{
    public class GetProductCategoryByEncodedNameQuery : IRequest<ProductCategoryDto>
    {
        public string EncodedName { get; set; }

        public GetProductCategoryByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
