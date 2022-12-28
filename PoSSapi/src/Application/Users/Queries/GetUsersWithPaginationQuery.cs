using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

using PoSSapi.Domain.Enums;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Users.Dtos;

namespace PoSSapi.Application.Users.Queries;

public record GetUsersWithPaginationQuery : IRequest<PaginatedList<UserDto>>
{
    public UserType UserType { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? Username { get; init; }
}

public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<UserDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserDto>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var users = _context.Users
            .Where(x => x.UserType == request.UserType);
        
        if (!string.IsNullOrEmpty(request.Username))
        {
            users = users.Where(x => x.Username.Contains(request.Username));
        }

        return await users.ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
