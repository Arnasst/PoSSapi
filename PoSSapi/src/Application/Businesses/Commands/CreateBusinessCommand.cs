using AutoMapper;
using MediatR;
using PoSSapi.Application.Common.Interfaces;

namespace PoSSapi.Application.Businesses.Commands;

public class CreateBusinessCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
}

public class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateBusinessCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }

    public Task<Guid> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}