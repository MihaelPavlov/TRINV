using MediatR;
using Microsoft.AspNetCore.Mvc;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Commands;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;
using TRINV.Shared.Business.Utilities;

namespace TRINV.StartUp.Controllers.ExternalAssetIntegration;

[ApiController]
[Route("[controller]")]
public class RequestExternalResourcesController : ControllerBase
{
    readonly IMediator mediator;

    public RequestExternalResourcesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<GetRequestExternalResourceQueryModel>>))]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(new GetRequestExternalResourceListQuery(), cancellationToken);
        return this.Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult))]
    public async Task<IActionResult> Create([FromBody] CreateRequestExternalResourceCommand command, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(command, cancellationToken);
        return this.Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult))]
    public async Task<IActionResult> Update([FromBody] UpdateRequestExternalResourceCommand command, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(command, cancellationToken);
        return this.Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult))]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(new DeleteRequestExternalResourceCommand(id), cancellationToken);
        return this.Ok(result);
    }
}
