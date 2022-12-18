using AutoMapper;
using PoSSapi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PoSSapi.Domain.Entities;
using PoSSapi.Application.Common.Exceptions;

namespace PoSSapi.Application.TodoItems.Queries;

public record GetUserQuery : IRequest<User>
{
    public Guid Id { get; init; }
}

public class ExportTodosQueryHandler : IRequestHandler<GetUserQuery, User>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ExportTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.Users
                .Where(t => t.Id == request.Id)
                .ToListAsync(cancellationToken);

        if (records.Count == 0)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        return records[0];
    }
}
