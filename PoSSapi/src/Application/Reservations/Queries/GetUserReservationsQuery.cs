using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoSSapi.Application.Common.Interfaces;

namespace PoSSapi.Application.Reservations.Commands;

public record GetUserReservationsQuery(Guid UserId) : IRequest<IQueryable<ReservationDto>>;

public class GetUserReservationsQueryHandler : IRequestHandler<GetUserReservationsQuery, IQueryable<ReservationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserReservationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IQueryable<ReservationDto>> Handle(GetUserReservationsQuery request, CancellationToken cancellationToken)
    {
        return _context.Reservations
            .Where(x => x.CustomerId == request.UserId)
            .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider);
    }
}
