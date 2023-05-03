using SmellIt.Domain.Entities;

namespace SmellIt.Application.SmellIt.ProductCategories;
public class ProductCategoryDto
{
    public string EncodedName { get; set; } = default!;
    public string NamePl { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string? DescriptionPl { get; set; }
    public string? DescriptionEn { get; set; }
    public ProductCategoryDto? ParentCategory { get; set; }
}
