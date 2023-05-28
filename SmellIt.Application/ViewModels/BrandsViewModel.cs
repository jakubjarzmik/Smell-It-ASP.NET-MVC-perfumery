using SmellIt.Application.Features.Brands.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels;

public class BrandsViewModel : PaginatedViewModel<BrandDto>
{
    public BrandsViewModel(IEnumerable<BrandDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}