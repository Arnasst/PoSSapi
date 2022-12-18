using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;
using MediatR;

namespace PoSSapi.Application.TodoItems.Commands.UserCommands;

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

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        var business = await _context.Businesses.FindAsync(request.BusinessId);
        if (business == null)
        {
            throw new NotFoundException(nameof(Business), request.BusinessId);
        }

        entity.Business = business;
        entity.Name = request.Name;
        entity.Surname = request.Surname;
        entity.Age = request.Age;
        entity.Username = request.Username;
        entity.Email = request.Email;
        entity.Password = request.Password;
        entity.UserType = request.UserType;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
