using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Businesses.Commands;

public class CreateBusinessCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
    public Guid? ManagerId { get; init; }
}

public class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateBusinessCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        if (request.ManagerId.HasValue)
        {
            var manager = await _context.Users.FindAsync(request.ManagerId.Value);
            if (manager == null)
            {
                throw new NotFoundException(nameof(User), request.ManagerId.Value);
            }
        }

        var business = new Business
        {
            Id = request.Id,
            ManagerId = request.ManagerId
        };
        
        _context.Businesses.Add(business);
        await _context.SaveChangesAsync(cancellationToken);
        
        return business.Id;
    }
}