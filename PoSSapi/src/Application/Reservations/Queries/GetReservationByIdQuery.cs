using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Reservations.Commands;

public record GetReservationByIdQuery(Guid Id) : IRequest<Reservation>;

public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Reservation>
{
    private readonly IApplicationDbContext _context;

    public GetReservationByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations
            .FindAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Reservation), request.Id);

        return reservation;
    }
}
