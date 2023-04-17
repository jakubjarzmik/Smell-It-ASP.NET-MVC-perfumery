using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class FragranceCategoryTranslation : BaseTranslation
{
    [ForeignKey("FragranceCategory")]
    public int FragranceCategoryId { get; set; }
    public FragranceCategory FragranceCategory { get; set; } = default!;

    public string EncodedName { get; private set; } = default!;
    public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-") + "-translation";
}