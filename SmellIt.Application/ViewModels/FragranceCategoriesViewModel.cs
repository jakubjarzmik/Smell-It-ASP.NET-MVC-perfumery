using SmellIt.Application.SmellIt.FragranceCategories;

namespace SmellIt.Application.ViewModels
{
    public class FragranceCategoriesViewModel
    {
        public IEnumerable<FragranceCategoryDto>? FragranceCategories { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
