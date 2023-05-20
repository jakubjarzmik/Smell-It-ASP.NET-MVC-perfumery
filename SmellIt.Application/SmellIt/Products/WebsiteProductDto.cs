using SmellIt.Application.SmellIt.Brands;
using SmellIt.Application.SmellIt.FragranceCategories;
using SmellIt.Application.SmellIt.Genders;
using SmellIt.Application.SmellIt.ProductCategories;
using SmellIt.Application.SmellIt.ProductImages;
using SmellIt.Application.SmellIt.ProductPrices;

namespace SmellIt.Application.SmellIt.Products;
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
