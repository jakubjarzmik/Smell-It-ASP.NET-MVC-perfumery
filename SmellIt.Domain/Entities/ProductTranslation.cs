using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class ProductTranslation : BaseTranslation
{
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;

    public string EncodedName { get; private set; } = default!;
    public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-") + "-translation";
}