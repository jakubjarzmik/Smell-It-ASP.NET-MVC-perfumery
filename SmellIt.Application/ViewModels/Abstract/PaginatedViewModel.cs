using SmellIt.Application.Features.Brands.DTOs;

namespace SmellIt.Application.ViewModels.Abstract;
public abstract class PaginatedViewModel<TDto>
{
    public IEnumerable<TDto>? Items { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }

    public PaginatedViewModel(IEnumerable<TDto> items, int totalItems, int currentPage, int pageSize)
    {
        Items = items;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
    }
}
