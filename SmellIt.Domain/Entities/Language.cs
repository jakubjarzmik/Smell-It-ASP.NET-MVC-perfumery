using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public virtual ICollection<BrandTranslation>? BrandTranslations { get; set; }
        public virtual ICollection<FragranceCategoryTranslation>? FragranceCategoryTranslations { get; set; }
        public virtual ICollection<GenderTranslation>? GenderTranslations { get; set; }
        public virtual ICollection<ProductTranslation>? ProductTranslations { get; set; }
        public virtual ICollection<ProductCategoryTranslation>? ProductCategoryTranslations { get; set; }
        
        public override void EncodeName() => 
            EncodedName = Name.ConvertToEncodedName();
    }
}
