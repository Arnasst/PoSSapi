using Microsoft.AspNetCore.Mvc;

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

    [HttpPut]
    public async Task<ActionResult> Update(UpdateIngredientCommand command)
    {
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteIngredientCommand(id));

        return NoContent();
    }

    [HttpGet("list")]
    public async Task<ActionResult<IQueryable<Ingredient>>> GetAllIngredientsPaginatedQuery([FromQuery] GetAllIngredientsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet]
    public async Task<ActionResult<Ingredient>> GetIngredientByName([FromQuery] GetIngredientByNameQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("list/findByStockStatus")]
    public async Task<ActionResult<Ingredient>> GetIngredientByName([FromQuery] GetIngredientsByStockStatusQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
