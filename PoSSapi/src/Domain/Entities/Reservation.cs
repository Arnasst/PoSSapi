namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class Reservation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Time { get; set; }
    public int NumOfPeople { get; set; }
    public int TableNumber { get; set; }
    public int CustomerID { get; set; }
    public ReservationStatus Status { get; set; }
}
