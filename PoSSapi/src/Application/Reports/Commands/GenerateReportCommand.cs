using AutoMapper;
using MediatR;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;
using PoSSapi.Application.Reports.Dtos;

namespace PoSSapi.Application.Reports.Commands;

public record GenerateReportCommand : IRequest<ReportDto>
{
    public Guid Id { get; init; }
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }
}

public class GenerateReportCommandHandler : IRequestHandler<GenerateReportCommand, ReportDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GenerateReportCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ReportDto> Handle(GenerateReportCommand request, CancellationToken cancellationToken)
    {
        var entity = new Report {
            Id = request.Id,
            StartTime = request.StartTime,
            EndTime = request.EndTime
        };

        var payments = _context.Payments
            .Where(x => x.TimeWhenCompleted >= request.StartTime)
            .Where(x => x.TimeWhenCompleted <= request.EndTime)
            .ToList<Payment>();

        entity.Revenue = payments.Sum(x => x.PriceOfOrder)
            + payments.Sum(x => x.Tip)
            - payments.Sum(x => x.Discount);

        _context.Reports.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        var returnObject = new ReportDto();
        _mapper.Map(entity, returnObject);

        return returnObject;
    }
}