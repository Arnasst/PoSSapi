using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Reservations.Commands;

public class UpdateReservationCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTime Time { get; init; }
    public int NumOfPeople { get; init; }
    public int TableNumber { get; init; }
    public Guid CustomerId { get; init; }
    public ReservationStatus Status { get; init; }
}

public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateReservationCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations
            .FindAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Reservation), request.Id);

        reservation.Id = request.Id;
        reservation.Name = request.Name;
        reservation.Time = request.Time;
        reservation.NumOfPeople = request.NumOfPeople;
        reservation.TableNumber = request.TableNumber;
        reservation.CustomerId = request.CustomerId;
        reservation.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
