using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Reservations.Commands;

public class DeleteReservationCommand : IRequest
{
    public Guid Id { get; init; }
}

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteReservationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations
            .FindAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Reservation), request.Id);

        _context.Reservations.Remove(reservation);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
