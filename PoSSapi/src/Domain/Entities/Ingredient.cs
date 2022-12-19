namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class Ingredient : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public StockStatus StockStatus { get; set; }
}
