using Microsoft.AspNetCore.Mvc;
using PoSSapi.Application.Businesses.Commands;
using PoSSapi.Application.Businesses.Queries;
using PoSSapi.Application.Common.Models;
using PoSSapi.Domain.Entities;

namespace PoSSapi.WebUI.Controllers;

public class BusinessController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Business>> GetBusinessById(Guid id)
    {
        return await Mediator.Send(new GetBusinessByIdQuery(id));
    }

    [HttpGet("list")]
    public async Task<ActionResult<PaginatedList<Business>>> GetAllBusinesses([FromQuery] GetAllBusinessesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPut("{id}/modify")]
    public async Task<ActionResult> UpdateBusiness(UpdateBusinessCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}/modify")]
    public async Task<ActionResult> DeleteBusiness(DeleteBusinessCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBusiness(CreateBusinessCommand command)
    {
        return await Mediator.Send(command);
    }
}