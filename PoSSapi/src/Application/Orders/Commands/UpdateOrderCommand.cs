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
    public Guid[] DishIds { get; init; }
    public Guid[] PaymentIds { get; init; }
    public DateTime OrderDate { get; init; }
    public DateTime CompletionDate { get; init; }
    public OrderStatus Status { get; init; }

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
            var order = await _context.Orders
                            .FindAsync(request.Id, cancellationToken)
                        ?? throw new NotFoundException(nameof(Order), request.Id);

            _mapper.Map(request, order);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}