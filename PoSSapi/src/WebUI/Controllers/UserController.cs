using PoSSapi.Domain.Entities;
using PoSSapi.Application.TodoItems.Commands.UserCommands;
using Microsoft.AspNetCore.Mvc;
using Template.Application.TodoLists.Queries.Users;

namespace PoSSapi.WebUI.Controllers;

public class UserController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<User> Get(Guid id)
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

        // TODO
//     [HttpGet("list/findByType")]
//     public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetUsersByTypeWithPagination([FromQuery] GetUsersWithPaginationQuery query)
//     {
//         return await Mediator.Send(query);
//     }
}
