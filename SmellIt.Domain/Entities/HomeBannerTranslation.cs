using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class HomeBannerTranslation : BaseEntity
{
	[MaxLength(255)]
	public string Text { get; set; } = default!;
    public int HomeBannerId { get; set; }
	[ForeignKey("HomeBannerId")]
    public virtual HomeBanner HomeBanner { get; set; } = default!;
    public int LanguageId { get; set; }
    [ForeignKey("LanguageId")]
    public virtual Language Language { get; set; } = default!;
}