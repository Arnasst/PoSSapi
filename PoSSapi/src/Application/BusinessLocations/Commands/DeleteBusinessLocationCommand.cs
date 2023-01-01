using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.BusinessLocations.Commands;

public class DeleteBusinessLocationCommand : IRequest
{
    public Guid Id { get; init; }
}

public class DeleteBusinessLocationCommandHandler : IRequestHandler<DeleteBusinessLocationCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBusinessLocationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBusinessLocationCommand request, CancellationToken cancellationToken)
    {
        var businessLocation = await _context.BusinessLocations.FindAsync(request.Id, cancellationToken) ??
                       throw new NotFoundException(nameof(BusinessLocations), request.Id);

        _context.BusinessLocations.Remove(businessLocation);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
