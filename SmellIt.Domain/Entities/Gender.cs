using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public virtual ICollection<Product> Products { get; set; } = default!;
        public virtual ICollection<GenderTranslation> GenderTranslations { get; set; } = default!;
    }
}
