using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities;
public class HomeBanner : BaseEntity
{
    [MaxLength(50)]
    public string Key { get; set; } = default!;
    [MaxLength(255)]
    public string ImagePath { get; set; } = default!;
    public virtual List<HomeBannerTranslation> HomeBannerTranslations { get; set; } = new();

    public override void EncodeName() => EncodedName = Key.ConvertToEncodedName();
}