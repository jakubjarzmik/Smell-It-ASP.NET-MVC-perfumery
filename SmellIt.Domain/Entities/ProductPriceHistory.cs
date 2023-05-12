using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class ProductPriceHistory : BaseEntity
{
    public int ProductId { get; set; }
    [ForeignKey("ProductId")] 
    public virtual Product Product { get; set; } = default!;
    public decimal Price { get; set; }
}
