using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class BrandTranslation : BaseEntity
{
    public virtual string? Description { get; set; }

    [ForeignKey("Brand")]
    public int BrandId { get; set; }
    public Brand Brand { get; set; } = default!;

    [ForeignKey("Language")]
    public int LanguageId { get; set; }
    public Language Language { get; set; } = default!;
    
    public override void EncodeName() => EncodedName = Brand.EncodedName + "-translation";

}