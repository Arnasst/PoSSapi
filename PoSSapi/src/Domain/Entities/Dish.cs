namespace PoSSapi.Domain.Entities;

public class Dish
{
    public Guid Id { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public decimal Price { get; set; }
}
