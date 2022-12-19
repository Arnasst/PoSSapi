using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Reservations.Commands;

public record GetUserReservationsQuery(Guid UserId) : IRequest<IQueryable<Reservation>>;

public class GetUserReservationsQueryHandler : IRequestHandler<GetUserReservationsQuery, IQueryable<Reservation>>
{
    private readonly IApplicationDbContext _context;

    public GetUserReservationsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Reservation>> Handle(GetUserReservationsQuery request, CancellationToken cancellationToken)
    {
        return _context.Reservations
            .Where(x => x.CustomerId == request.UserId);
    }
}
