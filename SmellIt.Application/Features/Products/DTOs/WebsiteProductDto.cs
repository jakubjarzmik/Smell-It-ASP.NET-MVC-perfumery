using SmellIt.Application.Features.Brands.DTOs;
using SmellIt.Application.Features.FragranceCategories.DTOs;
using SmellIt.Application.Features.Genders.DTOs;
using SmellIt.Application.Features.ProductCategories.DTOs;
using SmellIt.Application.Features.ProductImages.DTOs;
using SmellIt.Application.Features.ProductPrices.DTOs;

namespace SmellIt.Application.Features.Products.DTOs;
public class WebsiteProductDto
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public ProductPriceDto Price { get; set; } = default!;
    public ProductPriceDto? PromotionalPrice { get; set; }
    public decimal? Last30DaysLowestPrice { get; set; }
    public decimal? SoldAmount { get; set; }
    public ProductCategoryDtoForWebsite? ProductCategory { get; set; }
    public WebsiteBrandDto? Brand { get; set; }
    public WebsiteFragranceCategoryDto? FragranceCategory { get; set; }
    public GenderDto? Gender { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<ProductImageDto>? ProductImages { get; set; }
}
