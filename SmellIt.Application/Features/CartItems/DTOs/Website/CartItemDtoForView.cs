using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.CartItems.DTOs.Website;
public class CartItemDtoForView
{
    public string ImageUrl { get; set; } = default!;
    public string ImageAlt { get; set; } = default!;
    public string ProductEncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string ProductInfo { get; set; } = default!;
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal? PromotionalPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal? TotalPromotionalPrice { get; set; }
}
