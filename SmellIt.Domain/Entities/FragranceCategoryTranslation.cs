using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class FragranceCategoryTranslation : BaseTranslation
{
    [ForeignKey("FragranceCategory")]
    public int FragranceCategoryId { get; set; }
    public FragranceCategory FragranceCategory { get; set; } = default!;
    
    public override void EncodeName() => 
        EncodedName = Name.ConvertToEncodedName() + "-translation";
}