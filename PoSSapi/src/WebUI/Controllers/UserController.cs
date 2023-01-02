using Microsoft.AspNetCore.Mvc;

using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Users.Commands;
using PoSSapi.Application.Users.Queries;
using PoSSapi.Application.Users.Dtos;

namespace PoSSapi.WebUI.Controllers;

public class UserController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<UserDto> Get(Guid id)
    {
        var user = await Mediator.Send(new GetUserQuery { Id = id });

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateUserCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteUserCommand(id));

        return NoContent();
    }

    [HttpGet("list/findByType")]
    public async Task<ActionResult<PaginatedList<UserDto>>> GetUsersByTypeWithPagination([FromQuery] GetUsersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}
