using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

using PoSSapi.Domain.Enums;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Application.Common.Models;
using PoSSapi.Application.TodoItems.Dtos;

namespace PoSSapi.Application.TodoItems.Queries.UserQueries;

public record GetUsersWithPaginationQuery : IRequest<PaginatedList<UserDto>>
{
    public UserType UserType { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
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
        return await _context.Users
            .Where(x => x.UserType == request.UserType)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
