namespace SmellIt.Application.ViewModels.Abstract;
public abstract class PaginatedViewModel<TDto>
{
    public IEnumerable<TDto>? Items { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
}
