using SmellIt.Application.SmellIt.Brands;
using SmellIt.Application.SmellIt.FragranceCategories;
using SmellIt.Application.SmellIt.Genders;
using SmellIt.Application.SmellIt.ProductCategories;
using SmellIt.Application.SmellIt.ProductImages;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.SmellIt.Products;
public class ProductDto
{
    public string EncodedName { get; set; } = default!;
    public string NamePl { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string? DescriptionPl { get; set; }
    public string? DescriptionEn { get; set; }
    public int? Capacity { get; set; }
    public decimal Price { get; set; } = default!;
    public decimal? PromotionalPrice { get; set; }
    public decimal? Last30DaysLowestPrice { get; set; }
    public ProductCategoryDto? ProductCategory { get; set; }
    public BrandDto? Brand { get; set; }
    public FragranceCategoryDto? FragranceCategory { get; set; }
    public GenderDto? Gender { get; set; }
    public ICollection<ProductImageDto>? ProductImages { get; set; }
}
