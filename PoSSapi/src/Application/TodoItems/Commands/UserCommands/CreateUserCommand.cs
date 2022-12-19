using MediatR;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.TodoItems.Commands.UserCommands;

public record CreateUserCommand : IRequest<Guid>
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

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses.FindAsync(request.BusinessId);
        if (business == null)
        {
            throw new NotFoundException(nameof(Business), request.BusinessId);
        }

        var entity = new User
        {
            Id = request.Id,
            Business = business,
            Name = request.Name,
            Surname = request.Surname,
            Age = request.Age,
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            UserType = request.UserType
        };

        _context.Users.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
