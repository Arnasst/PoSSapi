namespace PoSSapi.Application.Reservations;

using PoSSapi.Domain.Enums;

public record struct ReservationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Time { get; set; }
    public int NumOfPeople { get; set; }
    public int TableNumber { get; set; }
    public ReservationStatus Status { get; set; }
}
