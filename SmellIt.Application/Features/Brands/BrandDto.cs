namespace SmellIt.Application.Features.Brands;
public class BrandDto
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? DescriptionPl { get; set; }
    public string? DescriptionEn { get; set; }
}
