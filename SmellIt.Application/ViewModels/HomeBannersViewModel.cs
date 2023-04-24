using SmellIt.Application.SmellIt.HomeBanners;

namespace SmellIt.Application.ViewModels
{
    public class HomeBannersViewModel
	{
        public IEnumerable<HomeBannerDto>? HomeBanners { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
