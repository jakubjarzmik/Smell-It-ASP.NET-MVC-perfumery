using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities.Abstract;
public class BaseTranslation : BaseEntity
{
    public virtual string Name { get; set; } = default!;
    public virtual string? Description { get; set; }

    [ForeignKey("Language")]
    public int LanguageId { get; set; }
    public Language Language { get; set; } = default!;
}