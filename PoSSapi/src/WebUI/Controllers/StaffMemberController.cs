// using PoSSapi.Application.Common.Models;
// using PoSSapi.Domain.Entities;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace PoSSapi.WebUI.Controllers;

// public class StaffMemberController : ApiControllerBase
// {
//     [HttpGet("{id}")]
//     public async Task<StaffMember> Get(int id)
//     {
//         var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

//         return File(vm.Content, vm.ContentType, vm.FileName);
//     }

//     [HttpPost]
//     public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
//     {
//         return await Mediator.Send(command);
//     }

//     [HttpPut("{id}")]
//     public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
//     {
//         if (id != command.Id)
//         {
//             return BadRequest();
//         }

//         await Mediator.Send(command);

//         return NoContent();
//     }

//     [HttpDelete("{id}")]
//     public async Task<ActionResult> Delete(int id)
//     {
//         await Mediator.Send(new DeleteTodoItemCommand(id));

//         return NoContent();
//     }

//     [HttpGet("list/findByPosition")]
//     public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetStaffByPositionWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
//     {
//         return await Mediator.Send(query);
//     }
// }
