namespace PoSSapi.Application.Reservations;

using AutoMapper;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

public record ReservationDto : IMapFrom<Reservation>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Time { get; set; }
    public int NumOfPeople { get; set; }
    public int TableNumber { get; set; }
    public ReservationStatus Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Reservation, ReservationDto>();
    }
}
