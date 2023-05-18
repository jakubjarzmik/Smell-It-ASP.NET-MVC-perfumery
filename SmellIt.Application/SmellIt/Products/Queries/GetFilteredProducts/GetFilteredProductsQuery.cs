using MediatR;

namespace SmellIt.Application.SmellIt.Products.Queries.GetFilteredProducts
{
    public class GetFilteredProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public string? CategoryEncodedName { get; set; }
        public string? BrandEncodedName { get; set; }
        public string? GenderEncodedName { get; set; }
        public string? FragranceCategoryEncodedName { get; set; }
    }
}
