using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class PrivacyPolicy : BaseEntityWithEncodedName
{
    public string Text { get; set; } = default!;

	public int LanguageId { get; set; }
    [ForeignKey("LanguageId")]
	public Language Language { get; set; } = default!;
    public override void EncodeName() =>
            EncodedName = $"{Id}-{Language.Code}-privacy-policy".ConvertToEncodedName();
}