using MediatR;
using Microsoft.AspNetCore.Mvc;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;
using TRINV.Shared.Business.Utilities;

namespace TRINV.StartUp.Controllers.ExternalAssetIntegration;

[ApiController]
[Route("[controller]")]
public class ExternalIntegrationResourceController : ControllerBase
{
    readonly IMediator mediator;

    public ExternalIntegrationResourceController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<GetExternalIntegrationResourceListQuery>>))]
    public async Task<IActionResult> GetExternalIntegrationResourceList(CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(new GetExternalIntegrationResourceListQuery(), cancellationToken);
        return this.Ok(result);
    }

    [HttpGet("execute-all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>))]
    public async Task<IActionResult> ExecuteAll(CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(new GetExternalIntegrationResourceResultListQuery(), cancellationToken);
        return this.Ok(result);
    }

    [HttpGet("execute-by-category/{category}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>))]
    public async Task<IActionResult> ExecuteByCategory(CancellationToken cancellationToken)
    {
        return this.Ok();
    }

    [HttpGet("execute-by-user-id/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>))]
    public async Task<IActionResult> ExecuteByUserId(CancellationToken cancellationToken)
    {
        return this.Ok();
    }
}
