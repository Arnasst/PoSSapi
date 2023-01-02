using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Orders.Commands;

public class UpdateOrderCommand : IRequest
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public Guid[]? DishIds { get; init; }
    public DateTime OrderDate { get; init; }
    public DateTime CompletionDate { get; init; }
    public OrderStatus Status { get; init; }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Order), request.Id);
        
        var customer = await _context.Users.FindAsync(request.CustomerId, cancellationToken)
                        ?? throw new NotFoundException(nameof(User), request.CustomerId);

        _context.OrderedDishes.Where(d => d.OrderId == request.Id).ToList()
            .ForEach(d => _context.OrderedDishes.Remove(d));

        if (request.DishIds != null)
        {
            var dishes = _context.Dishes.Where(d => request.DishIds.Contains(d.Id)).ToList();

            if (request.DishIds.Length != dishes.Count)
            {
                throw new NotFoundException(nameof(Dish), request.DishIds);
            }

            order.Dishes = request.DishIds.Select(d => new OrderedDish { DishId = d, OrderId = request.Id })
                .ToList();
        }

        order.Customer = customer;
        order.OrderDate = request.OrderDate;
        order.CompletionDate = request.CompletionDate;
        order.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
