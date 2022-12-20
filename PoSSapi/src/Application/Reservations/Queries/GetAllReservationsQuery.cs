using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoSSapi.Application.Common.Interfaces;

namespace PoSSapi.Application.Reservations.Commands;

public record GetAllReservationsQuery : IRequest<IQueryable<ReservationDto>>;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IQueryable<ReservationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllReservationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IQueryable<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        return _context.Reservations
            .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider);
    }
}
