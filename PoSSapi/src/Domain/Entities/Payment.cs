namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class Payment
{
    public Guid Id { get; set; }
    public User Customer { get; set; }
    public Guid CustomerId { get; set; }
    public Order Order { get; set; }
    public Guid OrderId { get; set; }
    public decimal PriceOfOrder { get; set; }
    public decimal Discount { get; set; }
    public decimal Tip { get; set; }
    public PaymentOption PaymentOptions { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime TimeWhenCompleted { get; set; }
}
