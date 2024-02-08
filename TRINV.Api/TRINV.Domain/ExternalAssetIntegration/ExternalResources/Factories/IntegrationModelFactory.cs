using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Exceptions;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories;

internal class IntegrationModelFactory : IIntegrationModelFactory
{
    int userId = default!;
    string name = default!;
    string baseUrl = default!;
    string apiKey = default!;
    ExternalResourceStatus status = default!;
    ExternalResourceCategory category = default!;

    List<IntegrationModelEndpoint> endpoints = new List<IntegrationModelEndpoint>();

    public IIntegrationModelFactory WithApiKey(string apiKey)
    {
        this.apiKey = apiKey;
        return this;
    }

    public IIntegrationModelFactory WithBaseUrl(string baseUrl)
    {
        this.baseUrl = baseUrl;
        return this;
    }

    public IIntegrationModelFactory WithCategory(ExternalResourceCategory category)
    {
        this.category = category;
        return this;
    }

    public IIntegrationModelFactory WithEndpoints(List<IntegrationModelEndpoint> endpoints)
    {
        this.endpoints.AddRange(endpoints);
        return this;
    }

    public IIntegrationModelFactory WithName(string name)
    {
        this.name = name;
        return this;
    }

    public IIntegrationModelFactory WithStatus(ExternalResourceStatus status)
    {
        this.status = status;
        return this;
    }

    public IIntegrationModelFactory WithUserId(int userId)
    {
        this.userId = userId;
        return this;
    }

    public IntegrationModel Build()
    {
        if (!this.endpoints.Any())
            throw new InvalidIntegrationModelException("There should be atleast one endpoint to be integration model valid");

        return new IntegrationModel(
            this.userId,
            this.name,
            this.baseUrl,
            this.apiKey,
            this.status,
            this.category,this.endpoints);
    }
}
