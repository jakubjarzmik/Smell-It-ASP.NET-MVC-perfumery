using SmellIt.Application.Features.Brands;
using SmellIt.Application.Features.FragranceCategories;
using SmellIt.Application.Features.Genders;
using SmellIt.Application.Features.ProductCategories;
using SmellIt.Application.Features.ProductImages;
using SmellIt.Application.Features.ProductPrices;

namespace SmellIt.Application.Features.Products;
public class ProductDto
{
    public string EncodedName { get; set; } = default!;
    public string NamePl { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string? DescriptionPl { get; set; }
    public string? DescriptionEn { get; set; }
    public int? Capacity { get; set; }
    public ProductPriceDto Price { get; set; } = default!;
    public ProductPriceDto? PromotionalPrice { get; set; }
    public decimal? Last30DaysLowestPrice { get; set; }
    public ProductCategoryDto? ProductCategory { get; set; }
    public BrandDto? Brand { get; set; }
    public FragranceCategoryDto? FragranceCategory { get; set; }
    public GenderDto? Gender { get; set; }
    public ICollection<ProductImageDto>? ProductImages { get; set; }
}
