using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities
{
    public class ProductCategory : BaseEntityWithEncodedName
    {
        public int? ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual ProductCategory? ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = default!;
        public virtual ICollection<Product> Products { get; set; } = default!;
        public virtual ICollection<ProductCategoryTranslation> ProductCategoryTranslations { get; set; } = default!;
        public override void EncodeName() => 
            EncodedName = (Id + "-" + ProductCategoryTranslations!.First(fct => fct.Language.Code == "en-GB").Name).ConvertToEncodedName();
    }
}
