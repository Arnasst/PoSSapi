using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;


namespace PoSSapi.Application.Orders.Queries;

public record GetAllOrdersQuery : IRequest<PaginatedList<Order>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public Guid? UserId { get; init; }
    public OrderStatus? Status { get; init; }
}

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PaginatedList<Order>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = _context.Orders;
        IQueryable<Order> orderQuery;

        if (request.UserId != null && request.UserId != null)
        {
            orderQuery = orders
                .Where(o => o.CustomerId == request.UserId 
                            && o.Status == request.Status);
        }
        else if (request.UserId != null)
        {
            orderQuery = orders
                .Where(x => x.CustomerId == request.UserId);
        }
        else if (request.Status != null)
        {
            orderQuery = orders
                .Where(x => x.Status == request.Status);
        }
        else
        {
            orderQuery = orders;
        }

        return await orderQuery
            .ProjectTo<Order>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}