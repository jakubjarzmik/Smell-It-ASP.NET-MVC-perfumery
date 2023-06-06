using SmellIt.Application.Features.ProductCategories.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels.Admin;

public class ProductCategoriesViewModel : PaginatedViewModel<ProductCategoryDto>
{
    public ProductCategoriesViewModel(IEnumerable<ProductCategoryDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}