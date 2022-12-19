using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.TodoItems.Dtos;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.TodoItems.Queries.UserQueries;

public record GetUserQuery : IRequest<UserDto>
{
    public Guid Id { get; init; }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.Users
                .Where(t => t.Id == request.Id)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        if (records.Count == 0)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        return records[0];
    }
}
