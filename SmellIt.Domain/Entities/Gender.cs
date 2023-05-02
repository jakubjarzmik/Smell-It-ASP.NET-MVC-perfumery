using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;

namespace SmellIt.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public virtual List<Product> Products { get; set; } = new();
        public virtual List<GenderTranslation> GenderTranslations { get; set; } = new();
    }
}
