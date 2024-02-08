using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories;

internal class IntegrationModelEndpointFactory : IIntegrationModelEndpointFactory
{
    HttpRequestType httpRequestType = default!;
    string queryUrl = default!;

    public IIntegrationModelEndpointFactory WithHttpRequestType(HttpRequestType httpRequestType)
    {
        this.httpRequestType = httpRequestType;
        return this;
    }

    public IIntegrationModelEndpointFactory WithQueryUrl(string queryUrl)
    {
        this.queryUrl = queryUrl;
        return this;
    }

    public IntegrationModelEndpoint Build()
    {
        return new IntegrationModelEndpoint(this.queryUrl, this.httpRequestType);
    }
}
