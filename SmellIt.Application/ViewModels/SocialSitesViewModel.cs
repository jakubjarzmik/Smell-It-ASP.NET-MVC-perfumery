using SmellIt.Application.Features.SocialSites.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels
{
    public class SocialSitesViewModel : PaginatedViewModel<SocialSiteDto>
    {
        public SocialSitesViewModel(IEnumerable<SocialSiteDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
        {
        }
    }
}
