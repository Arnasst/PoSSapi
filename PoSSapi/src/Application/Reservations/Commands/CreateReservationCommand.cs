using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Reservations.Commands;

public class CreateReservationCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTime Time { get; init; }
    public int NumOfPeople { get; init; }
    public int TableNumber { get; init; }
    public Guid CustomerId { get; init; }
    public ReservationStatus Status { get; init; }
}

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateReservationCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = new Reservation();

        _mapper.Map(request, reservation);
        // var reservation = new Reservation
        // {
        //     Id = request.Id,
        //     Name = request.Name,
        //     Time = request.Time,
        //     NumOfPeople = request.NumOfPeople,
        //     TableNumber = request.TableNumber,
        //     CustomerId = request.CustomerId,
        //     Status = request.Status
        // };

        await _context.Reservations
            .AddAsync(reservation, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return reservation.Id;
    }
}
