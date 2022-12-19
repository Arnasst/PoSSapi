using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Reservations.Commands;

public record GetReservationsByStatusQuery(ReservationStatus Status) : IRequest<IQueryable<Reservation>>;

public class GetReservationsByStatusQueryHandler : IRequestHandler<GetReservationsByStatusQuery, IQueryable<Reservation>>
{
    private readonly IApplicationDbContext _context;

    public GetReservationsByStatusQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Reservation>> Handle(GetReservationsByStatusQuery request, CancellationToken cancellationToken)
    {
        return _context.Reservations
            .Where(x => x.Status == request.Status);
    }
}
