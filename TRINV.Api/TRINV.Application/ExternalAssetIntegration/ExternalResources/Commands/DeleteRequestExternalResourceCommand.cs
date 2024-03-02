using MediatR;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Commands;

public record DeleteRequestExternalResourceCommand(int Id) : IRequest<OperationResult>;

internal class DeleteRequestExternalResourceCommandHandler : IRequestHandler<DeleteRequestExternalResourceCommand, OperationResult>
{
    readonly IRequestExternalResourceDomainRepository domainRepository;

    public DeleteRequestExternalResourceCommandHandler(IRequestExternalResourceDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult> Handle(DeleteRequestExternalResourceCommand request, CancellationToken cancellationToken)
    {
        var integrationModel = await this.domainRepository.FindAsync(x => x.Id == request.Id, cancellationToken);

        if (integrationModel == null)
            return new OperationResult().ReturnWithErrorMessage(new NotFoundException($"Request for external resource with id {request.Id} was not found"));

        this.domainRepository.Delete(integrationModel);
        await this.domainRepository.SaveChangesAsync(cancellationToken);

        return new OperationResult();
    }
}