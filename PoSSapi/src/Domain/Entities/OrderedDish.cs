namespace PoSSapi.Domain.Entities;

public class OrderedDish
{
    public Guid Id { get; set; }
    public Order Order { get; set; }
    public Dish Dish { get; set; }
    public int Quantity { get; set; }
}
