using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory Category { get; set; } = default!;

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; } = default!;

        public int? FragranceCategoryId { get; set; }
        [ForeignKey("FragranceCategoryId")]
        public virtual FragranceCategory? FragranceCategory { get; set; } = default!;

        public int? GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender? Gender { get; set; } = default!;

        public virtual List<ProductImage> ProductImages { get; set; } = new();
        public virtual List<ProductTranslation> ProductTranslations { get; set; } = new();
        
        public override void EncodeName() => 
            EncodedName = ProductTranslations!.First(fct => 
                fct.Language.Code == "en-GB").Name.ConvertToEncodedName();
    }
}
