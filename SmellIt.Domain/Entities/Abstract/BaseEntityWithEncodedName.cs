using System.ComponentModel.DataAnnotations;

namespace SmellIt.Domain.Entities.Abstract;

public abstract class BaseEntityWithEncodedName : BaseEntity
{
    [MaxLength(50)]
    public string? EncodedName { get; set; }
    public abstract void EncodeName();
}