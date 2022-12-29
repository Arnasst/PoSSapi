using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public Guid[]? DishIds { get; init; }
    public DateTime OrderDate { get; init; }
    public DateTime CompletionDate { get; init; }
    public OrderStatus Status { get; init; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Users.FindAsync(request.CustomerId, cancellationToken) ?? 
                       throw new NotFoundException(nameof(User), request.CustomerId);

        var order = new Order
        {
            Id = request.Id,
            Customer = customer,
            CustomerId = request.CustomerId,
            OrderDate = request.OrderDate,
            CompletionDate = request.CompletionDate,
            Status = request.Status
        };
        
        await _context.Orders
            .AddAsync(order, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);

        if (request.DishIds == null)
        {
            return order.Id;
        }
        
        var dishes = await _context.Dishes
            .Where(d => request.DishIds.Contains(d.Id))
            .ToListAsync(cancellationToken);
        
        if (request.DishIds.Length != dishes.Count)
        {
            throw new NotFoundException(nameof(Dish), request.DishIds);
        }
        
        order.Dishes = dishes.Select(d => new OrderedDish
        {
            DishId = d.Id,
            OrderId = request.Id
        }).ToList();

        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
