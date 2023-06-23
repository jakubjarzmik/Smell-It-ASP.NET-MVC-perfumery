namespace SmellIt.Application.Features.OrderItems.DTOs;

public class OrderItemDto
{
    public int OrderId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string Product { get; set; } = default!;
    public string? ProductImage { get; set; }
}