using AutoMapper;
using PoSSapi.Domain.Enums;
using PoSSapi.Domain.Entities;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using MediatR;


namespace PoSSapi.Application.TodoItems.Queries;

public record GetUsersWithPaginationQuery : IRequest<PaginatedList<User>>
{
    public UserType UserType { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<User>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<User>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        // TODO: Fix this to return UserDto
        return await _context.Users
            .Where(x => x.UserType == request.UserType)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
