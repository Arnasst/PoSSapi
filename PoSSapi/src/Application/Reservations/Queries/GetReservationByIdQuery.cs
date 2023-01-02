using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Domain.Entities;
using AutoMapper;

namespace PoSSapi.Application.Reservations.Commands;

public record GetReservationByIdQuery(Guid Id) : IRequest<ReservationDto>;

public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReservationByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservations
            .FindAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Reservation), request.Id);

        return _mapper.Map<Reservation, ReservationDto>(reservation);
    }
}
