using MediatR;

namespace SmellIt.Application.SmellIt.ProductCategories.Queries.GetAllProductCategories
{
    public class GetAllProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryDto>>
    {
    }
}
