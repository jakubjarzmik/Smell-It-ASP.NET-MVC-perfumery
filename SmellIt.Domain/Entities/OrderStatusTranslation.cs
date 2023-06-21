using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class OrderStatusTranslation : BaseTranslation
{
    public int OrderStatusId { get; set; }
    [ForeignKey("OrderStatusId")]
    public virtual OrderStatus OrderStatus { get; set; } = default!;
}