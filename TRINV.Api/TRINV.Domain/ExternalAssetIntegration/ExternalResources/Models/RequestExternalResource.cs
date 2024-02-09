using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Exceptions;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

public class RequestExternalResource : Entity<int>, IAggregateRoot
{
    internal RequestExternalResource(int userId, string name, string baseUrl, string apiKey, ExternalResourceStatus status, ExternalResourceCategory category)
    {
        this.Validate(name, baseUrl, apiKey, status, category);

        this.UserId = userId;
        this.Name = name;
        this.BaseUrl = baseUrl;
        this.ApiKey = apiKey;
        this.Status = status;
        this.Category = category;
    }

    public int UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string BaseUrl { get; private set; } = string.Empty;
    public string ApiKey { get; private set; } = string.Empty;
    public ExternalResourceStatus Status { get; private set; }
    public ExternalResourceCategory Category { get; private set; }

    public RequestExternalResource UpdateName(string name)
    {
        this.Name = name;
        return this;
    }

    public RequestExternalResource UpdateBaseUrl(string baseUrl)
    {
        this.BaseUrl = baseUrl;
        return this;
    }

    public RequestExternalResource UpdateApiKey(string apiKey)
    {
        this.ApiKey = apiKey;
        return this;
    }

    public RequestExternalResource UpdateStatus(ExternalResourceStatus status)
    {
        ValidateStatus(status);
        this.Status = status;
        return this;
    }

    public RequestExternalResource UpdateCategory(ExternalResourceCategory category)
    {
        ValidateCategory(category);
        this.Category = category;
        return this;
    }

    private void Validate(string name, string baseUrl, string apiKey, ExternalResourceStatus status, ExternalResourceCategory category)
    {
        //TODO: Validate other field with guard
        ValidateStatus(status);
        ValidateCategory(category);
    }

    private void ValidateStatus(ExternalResourceStatus status)
    {
        if (!Enum.IsDefined(status))
            throw new InvalidRequestExternalResourceException($"Status is not a valid");
    }

    private void ValidateCategory(ExternalResourceCategory category)
    {
        if (!Enum.IsDefined(category))
            throw new InvalidRequestExternalResourceException($"Category is not a valid");
    }
}
