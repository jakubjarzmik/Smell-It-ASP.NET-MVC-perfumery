using SmellIt.Application.Features.FragranceCategories.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels.Admin;

public class FragranceCategoriesViewModel : PaginatedViewModel<FragranceCategoryDto>
{
    public FragranceCategoriesViewModel(IEnumerable<FragranceCategoryDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}