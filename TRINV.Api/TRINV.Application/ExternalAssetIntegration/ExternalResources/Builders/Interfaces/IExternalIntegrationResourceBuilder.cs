using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;

public interface IExternalIntegrationResourceBuilder
{
    int Id { get; }
    ExternalResourceCategory Category { get; }

    Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> Build(CancellationToken cancellationToken);
}
