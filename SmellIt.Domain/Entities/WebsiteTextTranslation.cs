using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class WebsiteTextTranslation : BaseEntity
{
	[MaxLength(255)]
	public string Text { get; set; } = default!;

	[ForeignKey("WebsiteText")]
	public int WebsiteTextId { get; set; }
	public WebsiteText WebsiteText { get; set; } = default!;

	[ForeignKey("Language")]
	public int LanguageId { get; set; }
	public Language Language { get; set; } = default!;

	public override void EncodeName() => EncodedName = WebsiteText.EncodedName + "-" + Language.Code + "-translation";
}