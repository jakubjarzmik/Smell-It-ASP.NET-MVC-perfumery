using SmellIt.Application.Features.Brands.DTOs;
using SmellIt.Application.Features.FragranceCategories.DTOs;
using SmellIt.Application.Features.Genders.DTOs;
using SmellIt.Application.Features.ProductCategories.DTOs;
using SmellIt.Application.Features.ProductImages.DTOs;
using SmellIt.Application.Features.ProductPrices.DTOs;

namespace SmellIt.Application.Features.Products.DTOs;
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
    public string? ProductCategoryEncodedName { get; set; }
    public ProductCategoryDto? ProductCategory { get; set; }
    public string? BrandEncodedName { get; set; }
    public BrandDto? Brand { get; set; }
    public string? FragranceCategoryEncodedName { get; set; }
    public FragranceCategoryDto? FragranceCategory { get; set; }
    public int? GenderId { get; set; }
    public GenderDto? Gender { get; set; }
    public ICollection<ProductImageDto>? ProductImages { get; set; }
}
