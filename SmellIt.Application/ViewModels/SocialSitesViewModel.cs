using SmellIt.Application.SmellIt.SocialSites;

namespace SmellIt.Application.ViewModels
{
    public class SocialSitesViewModel
    {
        public IEnumerable<SocialSiteDto>? SocialSites { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
