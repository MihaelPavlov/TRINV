using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces.Interfaces;

public interface IExternalIntegrationResourceService
{
    Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAllByUserId(int userId, CancellationToken cancellationToken);
    Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAllByCategory(ExternalResourceCategory category, CancellationToken cancellationToken);
    Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> ExecuteAll(CancellationToken cancellationToken);
}
