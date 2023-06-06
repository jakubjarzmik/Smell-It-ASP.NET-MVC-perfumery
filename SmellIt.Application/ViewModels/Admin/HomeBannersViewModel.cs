using SmellIt.Application.Features.HomeBanners.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels.Admin;

public class HomeBannersViewModel : PaginatedViewModel<HomeBannerDto>
{
    public HomeBannersViewModel(IEnumerable<HomeBannerDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}