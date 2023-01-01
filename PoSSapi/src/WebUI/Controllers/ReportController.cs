using Microsoft.AspNetCore.Mvc;

using PoSSapi.Application.Common.Models;
using PoSSapi.Application.Reports.Commands;
using PoSSapi.Application.Reports.Queries;
using PoSSapi.Application.Reports.Dtos;

namespace PoSSapi.WebUI.Controllers;

public class ReportController : ApiControllerBase
{
    [HttpPost("generate")]
    public async Task<ActionResult<ReportDto>> Generate(GenerateReportCommand command)
    {
        return await Mediator.Send(command);
    }

    //required parameters: start, end
    [HttpGet("findByDate")]
    public async Task<ActionResult<PaginatedList<ReportDto>>> Find([FromQuery] GetReportsQuery query)
    {
        return await Mediator.Send(query);
    }

    //required parameters: start, end
    [HttpGet("analytics")]
    public async Task<ActionResult<ReportsAnalyticsDto>> GetAnalytics([FromQuery] GetReportsAnalyticsQuery query)
    {
        return await Mediator.Send(query);
    }
}
