using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class FragranceCategoryTranslation : BaseTranslation
{
    public int FragranceCategoryId { get; set; }
    [ForeignKey("FragranceCategoryId")]
    public FragranceCategory FragranceCategory { get; set; } = default!;
}