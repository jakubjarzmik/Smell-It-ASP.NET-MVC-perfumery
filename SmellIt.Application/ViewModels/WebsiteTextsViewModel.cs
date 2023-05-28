using SmellIt.Application.Features.WebsiteTexts.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels;

public class WebsiteTextsViewModel : PaginatedViewModel<WebsiteTextForAdminDto>
{
    public WebsiteTextsViewModel(IEnumerable<WebsiteTextForAdminDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}