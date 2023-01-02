using AutoMapper;
using MediatR;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Payments.Dtos;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Payments.Queries;

public record GetPaymentQuery : IRequest<PaymentDto>
{
    public Guid Id { get; init; }
}

public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, PaymentDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPaymentQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = await _context.Payments.FindAsync(request.Id, cancellationToken) ?? 
                    throw new NotFoundException(nameof(Payment), request.Id);

        var paymentDto = _mapper.Map<PaymentDto>(payment);
        paymentDto.CustomerId = payment.CustomerId;
        paymentDto.OrderId = payment.OrderId;

        return paymentDto;
    }
}
