using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class GenderTranslation : BaseTranslation
{
    [ForeignKey("Gender")]
    public int GenderId { get; set; }
    public Gender Gender { get; set; } = default!;
    
    public override void EncodeName() => 
        EncodedName = Name.ConvertToEncodedName() + "-translation";
}