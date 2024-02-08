using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;

namespace TRINV.Infrastructure.Entities;

public class IntegrationModelEndpoint
{
    public int Id { get; set; }
    public int IntegrationModelId { get; set; }
    public string QueryUrl { get; set; } = string.Empty;
    public HttpRequestType HttpRequestType { get; set; }

    public IntegrationModel IntegrationModel { get; set; } = null!;
}
