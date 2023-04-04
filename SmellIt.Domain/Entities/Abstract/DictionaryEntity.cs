using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities.Abstract
{
    public abstract class DictionaryEntity : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
