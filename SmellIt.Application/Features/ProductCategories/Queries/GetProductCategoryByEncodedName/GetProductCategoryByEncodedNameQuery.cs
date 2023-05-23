using MediatR;
using SmellIt.Application.Features.ProductCategories.DTOs;

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
