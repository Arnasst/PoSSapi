using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Domain.Enums;


namespace PoSSapi.Application.Reservations.Commands;

public record GetAllReservationsQuery : IRequest<PaginatedList<ReservationDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public Guid? UserId { get; init; }
    public ReservationStatus? Status { get; init; }
}

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, PaginatedList<ReservationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllReservationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = _context.Reservations;

        if (request.UserId != null)
        {
            reservations
                .Where(x => x.CustomerId == request.UserId);
        }

        if (request.Status != null)
        {
            reservations
                .Where(x => x.Status == request.Status);
        }

        return await reservations
            .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
