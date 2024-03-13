using MediatR;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces.Interfaces;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;

public record GetExternalIntegrationResourceResultListQuery : IRequest<OperationResult>;

internal class GetExternalIntegrationResourceResultListQueryHandler : IRequestHandler<GetExternalIntegrationResourceResultListQuery, OperationResult>
{
    readonly IExternalIntegrationResourceService externalIntegrationResourceService;

    public GetExternalIntegrationResourceResultListQueryHandler(IExternalIntegrationResourceService externalIntegrationResourceService)
    {
        this.externalIntegrationResourceService = externalIntegrationResourceService;
    }

    public async Task<OperationResult> Handle(GetExternalIntegrationResourceResultListQuery request, CancellationToken cancellationToken)
    {
         await this.externalIntegrationResourceService.ExecuteAll(cancellationToken);
        return new OperationResult();
    }
}
