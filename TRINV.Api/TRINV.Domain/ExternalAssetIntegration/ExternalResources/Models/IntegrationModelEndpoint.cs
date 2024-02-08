using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

public class IntegrationModelEndpoint : Entity<int>, IAggregateRoot
{
    public string QueryUrl { get; private set; }
    public HttpRequestType HttpRequestType { get; private set; }

    internal IntegrationModelEndpoint(string queryUrl, HttpRequestType httpRequestType)
    {
        // Add Validation
        QueryUrl = queryUrl;
        HttpRequestType = httpRequestType;
    }
}
