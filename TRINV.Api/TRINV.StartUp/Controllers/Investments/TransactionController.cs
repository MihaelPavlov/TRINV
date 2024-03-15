using MediatR;
using Microsoft.AspNetCore.Mvc;
using TRINV.Application.Investments.Transaction.Commands;
using TRINV.Application.Investments.Transaction.Queries;
using TRINV.Shared.Business.Utilities;

namespace TRINV.StartUp.Controllers.Investments;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    readonly IMediator mediator;

    public TransactionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<GetTransactionByIdQueryModel>))]
    public async Task<IActionResult> GetTransactionById(int id, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(new GetTransactionByIdQuery(id), cancellationToken);
        return this.Ok(result);
    }

    [HttpPost("asset-transaction-list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>))]
    public async Task<IActionResult> GetTransactionListByAssetId([FromBody] GetTransactionListByAssetIdQuery query, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(query, cancellationToken);
        return this.Ok(result);
    }

    [HttpPost("asset-list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<GetAssetListQueryModel>>))]
    public async Task<IActionResult> GetAssetList([FromBody] GetAssetListQuery query, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(query, cancellationToken);
        return this.Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult))]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(command, cancellationToken);
        return this.Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult))]
    public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionCommand command, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(command, cancellationToken);
        return this.Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult))]
    public async Task<IActionResult> DeleteTransaction(int id, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(new DeleteTransactionCommand(id), cancellationToken);
        return this.Ok(result);
    }
}
