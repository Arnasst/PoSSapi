using AutoMapper;
using MediatR;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Reports.Dtos;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Reports.Queries;

public record GetReportsAnalyticsQuery : IRequest<ReportsAnalyticsDto>
{
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }
}

public class GetReportsAnalyticsQueryHandler : IRequestHandler<GetReportsAnalyticsQuery, ReportsAnalyticsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReportsAnalyticsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ReportsAnalyticsDto> Handle(GetReportsAnalyticsQuery request, CancellationToken cancellationToken)
    {
        var analytics = _mapper.Map<ReportsAnalyticsDto>(request);
        analytics.TotalRevenue = _context.Reports
            .Where(x => x.StartTime >= request.StartTime)
            .Where(x => x.EndTime <= request.EndTime)
            .Sum(x => x.Revenue);

        return analytics;
    }
}
