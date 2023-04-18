using SmellIt.Domain.Entities.Abstract;
using SmellIt.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<GenderTranslation>? GenderTranslations { get; set; }
        
        public override void EncodeName() => 
            EncodedName = GenderTranslations!.First(fct => 
                fct.Language.Code == "en-GB").Name.ConvertToEncodedName();
    }
}
