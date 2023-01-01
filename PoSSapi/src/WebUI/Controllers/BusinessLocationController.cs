using Microsoft.AspNetCore.Mvc;
using PoSSapi.Application.Businesses.Dtos;
using PoSSapi.Application.Businesses.Queries;
using PoSSapi.Application.BusinessLocations.Commands;
using PoSSapi.Application.BusinessLocations.Dtos;
using PoSSapi.Application.BusinessLocations.Queries;
using PoSSapi.Application.Common.Models;

namespace PoSSapi.WebUI.Controllers;

public class BusinessLocationsController : ApiControllerBase
{
    [HttpGet("list")]
    public async Task<ActionResult<PaginatedList<BusinessLocationDto>>> GetAllBusinessLocations([FromQuery] GetAllBusinessLocationsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpDelete("{id}/modify")]
    public async Task<ActionResult> DeleteBusinessLocation(Guid id)
    {
        await Mediator.Send(new DeleteBusinessLocationCommand {Id = id});
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBusinessLocation(CreateBusinessLocationCommand command)
    {
        return await Mediator.Send(command);
    }
}
