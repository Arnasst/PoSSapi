using Microsoft.AspNetCore.Mvc;
using PoSSapi.Application.Reservations;
using PoSSapi.Application.Reservations.Commands;
using PoSSapi.Domain.Entities;
using PoSSapi.Domain.Enums;

namespace PoSSapi.WebUI.Controllers;

public class ReservationController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDto>> GetReservationById(Guid id)
    {
        return await Mediator.Send(new GetReservationByIdQuery(id));
    }

    [HttpGet("list")]
    public async Task<ActionResult<IQueryable<ReservationDto>>> GetAllReservations()
    {
        return Ok(await Mediator.Send(new GetAllReservationsQuery()));
    }

    [HttpGet("list/{userId}")]
    public async Task<ActionResult<IQueryable<ReservationDto>>> GetUsersReservations(Guid userId)
    {
        return Ok(await Mediator.Send(new GetUserReservationsQuery(userId)));
    }

    [HttpGet("{status}")]
    public async Task<ActionResult<IQueryable<ReservationDto>>> GetReservationsByStatus(ReservationStatus status)
    {
        return Ok(await Mediator.Send(new GetReservationsByStatusQuery(status)));
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
