using Microsoft.AspNetCore.Mvc;
using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Orders.Commands;
using PoSSapi.Application.Orders.Dtos;
using PoSSapi.Application.Orders.Queries;

namespace PoSSapi.WebUI.Controllers;

public class OrderController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
    {
        return await Mediator.Send(new GetOrderByIdQuery(id));
    }

    [HttpGet("list")]
    public async Task<ActionResult<PaginatedList<OrderDto>>> GetAllOrders([FromQuery] GetAllOrdersQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPut("{id}/modify")]
    public async Task<ActionResult> UpdateOrder(Guid id, UpdateOrderCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}/modify")]
    public async Task<ActionResult> DeleteOrder(Guid id)
    {
        await Mediator.Send(new DeleteOrderCommand{Id = id});
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOrder(CreateOrderCommand command)
    {
        return await Mediator.Send(command);
    }
}
