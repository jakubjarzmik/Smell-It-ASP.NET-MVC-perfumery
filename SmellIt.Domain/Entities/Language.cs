using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities
{
    public class Language : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; } = default!;
        [MaxLength(10)]
        public string Code { get; set; } = default!;

        public virtual List<BrandTranslation> BrandTranslations { get; set; } = new();
        public virtual List<FragranceCategoryTranslation> FragranceCategoryTranslations { get; set; } = new();
        public virtual List<GenderTranslation> GenderTranslations { get; set; } = new();
        public virtual List<HomeBannerTranslation> HomeBannerTranslations { get; set; } = new();
        public virtual List<ProductTranslation> ProductTranslations { get; set; } = new();
        public virtual List<ProductCategoryTranslation> ProductCategoryTranslations { get; set; } = new();
        public virtual List<WebsiteTextTranslation> WebsiteTexts { get; set; } = new();
        
        public override void EncodeName() => 
            EncodedName = Name.ConvertToEncodedName();
    }
}
