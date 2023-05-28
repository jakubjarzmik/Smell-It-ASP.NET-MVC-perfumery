using MediatR;
using SmellIt.Application.ViewModels;

namespace SmellIt.Application.Features.ProductCategories.Queries.GetPaginatedProductCategories;

public class GetPaginatedProductCategoriesQuery : IRequest<ProductCategoriesViewModel>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetPaginatedProductCategoriesQuery(int? pageNumber, int pageSize)
    {
        PageNumber = pageNumber ?? 1;
        PageSize = pageSize;
    }
}