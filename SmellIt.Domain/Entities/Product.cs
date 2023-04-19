using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities
{
    public class Product : BaseEntity
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; } = default!;

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = default!;

        [ForeignKey("FragranceCategory")]
        public int? FragranceCategoryId { get; set; }
        public virtual FragranceCategory? FragranceCategory { get; set; } = default!;

        [ForeignKey("Gender")]
        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; } = default!;

        public virtual List<ProductImage> ProductImages { get; set; } = new();
        public virtual List<ProductTranslation> ProductTranslations { get; set; } = new();
        
        public override void EncodeName() => 
            EncodedName = ProductTranslations!.First(fct => 
                fct.Language.Code == "en-GB").Name.ConvertToEncodedName();
    }
}
