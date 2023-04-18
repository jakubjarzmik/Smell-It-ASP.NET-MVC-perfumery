namespace SmellIt.Application.SmellIt.Brands;
public class BrandDto
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? DescriptionPL { get; set; }
    public string? DescriptionEN { get; set; }
}
