using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Exceptions;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories;

internal class RequestExternalResourceFactory : IRequestExternalResourceFactory
{
    int userId = default!;
    string name = default!;
    string baseUrl = default!;
    string apiKey = default!;
    ExternalResourceStatus status = default!;
    ExternalResourceCategory category = default!;

    public IRequestExternalResourceFactory WithApiKey(string apiKey)
    {
        this.apiKey = apiKey;
        return this;
    }

    public IRequestExternalResourceFactory WithBaseUrl(string baseUrl)
    {
        this.baseUrl = baseUrl;
        return this;
    }

    public IRequestExternalResourceFactory WithCategory(ExternalResourceCategory category)
    {
        this.category = category;
        return this;
    }

    public IRequestExternalResourceFactory WithName(string name)
    {
        this.name = name;
        return this;
    }

    public IRequestExternalResourceFactory WithStatus(ExternalResourceStatus status)
    {
        this.status = status;
        return this;
    }

    public IRequestExternalResourceFactory WithUserId(int userId)
    {
        this.userId = userId;
        return this;
    }

    public RequestExternalResource Build()
    {
        if (string.IsNullOrEmpty(this.name)
            || string.IsNullOrEmpty(this.apiKey)
            || string.IsNullOrEmpty(this.baseUrl)
            || this.userId == 0)
            throw new InvalidRequestExternalResourceException("Requested External Resource is invalid");

        return new RequestExternalResource(
            this.userId,
            this.name,
            this.baseUrl,
            this.apiKey,
            this.status,
            this.category);
    }
}
