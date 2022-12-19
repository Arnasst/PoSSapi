namespace PoSSapi.Domain.Entities;

public class Dish
{
    public Guid Id { get; set; }
    public ICollection<DishIngredient> Ingredients { get; set; }
    public decimal Price { get; set; }
}
