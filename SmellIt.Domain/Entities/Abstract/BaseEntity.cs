using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SmellIt.Domain.Entities.Abstract;
public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? CreatedById { get; set; }
    [ForeignKey("CreatedById")]
    public virtual IdentityUser? CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedById { get; set; }
    [ForeignKey("ModifiedById")]
    public virtual IdentityUser? ModifiedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedById { get; set; }
    [ForeignKey("DeletedById")]
    public virtual IdentityUser? DeletedBy { get; set; }
    public bool IsActive { get; set; } = true;
}