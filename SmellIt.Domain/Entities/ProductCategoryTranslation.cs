using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class ProductCategoryTranslation : BaseTranslation
{
    [ForeignKey("ProductCategory")]
    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; } = default!;

    public string EncodedName { get; private set; } = default!;
    public void EncodeName() => EncodedName = Name.ToLower().Replace(" ","-") + "-translation";
}