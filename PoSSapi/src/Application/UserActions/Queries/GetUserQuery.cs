using AutoMapper;
using MediatR;

using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.Common.Exceptions;
using PoSSapi.Application.UserActions.Dtos;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.UserActions.Queries;

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
        var user = await _context.Users.FindAsync(request.Id) ?? 
                    throw new NotFoundException(nameof(User), request.Id);

        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}
