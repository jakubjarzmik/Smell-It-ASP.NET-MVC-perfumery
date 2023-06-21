using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;

public class OrderStatus : BaseEntityWithEncodedName
{
    public virtual ICollection<Order> Orders { get; set; } = default!;
    public virtual ICollection<OrderStatusTranslation> OrderStatusTranslations { get; set; } = default!;
    public override void EncodeName() => 
        EncodedName = (Id + "-" + OrderStatusTranslations!.First(fct => fct.Language.Code == "en-GB").Name).ConvertToEncodedName();
}