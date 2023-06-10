namespace SmellIt.Application.Features.Payments.DTOs;
public class WebsitePaymentDto
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
