using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace SmellIt.Domain.Entities;

public class Address : BaseEntity
{
    [MaxLength(50)]
    public string FullName { get; set; } = default!;
    [MaxLength(50)]
    public string FirstLine { get; set; } = default!;
    [MaxLength(50)]
    public string? SecondLine { get; set; }
    [MaxLength(10)]
    public string PostalCode { get; set; } = default!;
    [MaxLength(50)]
    public string City { get; set; } = default!;
    [MaxLength(50)]
    public string Country { get; set; } = default!;
    public virtual ICollection<Order>? Orders { get; set; }
}