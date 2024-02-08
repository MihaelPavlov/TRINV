using MediatR;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.Queries;

public class Test2Query : IRequest<OperationResult>
{
    public int Id { get; set; }
}

internal class Test2QueryHandler : IRequestHandler<Test2Query, OperationResult>
{
    readonly IIntegrationModelFactory factory;
    readonly IIntegrationModelEndpointFactory factory2;
    readonly IIntegrationModelDomainRepository investmentDomainRepository2;
    public Test2QueryHandler( IIntegrationModelDomainRepository investmentDomainRepository2,IIntegrationModelFactory factory, IIntegrationModelEndpointFactory factory2)
    {
        this.factory = factory;
        this.factory2 = factory2;
        this.investmentDomainRepository2 = investmentDomainRepository2;
    }

    public async Task<OperationResult> Handle(Test2Query request, CancellationToken cancellationToken)
    {
       return new OperationResult().ReturnWithErrorMessage(new NotFoundException());
        //var obj1 = factory2.WithQueryUrl("TEST-GET").WithHttpRequestType(Domain.ExternalAssetIntegration.ExternalResources.Enums.HttpRequestType.GET).Build();
        var obj = this.factory
                .WithName("test")
                .WithApiKey("3213213921-ddq-3213ddsa-dsa")
                .WithUserId(1)
                .WithBaseUrl("https://api-test")
                .WithCategory(Domain.ExternalAssetIntegration.ExternalResources.Enums.ExternalResourceCategory.Crpyto)
                .WithStatus(Domain.ExternalAssetIntegration.ExternalResources.Enums.ExternalResourceStatus.InReview)
                //.WithEndpoints(new List<IntegrationModelEndpoint> { obj1 })
                .Build();

        await this.investmentDomainRepository2.Save(obj, cancellationToken);

        var res = await this.investmentDomainRepository2.Find(request.Id, cancellationToken);

        //return res;
    }
}
