using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;

public class CartItem : BaseEntity
{
    public string Session { get; set; } = default!;
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = default!;
    public decimal Quantity { get; set; }
}