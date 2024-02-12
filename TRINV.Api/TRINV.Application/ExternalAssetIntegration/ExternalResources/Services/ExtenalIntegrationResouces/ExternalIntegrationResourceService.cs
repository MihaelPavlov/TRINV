using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces;

internal class ExternalIntegrationResourceService : IExternalIntegrationResourceService
{
    readonly IEnumerable<IExternalIntegrationResourceBuilder> builders;

    public ExternalIntegrationResourceService(IEnumerable<IExternalIntegrationResourceBuilder> builders)
    {
        this.builders = builders;
    }

    // Maybe remove this. Think of a case where we would need
    // On the page where we are calculating the total profit.
    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAll(CancellationToken cancellationToken)
    {
        var collection = new List<ExternalIntegrationResourceResultModel>();
        foreach (var resource in this.builders)
        {
            var result = await resource.Build(cancellationToken);

            //TODO: Think of it it's not okey to stop the execution of other resource if one failed.
            if (!result.Success || result.RelatedObject is null)
                return new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>().MergeErrors(result);

            collection.AddRange(result.RelatedObject);
        }

        return new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>(collection);
    }

    // Execute based on account
    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAllByCategory(ExternalResourceCategory category, CancellationToken cancellationToken)
    {
        var collection = new List<ExternalIntegrationResourceResultModel>();

        foreach (var resource in this.builders.Where(x => x.Category == category))
        {
            var result = await resource.Build(cancellationToken);

            if (!result.Success || result.RelatedObject is null)
                return new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>().MergeErrors(result);

            collection.AddRange(result.RelatedObject);
        }

        return new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>(collection);
    }

    // Maybe we would use this to execute it when the user logged in and use all the cached information about resources, in this case we will increase the user loading. Intead of user waithing for the resource to load the first time.se6x3svi zc
    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAllByUserId(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}
