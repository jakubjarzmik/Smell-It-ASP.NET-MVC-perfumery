using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class LayoutTextTranslation : BaseEntity
{
	[MaxLength(255)]
	public string Text { get; set; } = default!;

	[ForeignKey("LayoutText")]
	public int LayoutTextId { get; set; }
	public LayoutText LayoutText { get; set; } = default!;

	[ForeignKey("Language")]
	public int LanguageId { get; set; }
	public Language Language { get; set; } = default!;

	public override void EncodeName() => EncodedName = LayoutText.EncodedName + "-translation";
}