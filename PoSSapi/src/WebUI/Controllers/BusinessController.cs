using Microsoft.AspNetCore.Mvc;
using PoSSapi.Application.Businesses.Commands;
using PoSSapi.Application.Businesses.Dtos;
using PoSSapi.Application.Businesses.Queries;
using PoSSapi.Application.Common.Models;

namespace PoSSapi.WebUI.Controllers;

public class BusinessController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BusinessDto>> GetBusinessById(Guid id)
    {
        return await Mediator.Send(new GetBusinessByIdQuery(id));
    }

    [HttpGet("list")]
    public async Task<ActionResult<PaginatedList<BusinessDto>>> GetAllBusinesses([FromQuery] GetAllBusinessesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPut("{id}/modify")]
    public async Task<ActionResult> UpdateBusiness(Guid id, UpdateBusinessCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}/modify")]
    public async Task<ActionResult> DeleteBusiness(Guid id)
    {
        await Mediator.Send(new DeleteBusinessCommand {Id = id});
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBusiness(CreateBusinessCommand command)
    {
        return await Mediator.Send(command);
    }
}
