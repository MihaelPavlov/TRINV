using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Infrastructure.Entities;

public class IntegrationModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public ExternalResourceStatus Status { get; set; }
    public ExternalResourceCategory Category { get; set; }

    public HashSet<IntegrationModelEndpoint> Endpoints { get; set; } = new();
}
