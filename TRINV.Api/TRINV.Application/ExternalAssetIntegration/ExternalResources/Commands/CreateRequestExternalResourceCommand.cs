using MediatR;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Factories.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Commands;

public class CreateRequestExternalResourceCommand : IRequest<OperationResult>
{
    public string Name { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
    public ExternalResourceCategory Category { get; set; }
}

internal class CreateRequestExternalResourceCommandHandler : IRequestHandler<CreateRequestExternalResourceCommand, OperationResult>
{
    readonly IRequestExternalResourceFactory integrationModelFactory;
    readonly IRequestExternalResourceDomainRepository domainRepository;

    public CreateRequestExternalResourceCommandHandler(IRequestExternalResourceFactory integrationModelFactory, IRequestExternalResourceDomainRepository domainRepository)
    {
        this.integrationModelFactory = integrationModelFactory;
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult> Handle(CreateRequestExternalResourceCommand request, CancellationToken cancellationToken)
    {  
        var integrationModel = this.integrationModelFactory
            .WithUserId(1)
            .WithName(request.Name)
            .WithApiKey(request.ApiKey)
            .WithBaseUrl(request.BaseUrl)
            .WithCategory(request.Category)
            .WithStatus(ExternalResourceStatus.InReview)
            .Build();

        await this.domainRepository.AddAsync(integrationModel, cancellationToken);
        await this.domainRepository.SaveChangesAsync(cancellationToken);

        return new OperationResult();
    }
}
