using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Reservations.Commands;

public record GetAllReservationsQuery : IRequest<IQueryable<Reservation>>;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IQueryable<Reservation>>
{
    private readonly IApplicationDbContext _context;

    public GetAllReservationsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Reservation>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        return _context.Reservations.Where(x => true);
    }
}
