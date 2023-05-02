using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        [MaxLength(255)]
        public string ImagePath { get; set; } = default!;

        [MaxLength(50)] 
        public string ImageAlt { get; set; } = default!;

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = default!;
    }
}
