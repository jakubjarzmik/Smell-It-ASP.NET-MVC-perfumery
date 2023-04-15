namespace SmellIt.Application.SmellIt.Brands;
public class BrandDto
{
    public string NameKey { get; set; } = default!;
    public string NamePL { get; set; } = default!;
    public string NameEN { get; set; } = default!;
    public string? DescriptionPL { get; set; }
    public string? DescriptionEN { get; set; }
}
