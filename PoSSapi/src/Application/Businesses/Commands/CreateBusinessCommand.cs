using MediatR;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Businesses.Commands;

public class CreateBusinessCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}

public class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateBusinessCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        var business = new Business
        {
            Id = request.Id,
            Name = request.Name
        };
        
        _context.Businesses.Add(business);
        await _context.SaveChangesAsync(cancellationToken);
        
        return business.Id;
    }
}
