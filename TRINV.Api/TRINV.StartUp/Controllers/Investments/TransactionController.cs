using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>))]
    public async Task<IActionResult> GetTransactionListByAssetId([FromBody] GetTransactionListByAssetIdQuery query, CancellationToken cancellationToken)
    {
        var result = await this.mediator.Send(query, cancellationToken);
        return this.Ok(result);
    }
}
