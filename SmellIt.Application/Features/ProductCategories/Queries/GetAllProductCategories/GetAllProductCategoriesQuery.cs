using MediatR;

namespace SmellIt.Application.Features.ProductCategories.Queries.GetAllProductCategories
{
    public class GetAllProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryDto>>
    {
    }
}
