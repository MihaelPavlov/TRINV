using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouce.Interfaces;

public interface IExternalIntegrationResourceService
{
    Task<ExternalIntegrationResourceResultModel> ExecuteAllByUserId(int userId, CancellationToken cancellationToken);
    Task<ExternalIntegrationResourceResultModel> ExecuteAllByCategory(ExternalResourceCategory category, CancellationToken cancellationToken);
    Task<ExternalIntegrationResourceResultModel> ExecuteAll(CancellationToken cancellationToken);
}
