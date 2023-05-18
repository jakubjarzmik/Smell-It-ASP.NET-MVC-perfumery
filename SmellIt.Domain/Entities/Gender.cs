using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities
{
    public class Gender : BaseEntityWithEncodedName
    {
        public virtual ICollection<Product> Products { get; set; } = default!;
        public virtual ICollection<GenderTranslation> GenderTranslations { get; set; } = default!;
        public override void EncodeName() =>
            EncodedName = (Id + "-" + GenderTranslations.First(fct => fct.Language.Code == "en-GB").Name)
                .ConvertToEncodedName();
    }
}
