using MediatR;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Commands;

public class UpdateRequestExternalResourceCommand : IRequest<OperationResult>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
    public ExternalResourceCategory Category { get; set; }
}

internal class UpdateRequestExternalResourceCommandHandler : IRequestHandler<UpdateRequestExternalResourceCommand, OperationResult>
{
    readonly IRequestExternalResourceDomainRepository domainRepository;

    public UpdateRequestExternalResourceCommandHandler(IRequestExternalResourceDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult> Handle(UpdateRequestExternalResourceCommand request, CancellationToken cancellationToken)
    {
        var requestExternalResource = await this.domainRepository.FindAsync(x => x.Id == request.Id, cancellationToken);

        if (requestExternalResource is null)
            return new OperationResult().ReturnWithErrorMessage(new NotFoundException($"Request for External Resource with id {request.Id} was not found"));

        requestExternalResource
            .UpdateName(request.Name)
            .UpdateApiKey(request.ApiKey)
            .UpdateBaseUrl(request.BaseUrl)
            .UpdateCategory(request.Category);

        this.domainRepository.Update(requestExternalResource);
        await this.domainRepository.SaveChangesAsync(cancellationToken);

        return new OperationResult();
    }
}
