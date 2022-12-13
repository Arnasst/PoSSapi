namespace PoSSapi.Domain.Entities;

public class Ingredient
{
    public int ID { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public string StockStatus { get; set; } // Enum
}
