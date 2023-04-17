using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class GenderTranslation : BaseTranslation
{
    [ForeignKey("Gender")]
    public int GenderId { get; set; }
    public Gender Gender { get; set; } = default!;

    public string EncodedName { get; private set; } = default!;
    public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-") + "-translation";
}