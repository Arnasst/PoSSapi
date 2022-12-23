using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Reservations.Commands;

public record GetReservationsByStatusQuery(ReservationStatus Status) : IRequest<IQueryable<ReservationDto>>;

public class GetReservationsByStatusQueryHandler : IRequestHandler<GetReservationsByStatusQuery, IQueryable<ReservationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReservationsByStatusQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IQueryable<ReservationDto>> Handle(GetReservationsByStatusQuery request, CancellationToken cancellationToken)
    {
        return _context.Reservations
            .Where(x => x.Status == request.Status)
            .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider);
    }
}
