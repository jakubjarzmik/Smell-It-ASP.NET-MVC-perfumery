using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class ProductTranslation : BaseTranslation
{
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;
    
    public override void EncodeName() => 
        EncodedName = Name.ConvertToEncodedName() + "-translation";
}