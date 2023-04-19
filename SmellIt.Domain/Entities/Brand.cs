using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class Brand : BaseEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    public virtual List<Product> Products { get; set; } = new();
    public virtual List<BrandTranslation> BrandTranslations { get; set; } = new();
    
    public override void EncodeName() => EncodedName = Name.ConvertToEncodedName();
}