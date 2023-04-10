using System.ComponentModel.DataAnnotations;

namespace SmellIt.Application.Dtos;
public class BrandDto
{
    public String NamePL { get; set; } = default!;
    public String NameEN { get; set; } = default!;
    public String? DescriptionPL { get; set; }
    public String? DescriptionEN { get; set; }
}
