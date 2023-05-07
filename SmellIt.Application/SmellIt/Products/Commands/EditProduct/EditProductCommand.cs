using MediatR;

namespace SmellIt.Application.SmellIt.Products.Commands.EditProduct
{
    public class EditProductCommand : ProductDto, IRequest
    {
        public string? ProductCategoryEncodedName { get; set; }
        public string? BrandEncodedName { get; set; }
        public string? FragranceCategoryEncodedName { get; set; }
        public int? GenderId { get; set; }
    }
}
