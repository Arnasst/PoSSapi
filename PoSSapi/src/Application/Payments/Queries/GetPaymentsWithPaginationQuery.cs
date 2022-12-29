using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

using PoSSapi.Domain.Enums;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Payments.Dtos;

namespace PoSSapi.Application.Payments.Queries;

public record GetPaymentsWithPaginationQuery : IRequest<PaginatedList<PaymentDto>>
{
    public Guid? UserId { get; init; }
    public PaymentStatus? Status { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPaymentsWithPaginationQueryHandler : IRequestHandler<GetPaymentsWithPaginationQuery, PaginatedList<PaymentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPaymentsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PaymentDto>> Handle(GetPaymentsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var payments = _context.Payments.AsQueryable();
        if (request.UserId != null) {
            payments = payments.Where(x => x.Id == request.UserId);
        }
        if (request.Status != null) {
            payments = payments.Where(x => x.Status == request.Status);
        }
        return await payments
            .ProjectTo<PaymentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
