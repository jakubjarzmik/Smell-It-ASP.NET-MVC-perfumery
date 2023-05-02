using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class FragranceCategoryTranslation : BaseTranslation
{
    public int FragranceCategoryId { get; set; }
    [ForeignKey("FragranceCategoryId")]
    public virtual FragranceCategory FragranceCategory { get; set; } = default!;
}