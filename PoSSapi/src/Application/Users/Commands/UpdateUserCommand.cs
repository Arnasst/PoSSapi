using AutoMapper;
using MediatR;

using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Users.Commands;

public record UpdateUserCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid BusinessId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType UserType { get; set; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users.FindAsync(request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(User), request.Id);

        var business = await _context.Businesses.FindAsync(request.BusinessId, cancellationToken) ??
            throw new NotFoundException(nameof(Business), request.BusinessId);

        _mapper.Map(request, entity);
        entity.Business = business;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
