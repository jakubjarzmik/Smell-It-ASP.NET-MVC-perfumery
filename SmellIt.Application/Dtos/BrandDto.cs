using System.ComponentModel.DataAnnotations;

namespace SmellIt.Application.Dtos;
public class BrandDto
{
    [Required(ErrorMessage = "Nazwa jest wymagana")]
    [StringLength(50, MinimumLength = 2,ErrorMessage = "Minimalna ilość znaków wynosi 2")]
    public String NamePL { get; set; } = default!;
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The minimum number of characters is 2.")]
    public String NameEN { get; set; } = default!;
    public String? DescriptionPL { get; set; }
    public String? DescriptionEN { get; set; }
}
