using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class ProductTranslation : BaseTranslation
{
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = default!;

    public override void EncodeName() => 
        EncodedName = Name.ConvertToEncodedName() + "-translation";
}