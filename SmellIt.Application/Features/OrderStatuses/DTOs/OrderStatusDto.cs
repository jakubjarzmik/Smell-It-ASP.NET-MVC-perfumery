namespace SmellIt.Application.Features.OrderStatuses.DTOs;

public class OrderStatusDto
{
    public int Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}