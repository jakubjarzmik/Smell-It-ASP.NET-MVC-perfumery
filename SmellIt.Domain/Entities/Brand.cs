using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class Brand : BaseEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    public virtual ICollection<Product>? Products { get; set; }
    public virtual ICollection<BrandTranslation>? BrandTranslations { get; set; }
    
    public override void EncodeName() => EncodedName = Name.ConvertToEncodedName();
}