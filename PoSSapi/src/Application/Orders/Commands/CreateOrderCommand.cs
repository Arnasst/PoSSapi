using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public Guid[] DishIds { get; init; }
    public Guid[] PaymentIds { get; init; }
    public DateTime OrderDate { get; init; }
    public DateTime CompletionDate { get; init; }
    public OrderStatus Status { get; init; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order();

        _mapper.Map(request, order);

        await _context.Orders
            .AddAsync(order, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
