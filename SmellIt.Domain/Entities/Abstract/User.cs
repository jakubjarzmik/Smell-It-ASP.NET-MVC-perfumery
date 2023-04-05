using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Domain.Entities.Abstract
{
    public abstract class User : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = default!;
        [MaxLength(50)]
        public string LastName { get; set; } = default!;
        [MaxLength(255)]
        public string Email { get; set; } = default!;
        [MaxLength(50)]
        public string Password { get; set; } = default!;
    }
}
