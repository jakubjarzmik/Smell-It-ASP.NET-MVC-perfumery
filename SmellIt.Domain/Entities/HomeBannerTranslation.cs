using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class HomeBannerTranslation : BaseEntity
{
	[MaxLength(255)]
	public string Text { get; set; } = default!;

	[ForeignKey("HomeBanner")]
	public int HomeBannerId { get; set; }
	public HomeBanner HomeBanner { get; set; } = default!;

	[ForeignKey("Language")]
	public int LanguageId { get; set; }
	public Language Language { get; set; } = default!;

	public override void EncodeName() => EncodedName = HomeBanner.EncodedName + "-" + Language.Code + "-translation";
}