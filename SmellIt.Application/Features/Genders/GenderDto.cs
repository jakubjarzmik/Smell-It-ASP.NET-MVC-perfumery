namespace SmellIt.Application.Features.Genders;
public class GenderDto
{
    public int Id { get; set; }
    public string EncodedName { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string NamePl { get; set; } = default!;

}
