using MediatR;

namespace SmellIt.Application.SmellIt.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : ProductCategoryDto, IRequest
    {
        public string? ParentCategoryEncodedName { get; set; }
    }
}
