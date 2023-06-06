
using SmellIt.Application.Features.CartItems.DTOs;

namespace SmellIt.Application.ViewModels.Website;

public class CartViewModel
{
    public IEnumerable<CartItemDto> CartItems { get; set; } = default!;
    public decimal TotalPrice { get; set; }
}