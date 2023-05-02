using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;
public class GenderTranslation : BaseTranslation
{
    public int GenderId { get; set; }
    [ForeignKey("GenderId")]
    public Gender Gender { get; set; } = default!;
}