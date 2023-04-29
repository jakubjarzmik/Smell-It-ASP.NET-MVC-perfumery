using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class ProductCategoryTranslation : BaseTranslation
{
    public int ProductCategoryId { get; set; }
    [ForeignKey("ProductCategoryId")]
    public ProductCategory ProductCategory { get; set; } = default!;

    public override void EncodeName() => 
        EncodedName = Name.ConvertToEncodedName() + "-translation";
}