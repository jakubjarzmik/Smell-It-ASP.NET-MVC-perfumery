namespace SmellIt.Application.Features.Orders.DTOs;

public class OrderCreateDto
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string PhoneNumber { get; set; } = default!;
    public string UserEmail { get; set; } = default!;
    public string? Notes { get; set; }
    public int DeliveryId { get; set; } = default!;
    public int PaymentId { get; set; } = default!;
    // address
    public string FullName { get; set; } = default!;
    public string FirstLine { get; set; } = default!;
    public string? SecondLine { get; set; }
    public string PostalCode { get; set; } = default!;
    public string City { get; set; } = default!;
}