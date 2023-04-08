using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities.Abstract
{
    public abstract class DictionaryEntity : BaseEntity
    {
        [MaxLength(50)]
        public string NameKey { get; set; } = default!;
        [MaxLength(50)]
        public string? DescriptionKey { get; set; }
    }
}
