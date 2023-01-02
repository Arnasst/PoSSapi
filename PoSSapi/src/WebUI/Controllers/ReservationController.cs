using Microsoft.AspNetCore.Mvc;
using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Reservations;
using PoSSapi.Application.Reservations.Commands;

namespace PoSSapi.WebUI.Controllers;

public class ReservationController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDto>> GetReservationById(Guid id)
    {
        return await Mediator.Send(new GetReservationByIdQuery(id));
    }

    [HttpGet("list")]
    public async Task<ActionResult<PaginatedList<ReservationDto>>> GetAllReservations([FromQuery] GetAllReservationsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPut("{id}/modify")]
    public async Task<ActionResult> UpdateReservation(UpdateReservationCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}/modify")]
    public async Task<ActionResult> DeleteReservation(DeleteReservationCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateReservation(CreateReservationCommand command)
    {
        return await Mediator.Send(command);
    }
}
