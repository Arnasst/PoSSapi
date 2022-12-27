using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Domain.Entities;
using AutoMapper;

namespace PoSSapi.Application.Orders.Queries;

public record GetOrderByIdQuery(Guid Id) : IRequest<Order>;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
                              .FindAsync(request.Id, cancellationToken)
                          ?? throw new NotFoundException(nameof(Order), request.Id);

        return order;
    }
}