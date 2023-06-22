using SmellIt.Application.Features.Addresses.DTOs;

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
    public string OrderStatus { get; set; } = default!;
}