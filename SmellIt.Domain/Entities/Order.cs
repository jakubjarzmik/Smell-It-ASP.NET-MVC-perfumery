using Microsoft.AspNetCore.Identity;
using SmellIt.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmellIt.Domain.Entities;

public class Order : BaseEntity
{
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string? Notes { get; set; }

    public string UserId { get; set; } = default!;
    [ForeignKey("UserId")] 
    public virtual IdentityUser User { get; set; } = default!;

    public int AddressId { get; set; } = default!;
    [ForeignKey("AddressId")]
    public virtual Address Address { get; set; } = default!;

    public int DeliveryId { get; set; } = default!;
    [ForeignKey("DeliveryId")]
    public virtual Delivery Delivery { get; set; } = default!;

    public int PaymentId { get; set; } = default!;
    [ForeignKey("PaymentId")]
    public virtual Payment Payment { get; set; } = default!;

    public int OrderStatusId { get; set; } = default!;
    [ForeignKey("OrderStatusId")]
    public virtual OrderStatus OrderStatus { get; set; } = default!;

    public virtual ICollection<OrderItem>? OrderItems { get; set; }
}