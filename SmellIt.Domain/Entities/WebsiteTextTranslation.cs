using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class WebsiteTextTranslation : BaseEntity
{
	[MaxLength(255)]
	public string Text { get; set; } = default!;

	public int WebsiteTextId { get; set; }
	[ForeignKey("WebsiteTextId")]
	public WebsiteText WebsiteText { get; set; } = default!;

	public int LanguageId { get; set; }
    [ForeignKey("LanguageId")]
	public Language Language { get; set; } = default!;

    public override void EncodeName() => EncodedName = WebsiteText.EncodedName + "-" + Language.Code + "-translation";
}