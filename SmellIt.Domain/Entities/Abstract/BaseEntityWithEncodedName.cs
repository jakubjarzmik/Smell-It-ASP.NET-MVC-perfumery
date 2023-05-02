using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities.Abstract
{
    public abstract class BaseEntityWithEncodedName : BaseEntity
    {
        [MaxLength(50)]
        public string? EncodedName { get; set; }
        public abstract void EncodeName();
    }
}
