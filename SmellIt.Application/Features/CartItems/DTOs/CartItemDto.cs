using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.CartItems.DTOs;
public class CartItemDto
{
    public string Session { get; set; } = default!;
    public string ProductEncodedName { get; set; } = default!;
    public  WebsiteProductDto? Product { get; set; } = default!;
    public decimal Quantity { get; set; }
}
