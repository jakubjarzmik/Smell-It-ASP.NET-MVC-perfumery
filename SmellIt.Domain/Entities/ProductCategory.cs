using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }
        public virtual ProductCategory? ParentCategory { get; set; }

        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<ProductCategoryTranslation>? ProductCategoryTranslations { get; set; }
        
        public override void EncodeName() => 
            EncodedName = ProductCategoryTranslations!.First(fct => 
                fct.Language.Code == "en-GB").Name.ConvertToEncodedName();
    }
}
