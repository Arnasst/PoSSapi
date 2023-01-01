using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

using PoSSapi.Domain.Enums;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Reports.Dtos;

namespace PoSSapi.Application.Reports.Queries;

public record GetReportsQuery : IRequest<PaginatedList<ReportDto>>
{
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, PaginatedList<ReportDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReportsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ReportDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Reports
            .Where(x => x.StartTime >= request.Start)
            .Where(x => x.EndTime <= request.End)
            .ProjectTo<ReportDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
