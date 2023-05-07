using MediatR;

namespace SmellIt.Application.SmellIt.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ProductDto, IRequest
    {
        public string? ProductCategoryEncodedName { get; set; }
        public string? BrandEncodedName { get; set; }
        public string? FragranceCategoryEncodedName { get; set; }
        public int? GenderId { get; set; }
    }
}
