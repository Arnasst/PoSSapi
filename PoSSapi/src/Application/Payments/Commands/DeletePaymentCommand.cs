using MediatR;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Payments.Commands;

public record DeletePaymentCommand(Guid Id) : IRequest;

public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePaymentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Payments.FindAsync(request.Id, cancellationToken) ??
                throw new NotFoundException(nameof(Payment), request.Id);

        _context.Payments.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}