using SmellIt.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual ICollection<ProductImage>? ProductImages { get; set; }
        public virtual ICollection<ProductTranslation>? ProductTranslations { get; set; }

        public string EncodedName { get; private set; } = default!;
        public void EncodeName() => EncodedName = ProductTranslations!.First(fct => fct.Language.Code == "en-GB").Name.ToLower().Replace(" ", "-");
    }
}
