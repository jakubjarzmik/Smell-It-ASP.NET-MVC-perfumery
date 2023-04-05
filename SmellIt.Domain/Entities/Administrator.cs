using SmellIt.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities
{
    public class Administrator : User
    {
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }
    }
}
