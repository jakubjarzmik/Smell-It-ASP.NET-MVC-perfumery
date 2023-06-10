using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class DeliveryTranslation : BaseTranslation
{
    public int DeliveryId { get; set; }
    [ForeignKey("DeliveryId")]
    public virtual Delivery Delivery { get; set; } = default!;

}