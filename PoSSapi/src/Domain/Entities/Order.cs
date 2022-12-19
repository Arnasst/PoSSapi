namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class Order : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public User Customer { get; set; }
    public Guid CustomerId { get; set; }
    public ICollection<OrderedDish> Dishes { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public OrderStatus Status { get; set; }
}
