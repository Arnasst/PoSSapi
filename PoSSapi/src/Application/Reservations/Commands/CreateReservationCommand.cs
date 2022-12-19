using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Reservations.Commands;

public class CreateReservationCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTime Time { get; init; }
    public int NumOfPeople { get; init; }
    public int TableNumber { get; init; }
    public Guid CustomerId { get; init; }
    public ReservationStatus Status { get; init; }
}

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateReservationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = new Reservation
        {
            Id = request.Id,
            Name = request.Name,
            Time = request.Time,
            NumOfPeople = request.NumOfPeople,
            TableNumber = request.TableNumber,
            CustomerId = request.CustomerId,
            Status = request.Status
        };

        await _context.Reservations
            .AddAsync(reservation, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
