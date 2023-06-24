using SmellIt.Application.Features.Addresses.DTOs;
using SmellIt.Application.Features.OrderItems.DTOs;
using SmellIt.Application.Features.OrderStatuses.DTOs;

namespace SmellIt.Application.Features.Orders.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Notes { get; set; }
    public string? UserEmail { get; set; }
    public AddressDto Address { get; set; } = default!;
    public string Delivery { get; set; } = default!;
    public string Payment { get; set; } = default!;
    public OrderStatusDto OrderStatus { get; set; } = default!;
    public ICollection<OrderItemDto>? OrderItems { get; set; }
}