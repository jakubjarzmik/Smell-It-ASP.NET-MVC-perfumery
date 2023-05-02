using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using SmellIt.Domain.Extensions;

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
    }
}
