using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class PaymentTranslation : BaseTranslation
{
    public int PaymentId { get; set; }
    [ForeignKey("PaymentId")]
    public virtual Payment Payment { get; set; } = default!;

}