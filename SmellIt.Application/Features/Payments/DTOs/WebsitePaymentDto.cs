namespace SmellIt.Application.Features.Payments.DTOs;
public class WebsitePaymentDto
{
    public int Id { get; set; } = default!;
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
