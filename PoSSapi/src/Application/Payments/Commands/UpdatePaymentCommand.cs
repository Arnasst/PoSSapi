using AutoMapper;
using MediatR;

using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Payments.Commands;

public record UpdatePaymentCommand : IRequest
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public Guid OrderId { get; init; }
    public decimal PriceOfOrder { get; init; }
    public decimal Discount { get; init; }
    public decimal Tip { get; init; }
    public PaymentOption PaymentOptions { get; init; }
    public PaymentStatus Status { get; init; }
    public DateTime TimeWhenCompleted { get; init; }
}

public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdatePaymentCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Payments.FindAsync(request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(Payment), request.Id);

        var customer = await _context.Users.FindAsync(request.CustomerId, cancellationToken) ??
            throw new NotFoundException(nameof(User), request.CustomerId);
        var order = await _context.Orders.FindAsync(request.OrderId, cancellationToken) ??
            throw new NotFoundException(nameof(Order), request.OrderId);

        entity.Customer = customer;
        entity.Order = order;

        entity.PriceOfOrder = request.PriceOfOrder;
        entity.Discount = request.Discount;
        entity.Tip = request.Tip;
        entity.PaymentOptions = request.PaymentOptions;
        entity.Status = request.Status;
        entity.TimeWhenCompleted = request.TimeWhenCompleted;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
