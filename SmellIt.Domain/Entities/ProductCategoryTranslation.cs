using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class ProductCategoryTranslation : BaseTranslation
{
    public int ProductCategoryId { get; set; }
    [ForeignKey("ProductCategoryId")]
    public virtual ProductCategory ProductCategory { get; set; } = default!;
}