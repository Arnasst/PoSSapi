using AutoMapper;
using MediatR;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Payments.Commands;

public record CreatePaymentCommand : IRequest<Guid>
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

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreatePaymentCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Users.FindAsync(request.CustomerId, cancellationToken) ??
            throw new NotFoundException(nameof(User), request.CustomerId);
        var order = await _context.Orders.FindAsync(request.OrderId, cancellationToken) ??
            throw new NotFoundException(nameof(Order), request.OrderId);

        var entity = new Payment();
        
        _mapper.Map(request, entity);
        entity.Customer = customer;
        entity.Order = order;

        _context.Payments.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
