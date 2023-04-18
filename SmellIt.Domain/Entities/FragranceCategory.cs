using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
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

        public override void EncodeName() => 
            EncodedName = FragranceCategoryTranslations!.First(fct => 
                fct.Language.Code == "en-GB").Name.ConvertToEncodedName();
    }
}
