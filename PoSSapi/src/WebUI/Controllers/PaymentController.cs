using Microsoft.AspNetCore.Mvc;

using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Payments.Commands;
//using PoSSapi.Application.Payments.Queries;
using PoSSapi.Application.Payments.Dtos;

namespace PoSSapi.WebUI.Controllers;

public class PaymentController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreatePaymentCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdatePaymentCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeletePaymentCommand(id));

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<PaymentDto> Get(Guid id)
    {
        var payment = await Mediator.Send(new GetPaymentQuery { Id = id });

        return payment;
    }

    //supported parameters: userId, status
    [HttpGet("list")]
    public async Task<ActionResult<PaginatedList<PaymentDto>>> GetPaymentsWithPagination([FromQuery] GetPaymentsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}
