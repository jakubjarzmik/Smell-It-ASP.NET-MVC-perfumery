using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities
{
    public class FragranceCategory : BaseEntityWithEncodedName
    {
        public virtual List<Product> Products { get; set; } = new();
        public virtual List<FragranceCategoryTranslation> FragranceCategoryTranslations { get; set; } = new();
        public override void EncodeName() =>
            EncodedName = (Id + "-" + FragranceCategoryTranslations.First(fct => fct.Language.Code == "en-GB").Name)
                                .ConvertToEncodedName();
    }
}
