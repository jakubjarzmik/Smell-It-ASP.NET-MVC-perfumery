using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class ProductPrice : BaseEntity
{
    public decimal Value { get; set; }
    public bool IsPromotion { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")] 
    public virtual Product Product { get; set; } = default!;
}
