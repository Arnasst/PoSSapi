using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoSSapi.Application.Businesses.Dtos;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Domain.Entities;


namespace PoSSapi.Application.Businesses.Queries;

public record GetAllBusinessesQuery : IRequest<PaginatedList<BusinessDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetAllBusinessesQueryHandler : IRequestHandler<GetAllBusinessesQuery, PaginatedList<BusinessDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllBusinessesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BusinessDto>> Handle(GetAllBusinessesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Business> businesses = _context.Businesses;

        return await businesses
            .ProjectTo<BusinessDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
