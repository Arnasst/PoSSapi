using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoSSapi.Application.BusinessLocations.Dtos;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.BusinessLocations.Queries;

public class GetAllBusinessLocationsQuery: IRequest<PaginatedList<BusinessLocationDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public Guid? BusinessId { get; init; }
}

public class GetAllBusinessLocationsQueryHandler : IRequestHandler<GetAllBusinessLocationsQuery, PaginatedList<BusinessLocationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllBusinessLocationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BusinessLocationDto>> Handle(GetAllBusinessLocationsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<BusinessLocation> businessLocations = _context.BusinessLocations;
        
        if (request.BusinessId != null)
        {
            businessLocations = businessLocations.Where(x => x.BusinessId == request.BusinessId);
        }

        return await businessLocations
            .ProjectTo<BusinessLocationDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}