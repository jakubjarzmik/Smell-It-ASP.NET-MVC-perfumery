using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class Brand : BaseEntityWithEncodedName
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    public virtual ICollection<Product> Products { get; set; } = default!;
    public virtual ICollection<BrandTranslation> BrandTranslations { get; set; } = default!;

    public override void EncodeName() => EncodedName = $"{Id}-{Name}".ConvertToEncodedName();
}