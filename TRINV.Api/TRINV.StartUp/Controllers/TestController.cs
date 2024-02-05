using MediatR;
using Microsoft.AspNetCore.Mvc;
using TRINV.Application.ExternalAssetIntegration.Queries;

namespace TRINV.StartUp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        readonly IMediator mediator;
        public TestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var res = await this.mediator.Send(new TestQuery(), cancellationToken);
            return Ok(res);
        }
    }
}