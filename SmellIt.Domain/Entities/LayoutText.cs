using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class LayoutText : BaseEntity
{
    [MaxLength(50)]
    public string Key { get; set; } = default!;
    public virtual List<LayoutTextTranslation> LayoutTextTranslations { get; set; } = new();
    
    public override void EncodeName() => EncodedName = Key.ConvertToEncodedName();
}