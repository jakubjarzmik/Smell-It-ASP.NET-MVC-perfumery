using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class Brand : BaseEntity
{
    public string Name { get; set; } = default!;
    public virtual ICollection<Product>? Products { get; set; }
    public virtual ICollection<BrandTranslation>? BrandTranslations { get; set; }

    public string EncodedName { get; private set; } = default!;
    public void EncodeName() => EncodedName = Name.ToLower().Replace(" ","-");
}