using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;

public class User : IdentityUser
{
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;
    [MaxLength(50)]
    public string LastName { get; set; } = default!;


    public int? AddressId { get; set; }
    [ForeignKey("AddressId")]
    public virtual Address? Address { get; set; }
}