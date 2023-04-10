using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class TranslationEngb : BaseEntity
{
    [MaxLength(50)]
    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;
}
