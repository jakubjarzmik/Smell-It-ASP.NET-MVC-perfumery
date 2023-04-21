using SmellIt.Application.SmellIt.LayoutTexts;

namespace SmellIt.Application.ViewModels
{
    public class LayoutTextsViewModel
    {
        public IEnumerable<LayoutTextDto>? LayoutTexts { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
