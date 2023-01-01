using AutoMapper;
using FluentValidation.Results;
using MediatR;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.Businesses.Commands;

public class UpdateBusinessCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }
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
        User? manager = null;
        
        if (request.ManagerId.HasValue)
        {
            manager = await _context.Users.FindAsync(request.ManagerId.Value);
            List<ValidationFailure> failures = new();

            if (manager == null)
            {
                throw new NotFoundException(nameof(User), request.ManagerId.Value);
            }

            if (manager.BusinessId != request.Id)
            {
                failures.Add(new ValidationFailure(nameof(request.ManagerId), "Manager is not assigned to this business"));
            }
            
            if (manager.UserType != UserType.Staff)
            {
                failures.Add(new ValidationFailure(nameof(request.ManagerId), "Manager is not a staff member"));
            }
            
            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
        }
        
        var business = await _context.Businesses.FindAsync(request.Id, cancellationToken) ??
                       throw new NotFoundException(nameof(Business), request.Id);

        business.Name = request.Name;
        business.ManagerId = request.ManagerId;
        business.Manager = manager;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
