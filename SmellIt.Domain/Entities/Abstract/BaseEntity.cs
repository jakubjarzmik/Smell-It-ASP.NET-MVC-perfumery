using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities.Abstract;
public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("CreatedBy")] 
    public int? CreatedById { get; set; } = 1;
    public virtual User? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [ForeignKey("ModifiedBy")]
    public int? ModifiedById { get; set; }
    public virtual User? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    [ForeignKey("DeletedBy")]
    public int? DeletedById { get; set; }
    public virtual User? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsActive { get; set; } = true;
}