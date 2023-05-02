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

        public virtual ICollection<BrandTranslation> BrandTranslations { get; set; } = default!;
        public virtual ICollection<FragranceCategoryTranslation> FragranceCategoryTranslations { get; set; } = default!;
        public virtual ICollection<GenderTranslation> GenderTranslations { get; set; } = default!;
        public virtual ICollection<HomeBannerTranslation> HomeBannerTranslations { get; set; } = default!;
        public virtual ICollection<PrivacyPolicy> PrivacyPolicies { get; set; } = default!;
        public virtual ICollection<ProductTranslation> ProductTranslations { get; set; } = default!;
        public virtual ICollection<ProductCategoryTranslation> ProductCategoryTranslations { get; set; } = default!;
        public virtual ICollection<WebsiteTextTranslation> WebsiteTexts { get; set; } = default!;
    }
}
