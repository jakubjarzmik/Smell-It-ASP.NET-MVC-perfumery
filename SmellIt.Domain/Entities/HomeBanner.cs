using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class HomeBanner : BaseEntityWithEncodedName
{
    [MaxLength(50)]
    public string Key { get; set; } = default!;
    [MaxLength(255)]
    public string ImagePath { get; set; } = default!;
    public virtual ICollection<HomeBannerTranslation> HomeBannerTranslations { get; set; } = default!;
    public override void EncodeName() =>
            EncodedName = (Id + "-" + Key).ConvertToEncodedName();
}