using AutoMapper;
using MediatR;
using PoSSapi.Application.Orders.Dtos;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Businesses.Queries;

public record GetBusinessByIdQuery(Guid Id) : IRequest<Business>;

public class GetBusinessByIdQueryHandler : IRequestHandler<GetBusinessByIdQuery, Business>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBusinessByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Business> Handle(GetBusinessByIdQuery request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
                              .FindAsync(request.Id, cancellationToken)
                          ?? throw new NotFoundException(nameof(Order), request.Id);

        return business;
    }
}
