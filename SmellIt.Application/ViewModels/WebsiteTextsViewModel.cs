using SmellIt.Application.SmellIt.WebsiteTexts;

namespace SmellIt.Application.ViewModels
{
    public class WebsiteTextsViewModel
    {
        public IEnumerable<WebsiteTextDto>? WebsiteTexts { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
