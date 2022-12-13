namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class Ingredient
{
    public int ID { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public StockStatus StockStatus { get; set; }
}
