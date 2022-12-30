namespace PoSSapi.Application.Reports.Dtos;
public record ReportDto
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Revenue { get; set; }
}
