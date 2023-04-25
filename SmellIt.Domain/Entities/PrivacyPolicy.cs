using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities;
public class PrivacyPolicy : BaseEntity
{
    public string Text { get; set; } = default!;

    [ForeignKey("Language")]
	public int LanguageId { get; set; }
	public Language Language { get; set; } = default!;

	public override void EncodeName() => EncodedName = Language.Code + "-privacypolicy";
}