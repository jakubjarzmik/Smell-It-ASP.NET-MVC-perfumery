namespace SmellIt.Application.Features.Brands.DTOs;
public class WebsiteBrandDto
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
