namespace PoSSapi.Domain.Entities;

public class Report
{
    public int ID { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public float Revenue { get; set; } // Changed from DailyRevenue
    public int? StaffID { get; set; } // Changed to be optional
}
