using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;

public class SocialSite : BaseEntityWithEncodedName
{
    [MaxLength(255)] 
    public string Link { get; set; } = default!;
    [MaxLength(50)]
    public string Type { get; set; } = default!;
    public override void EncodeName() =>
        EncodedName = (Id + "-" + Type).ConvertToEncodedName();
}