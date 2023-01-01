namespace PoSSapi.Application.Reports.Dtos;
public record ReportsAnalyticsDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal TotalRevenue { get; set; }
}
