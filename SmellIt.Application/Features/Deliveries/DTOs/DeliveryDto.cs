namespace SmellIt.Application.Features.Deliveries.DTOs;
public class DeliveryDto
{
    public string EncodedName { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public string NamePl { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string? DescriptionPl { get; set; }
    public string? DescriptionEn { get; set; }
}
