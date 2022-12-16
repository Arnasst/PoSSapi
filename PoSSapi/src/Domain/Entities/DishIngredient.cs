namespace PoSSapi.Domain.Entities;

public class DishIngredient
{
    public Guid Id { get; set; }
    public Dish Dish { get; set; }
    public Ingredient Ingredient { get; set; }
}
