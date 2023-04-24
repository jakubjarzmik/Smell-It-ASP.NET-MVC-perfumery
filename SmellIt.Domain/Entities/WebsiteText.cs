using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class WebsiteText : BaseEntity
{
    [MaxLength(50)]
    public string Key { get; set; } = default!;
    public virtual List<WebsiteTextTranslation> WebsiteTextTranslations { get; set; } = new();
    
    public override void EncodeName() => EncodedName = Key.ConvertToEncodedName();
}