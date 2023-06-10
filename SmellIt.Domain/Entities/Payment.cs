using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class Payment : BaseEntityWithEncodedName
{
    public virtual ICollection<PaymentTranslation> PaymentTranslations { get; set; } = default!;
    public override void EncodeName() =>
        EncodedName = (Id + "-" + PaymentTranslations.First(fct => fct.Language.Code == "en-GB").Name)
            .ConvertToEncodedName();
}