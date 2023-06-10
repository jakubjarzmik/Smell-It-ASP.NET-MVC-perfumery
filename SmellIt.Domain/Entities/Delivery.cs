using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class Delivery : BaseEntityWithEncodedName
{
    public decimal Price { get; set; }
    public virtual ICollection<DeliveryTranslation> DeliveryTranslations { get; set; } = default!;
    public override void EncodeName() =>
        EncodedName = (Id + "-" + DeliveryTranslations.First(fct => fct.Language.Code == "en-GB").Name)
            .ConvertToEncodedName();
}