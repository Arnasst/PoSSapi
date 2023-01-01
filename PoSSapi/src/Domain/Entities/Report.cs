namespace PoSSapi.Domain.Entities;
public class Report
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Revenue { get; set; }
}
