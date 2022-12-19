namespace PoSSapi.Domain.Entities;

public class Discount
{
    public Guid Id { get; set; }
    public List<Guid> AppliesTo { get; set; }
    public decimal Amount { get; set; }
    public bool IsPercentage { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
