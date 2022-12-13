namespace PoSSapi.Domain.Entities;

public class Report
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public float Revenue { get; set; } // Changed from DailyRevenue
    public int? StaffID { get; set; }
}
