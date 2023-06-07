using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.CartItems.DTOs.Website;
public class CartItemDtoForAdd
{
    public string Session { get; set; } = default!;
    public string ProductEncodedName { get; set; } = default!;
    public WebsiteProductDto? Product { get; set; } = default!;
    public decimal Quantity { get; set; }
}
