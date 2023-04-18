using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class ProductCategoryTranslation : BaseTranslation
{
    [ForeignKey("ProductCategory")]
    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; } = default!;
    
    public override void EncodeName() => 
        EncodedName = Name.ConvertToEncodedName() + "-translation";
}