using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;

public class OrderItem : BaseEntity
{
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = default!;

    public int OrderId { get; set; }
    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; } = default!;
}