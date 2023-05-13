using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities
{
    public class Product : BaseEntityWithEncodedName
    {
        public int? Capacity { get; set; }
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory? ProductCategory { get; set; }

        public int? BrandId { get; set; }
        [ForeignKey("BrandId")] 
        public virtual Brand? Brand { get; set; } = default!;

        public int? FragranceCategoryId { get; set; }
        [ForeignKey("FragranceCategoryId")]
        public virtual FragranceCategory? FragranceCategory { get; set; }

        public int? GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender? Gender { get; set; }

        public virtual ICollection<ProductImage>? ProductImages { get; set; }
        public virtual ICollection<ProductTranslation> ProductTranslations { get; set; } = default!;
        public virtual ICollection<ProductPrice> ProductPrices { get; set; } = default!;

        public override void EncodeName() => 
            EncodedName = (Id + "-" + ProductTranslations.First(fct => fct.Language.Code == "en-GB").Name)
                                .ConvertToEncodedName();
    }
}
