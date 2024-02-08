using MediatR;
using Microsoft.AspNetCore.Mvc;
using TRINV.Application.ExternalAssetIntegration.Queries;
using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;

namespace TRINV.StartUp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        readonly IMediator mediator;
        readonly IIntegrationModelDomainRepository repository;

        public TestController(IMediator mediator, IIntegrationModelDomainRepository repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var res = await this.mediator.Send(new TestQuery(), cancellationToken);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var res = await this.mediator.Send(new Test2Query() { Id = id }, cancellationToken);

            return Ok(res);
        }
    }
}