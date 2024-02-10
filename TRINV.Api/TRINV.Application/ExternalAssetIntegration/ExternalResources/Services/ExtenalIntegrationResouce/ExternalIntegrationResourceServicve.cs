using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouce.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouce;

internal class ExternalIntegrationResourceServicve : IExternalIntegrationResourceService
{
    IEnumerable<IExternalIntegrationResourceBuilder> builders;

    public ExternalIntegrationResourceServicve(IEnumerable<IExternalIntegrationResourceBuilder> builders)
    {
        this.builders = builders;
    }

    public Task<ExternalIntegrationResourceResultModel> ExecuteAll(CancellationToken cancellationToken)
    {
        var result =
    }

    public Task<ExternalIntegrationResourceResultModel> ExecuteAllByCategory(ExternalResourceCategory category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ExternalIntegrationResourceResultModel> ExecuteAllByUserId(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
