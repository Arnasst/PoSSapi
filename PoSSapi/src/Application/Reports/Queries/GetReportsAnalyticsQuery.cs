using AutoMapper;
using MediatR;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Reports.Dtos;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Reports.Queries;

public record GetReportsAnalyticsQuery : IRequest<ReportsAnalyticsDto>
{
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
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
        var analytics = new ReportsAnalyticsDto {
            StartTime = request.Start,
            EndTime = request.End
        };
        
        analytics.TotalRevenue = _context.Reports
            .Where(x => x.StartTime >= request.Start)
            .Where(x => x.EndTime <= request.End)
            .ToList<Report>()
            .Sum(x => x.Revenue);

        return analytics;
    }
}
