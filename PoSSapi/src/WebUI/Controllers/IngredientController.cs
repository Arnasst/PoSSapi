using Microsoft.AspNetCore.Mvc;
using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Ingredients.Commands;
using PoSSapi.Application.Ingredients.Queries;
using PoSSapi.Domain.Entities;

namespace PoSSapi.WebUI.Controllers;

public class IngredientController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<Ingredient> GetIngredientById(Guid id)
    {
        return await Mediator.Send(new GetIngredientByIdQuery(id));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateIngredient(CreateIngredientCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}/modify")]
    public async Task<ActionResult> Update(Guid id, UpdateIngredientCommand command)
    {
        command.Id = id;
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}/modify")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteIngredientCommand(id));

        return NoContent();
    }

    [HttpGet("list")]
    public async Task<ActionResult<PaginatedList<Ingredient>>> GetAllIngredientsPaginatedQuery([FromQuery] GetAllIngredientsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
