namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class Order
{
    public Guid Id { get; set; }
    public int CustomerID { get; set; }
    public List<Dish> Dishes { get; set; }
    public List<Payment> Payments { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public OrderStatus Status { get; set; }
}
