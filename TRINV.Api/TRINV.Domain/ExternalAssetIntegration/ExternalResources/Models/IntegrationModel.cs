using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Exceptions;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

public class IntegrationModel : Entity<int>, IAggregateRoot
{
    readonly HashSet<IntegrationModelEndpoint> endpoints;

    internal IntegrationModel(int userId, string name, string baseUrl, string apiKey, ExternalResourceStatus status, ExternalResourceCategory category, List<IntegrationModelEndpoint> endpoints)
    {
        this.Validate(name, baseUrl, apiKey, status, category);

        this.UserId = userId;
        this.Name = name;
        this.BaseUrl = baseUrl;
        this.ApiKey = apiKey;
        this.Status = status;
        this.Category = category;

        this.endpoints = endpoints.ToHashSet();
    }

    public int UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string BaseUrl { get; private set; } = string.Empty;
    public string ApiKey { get; private set; } = string.Empty;
    public ExternalResourceStatus Status { get; private set; }
    public ExternalResourceCategory Category { get; private set; }

    public IReadOnlyCollection<IntegrationModelEndpoint> Endpoints => endpoints.ToList().AsReadOnly();

    public IntegrationModel UpdateName(string name)
    {
        Name = name;
        return this;
    }

    public IntegrationModel UpdateBaseUrl(string baseUrl)
    {
        BaseUrl = baseUrl;
        return this;
    }

    public IntegrationModel UpdateApiKey(string apiKey)
    {
        ApiKey = apiKey;
        return this;
    }

    public IntegrationModel UpdateStatus(ExternalResourceStatus status)
    {
        ValidateStatus(status);
        Status = status;
        return this;
    }

    public IntegrationModel UpdateCategory(ExternalResourceCategory category)
    {
        ValidateCategory(category);
        Category = category;
        return this;
    }

    public void AddEndpoint(IntegrationModelEndpoint endpoint)
       => endpoints.Add(endpoint);

    private void Validate(string name, string baseUrl, string apiKey, ExternalResourceStatus status, ExternalResourceCategory category)
    {
        //TODO: Validate other field with guard
        ValidateStatus(status);
        ValidateCategory(category);
    }

    private void ValidateStatus(ExternalResourceStatus status)
    {
        if (!Enum.IsDefined(status))
            throw new InvalidIntegrationModelException($"Status is not a valid");
    }

    private void ValidateCategory(ExternalResourceCategory category)
    {
        if (!Enum.IsDefined(category))
            throw new InvalidIntegrationModelException($"Category is not a valid");
    }
}
