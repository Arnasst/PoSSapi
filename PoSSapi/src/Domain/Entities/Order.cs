namespace PoSSapi.Domain.Entities;

public class Order
{
    public int ID { get; set; }
    public int CustomerID { get; set; }
    public List<Dish> Dishes { get; set; }
    public List<Payment> Payments { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public string Status { get; set; } // Enum
}
