using SmellIt.Application.Features.Brands;
using SmellIt.Application.Features.FragranceCategories;
using SmellIt.Application.Features.Genders;
using SmellIt.Application.Features.ProductCategories;
using SmellIt.Application.Features.ProductImages;
using SmellIt.Application.Features.ProductPrices;

namespace SmellIt.Application.Features.Products;
public class WebsiteProductDto
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public ProductPriceDto Price { get; set; } = default!;
    public ProductPriceDto? PromotionalPrice { get; set; }
    public decimal? Last30DaysLowestPrice { get; set; }
    public WebsiteProductCategoryDto? ProductCategory { get; set; }
    public WebsiteBrandDto? Brand { get; set; }
    public WebsiteFragranceCategoryDto? FragranceCategory { get; set; }
    public GenderDto? Gender { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<ProductImageDto>? ProductImages { get; set; }
}
