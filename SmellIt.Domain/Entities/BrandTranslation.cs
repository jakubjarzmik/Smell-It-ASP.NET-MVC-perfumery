using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class BrandTranslation : BaseEntity
{
    public virtual string? Description { get; set; }

    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    public Brand Brand { get; set; } = default!;

    public int LanguageId { get; set; }
    [ForeignKey("LanguageId")]
    public Language Language { get; set; } = default!;

}