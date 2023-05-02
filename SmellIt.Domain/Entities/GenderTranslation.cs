using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class GenderTranslation : BaseTranslation
{
    public int GenderId { get; set; }
    [ForeignKey("GenderId")]
    public virtual Gender Gender { get; set; } = default!;
}