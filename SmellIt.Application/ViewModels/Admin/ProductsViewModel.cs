using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels.Admin;

public class ProductsViewModel : PaginatedViewModel<ProductDto>
{
    public ProductsViewModel(IEnumerable<ProductDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}