using MediatR;
using Microsoft.AspNetCore.Mvc;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;

namespace TRINV.StartUp.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    readonly IMediator mediator;
    readonly IRequestExternalResourceDomainRepository repository;

    public TestController(IMediator mediator, IRequestExternalResourceDomainRepository repository)
    {
        this.mediator = mediator;
        this.repository = repository;
    }
}