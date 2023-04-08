using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Entities
{
    public class TranslationPlpl : BaseEntity
    {
        [MaxLength(50)]
        public string Key { get; set; } = default!;
        public string Value { get; set; } = default!;
    }
}
