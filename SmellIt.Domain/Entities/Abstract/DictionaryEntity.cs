using System.ComponentModel.DataAnnotations;

namespace SmellIt.Domain.Entities.Abstract;
public abstract class DictionaryEntity : BaseEntity
{
    [MaxLength(50)]
    public string NameKey { get; set; } = default!;
    [MaxLength(50)]
    public string? DescriptionKey { get; set; }
}
