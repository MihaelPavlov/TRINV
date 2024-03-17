using MediatR;
using Microsoft.AspNetCore.Mvc;
using TRINV.Application.ExternalAssetIntegration.Dashboard.Queries;
using TRINV.Shared.Business.Utilities;

namespace TRINV.StartUp.Controllers.ExternalAssetIntegration;

[ApiController]
[Route("[controller]")]
public class DashboardController : ControllerBase
{
    readonly IMediator mediator;

    public DashboardController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("asset-investment-list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<GetInvestmentListByAssetIdQueryModel>>))]
    public async Task<IActionResult> GetTransactionListByAssetId([FromBody] GetInvestmentListByAssetIdQuery query, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(query, cancellationToken);
        return this.Ok(result);
    }

    [HttpGet("dashboard-investment-performance")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<GetInvestmentPerformanceQueryModel>>))]
    public async Task<IActionResult> GetInvestmentPerformance( CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(new GetInvestmentPerformanceQuery(), cancellationToken);
        return this.Ok(result);
    }
}
