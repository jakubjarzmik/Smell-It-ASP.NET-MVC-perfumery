using SmellIt.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmellIt.Domain.Entities
{
    public class FragranceCategory : BaseEntity
    {
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<FragranceCategoryTranslation>? FragranceCategoryTranslations { get; set; }


        public string EncodedName { get; private set; } = default!;
        public void EncodeName() => EncodedName = FragranceCategoryTranslations!.First(fct => fct.Language.Code == "en-GB").Name.ToLower().Replace(" ", "-");
    }
}
