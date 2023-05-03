using MediatR;

namespace SmellIt.Application.SmellIt.ProductCategories.Commands.EditProductCategory
{
    public class EditProductCategoryCommand : ProductCategoryDto, IRequest
    {
        public string? ParentCategoryEncodedName { get; set; }
    }
}
