namespace PoSSapi.Domain.Entities;

public class Reservation
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime Time { get; set; }
    public int NumOfPeople { get; set; }
    public int TableNumber { get; set; }
    public int CustomerID { get; set; }
    public string Status { get; set; } // Enum
}
