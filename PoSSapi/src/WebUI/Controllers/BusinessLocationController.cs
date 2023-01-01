using Microsoft.AspNetCore.Mvc;
using PoSSapi.Application.BusinessLocations.Commands;

namespace PoSSapi.WebUI.Controllers;

public class BusinessLocationsController : ApiControllerBase
{
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
