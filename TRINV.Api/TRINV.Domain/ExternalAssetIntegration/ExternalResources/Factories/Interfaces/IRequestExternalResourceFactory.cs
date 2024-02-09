using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;

public interface IRequestExternalResourceFactory : IFactory<RequestExternalResource>
{
    IRequestExternalResourceFactory WithUserId(int userId);
    IRequestExternalResourceFactory WithName(string name);
    IRequestExternalResourceFactory WithBaseUrl(string baseUrl);
    IRequestExternalResourceFactory WithApiKey(string apiKey);
    IRequestExternalResourceFactory WithStatus(ExternalResourceStatus status);
    IRequestExternalResourceFactory WithCategory(ExternalResourceCategory category);
}
