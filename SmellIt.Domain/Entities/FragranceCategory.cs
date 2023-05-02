using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities
{
    public class FragranceCategory : BaseEntityWithEncodedName
    {
        public virtual ICollection<Product> Products { get; set; } = default!;
        public virtual ICollection<FragranceCategoryTranslation> FragranceCategoryTranslations { get; set; } = default!;
        public override void EncodeName() =>
            EncodedName = (Id + "-" + FragranceCategoryTranslations.First(fct => fct.Language.Code == "en-GB").Name)
                                .ConvertToEncodedName();
    }
}
