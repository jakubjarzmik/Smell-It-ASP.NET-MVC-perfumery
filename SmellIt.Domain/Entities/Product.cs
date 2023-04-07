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
    public class Product : DictionaryEntity
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; } = default!;

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = default!;

        [ForeignKey("FragranceGroup")]
        public int? FragranceGroupId { get; set; }
        public virtual FragranceGroup? FragranceGroup { get; set; } = default!;

        [ForeignKey("Gender")]
        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; } = default!;

        public virtual ICollection<ProductImage>? ProductImages { get; set; }
    }
}
