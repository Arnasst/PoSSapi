using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoSSapi.Application.Orders.Dtos;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;


namespace PoSSapi.Application.Businesses.Queries;

public record GetAllBusinessesQuery : IRequest<PaginatedList<Business>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public Guid? UserId { get; init; }
    public OrderStatus? Status { get; init; }
}

public class GetAllBusinessesQueryHandler : IRequestHandler<GetAllBusinessesQuery, PaginatedList<Business>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllBusinessesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<Business>> Handle(GetAllBusinessesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Business> businesses = _context.Businesses;

        return await businesses
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
