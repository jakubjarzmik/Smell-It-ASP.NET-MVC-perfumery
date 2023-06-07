using SmellIt.Application.Features.CartItems.DTOs.Website;

namespace SmellIt.Application.ViewModels.Website;

public class CartViewModel
{
    public IEnumerable<CartItemDtoForView> CartItems { get; set; } = default!;
    public decimal TotalPrice { get; set; }
}