using MediatR;
using SmellIt.Application.Features.ProductCategories.DTOs;

namespace SmellIt.Application.Features.ProductCategories.Queries.GetAllProductCategories
{
    public class GetAllProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryDto>>
    {
    }
}
