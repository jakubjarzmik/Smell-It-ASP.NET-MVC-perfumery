using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;

        public virtual ICollection<BrandTranslation>? BrandTranslations { get; set; }
        public virtual ICollection<FragranceCategoryTranslation>? FragranceCategoryTranslations { get; set; }
        public virtual ICollection<GenderTranslation>? GenderTranslations { get; set; }
        public virtual ICollection<ProductTranslation>? ProductTranslations { get; set; }
        public virtual ICollection<ProductCategoryTranslation>? ProductCategoryTranslations { get; set; }

        public string EncodedName { get; private set; } = default!;
        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
