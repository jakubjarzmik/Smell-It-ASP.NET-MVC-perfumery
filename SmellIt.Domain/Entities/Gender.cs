using SmellIt.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities
{
    public class Gender : DictionaryEntity
    {
        public virtual ICollection<Product>? Products { get; set; }
    }
}
