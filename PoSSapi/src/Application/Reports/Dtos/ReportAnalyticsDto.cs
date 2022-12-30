namespace PoSSapi.Application.Reports.Dtos;
public record ReportAnalyticsDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal TotalRevenue { get; set; }
}
