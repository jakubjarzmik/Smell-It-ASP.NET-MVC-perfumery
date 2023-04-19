namespace SmellIt.Application.SmellIt.FragranceCategories;
public class FragranceCategoryDto
{
    public string EncodedName { get; set; } = default!;
    public string NamePL { get; set; } = default!;
    public string NameEN { get; set; } = default!;
    public string? DescriptionPL { get; set; }
    public string? DescriptionEN { get; set; }
}
