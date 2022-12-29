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

    public GetPaymentQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = await _context.Payments.FindAsync(request.Id, cancellationToken) ?? 
                    throw new NotFoundException(nameof(Payment), request.Id);

        var paymentDto = new PaymentDto {
            Id = request.Id,
            CustomerId = payment.Customer.Id,
            OrderId = payment.Order.Id,
            PriceOfOrder = payment.PriceOfOrder,
            Discount = payment.Discount,
            Tip = payment.Tip,
            PaymentOptions = payment.PaymentOptions,
            Status = payment.Status,
            TimeWhenCompleted = payment.CompletionTime
        };

        return paymentDto;
    }
}
