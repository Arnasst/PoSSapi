using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Orders.Commands;

public class DeleteOrderCommand : IRequest
{
    public Guid Id { get; init; }
}

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
                              .FindAsync(request.Id, cancellationToken)
                          ?? throw new NotFoundException(nameof(Order), request.Id);

        _context.Orders.Remove(order);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}