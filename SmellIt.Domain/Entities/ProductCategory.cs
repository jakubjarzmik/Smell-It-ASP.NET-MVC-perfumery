using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities
{
    public class ProductCategory : BaseEntityWithEncodedName
    {
        public int? ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual ProductCategory? ParentCategory { get; set; }
        public virtual List<ProductCategory> ProductCategories { get; set; } = new();
        public virtual List<Product> Products { get; set; } = new();
        public virtual List<ProductCategoryTranslation> ProductCategoryTranslations { get; set; } = new();
        public override void EncodeName() => 
            EncodedName = (Id + "-" + ProductCategoryTranslations!.First(fct => fct.Language.Code == "en-GB").Name).ConvertToEncodedName();
    }
}
