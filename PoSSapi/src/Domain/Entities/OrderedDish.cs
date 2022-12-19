namespace PoSSapi.Domain.Entities;

public class OrderedDish : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public Order Order { get; set; }
    public Guid OrderId { get; set; }
    public Dish Dish { get; set; }
    public Guid DishId { get; set; }
    public int Quantity { get; set; }
}
