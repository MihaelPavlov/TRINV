using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;

public interface IIntegrationModelEndpointFactory : IFactory<IntegrationModelEndpoint>
{
    IIntegrationModelEndpointFactory WithQueryUrl(string queryUrl);
    IIntegrationModelEndpointFactory WithHttpRequestType(HttpRequestType httpRequestType);
}
