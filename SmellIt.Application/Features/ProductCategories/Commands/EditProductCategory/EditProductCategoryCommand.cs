using MediatR;

namespace SmellIt.Application.Features.ProductCategories.Commands.EditProductCategory
{
    public class EditProductCategoryCommand : ProductCategoryDto, IRequest
    {
        public string? ParentCategoryEncodedName { get; set; }
    }
}
