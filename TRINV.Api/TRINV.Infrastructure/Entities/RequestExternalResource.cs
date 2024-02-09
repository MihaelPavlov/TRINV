﻿using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;

namespace TRINV.Infrastructure.Entities;

public class RequestExternalResource
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public ExternalResourceStatus Status { get; set; }
    public ExternalResourceCategory Category { get; set; }
}
