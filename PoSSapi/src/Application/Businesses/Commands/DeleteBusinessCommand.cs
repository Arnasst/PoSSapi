using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Businesses.Commands;

public class DeleteBusinessCommand : IRequest
{
    public Guid Id { get; init; }
}

public class DeleteBusinessCommandHandler : IRequestHandler<DeleteBusinessCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBusinessCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
    {
        return Unit.Value;
    }
}
