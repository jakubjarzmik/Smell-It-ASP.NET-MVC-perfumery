namespace SmellIt.Application.SmellIt.Genders;
public class GenderDto
{
    public int Id { get; set; }
    public string NamePl { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string? DescriptionPl { get; set; }
    public string? DescriptionEn { get; set; }
}
