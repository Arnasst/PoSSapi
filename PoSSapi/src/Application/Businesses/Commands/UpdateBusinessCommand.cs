using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Businesses.Commands;

public class UpdateBusinessCommand : IRequest
{
    public Guid Id { get; init; }
    public Guid? ManagerId { get; init; }
}

public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateBusinessCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
    {
        if (request.ManagerId.HasValue)
        {
            var manager = await _context.Users.FindAsync(request.ManagerId.Value);
            if (manager == null)
            {
                throw new NotFoundException(nameof(User), request.ManagerId.Value);
            }
        }
        
        var business = await _context.Businesses.FindAsync(request.Id, cancellationToken) ??
                       throw new NotFoundException(nameof(Business), request.Id);
        
        _mapper.Map(request, business);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
