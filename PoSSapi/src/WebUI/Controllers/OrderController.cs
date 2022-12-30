using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Orders.Dtos;
using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Orders.Commands;
using PoSSapi.Application.Orders.Queries;
using PoSSapi.Domain.Entities;

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
    public async Task<ActionResult> UpdateOrder(UpdateOrderCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}/modify")]
    public async Task<ActionResult> DeleteOrder(DeleteOrderCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOrder(CreateOrderCommand command)
    {
        return await Mediator.Send(command);
    }
}
