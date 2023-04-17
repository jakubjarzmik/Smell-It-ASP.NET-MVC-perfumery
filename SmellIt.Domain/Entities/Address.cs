using SmellIt.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmellIt.Domain.Entities
{
    public class Address : BaseEntity
    {
        [MaxLength(50)]
        public string Street { get; set; } = default!;
        [MaxLength(10)]
        public string PostalCode { get; set; } = default!;
        [MaxLength(50)]
        public string City { get; set; } = default!;
        [MaxLength(50)]
        public string Country { get; set; } = default!;

        public virtual ICollection<User>? Users { get; set; }

        public string EncodedName { get; private set; } = default!;

        public void EncodeName() =>
            EncodedName = Street.ToLower().Replace(" ", "-")
                          + "-" + PostalCode.ToLower().Replace(" ", "-")
                          + "-" + City.ToLower().Replace(" ", "-");
    }
}
