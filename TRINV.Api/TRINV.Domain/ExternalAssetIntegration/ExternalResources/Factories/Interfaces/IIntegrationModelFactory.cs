using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;

public interface IIntegrationModelFactory : IFactory<IntegrationModel>
{
    IIntegrationModelFactory WithUserId(int userId);
    IIntegrationModelFactory WithName(string name);
    IIntegrationModelFactory WithBaseUrl(string baseUrl);
    IIntegrationModelFactory WithApiKey(string apiKey);
    IIntegrationModelFactory WithStatus(ExternalResourceStatus status);
    IIntegrationModelFactory WithCategory(ExternalResourceCategory category);
    IIntegrationModelFactory WithEndpoints(List<IntegrationModelEndpoint> endpoints);
}
