using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities.Abstract;
public abstract class BaseTranslation : BaseEntity
{
    [MaxLength(50)]
    public virtual string Name { get; set; } = default!;
    public virtual string? Description { get; set; }

    [ForeignKey("Language")]
    public int LanguageId { get; set; }
    public virtual Language Language { get; set; } = default!;
}