using MediatR;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces.Interfaces;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;

public record GetExternalIntegrationResourceResultListQuery : IRequest<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>>;

internal class GetExternalIntegrationResourceResultListQueryHandler : IRequestHandler<GetExternalIntegrationResourceResultListQuery, OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>>
{
    readonly IExternalIntegrationResourceService externalIntegrationResourceService;

    public GetExternalIntegrationResourceResultListQueryHandler(IExternalIntegrationResourceService externalIntegrationResourceService)
    {
        this.externalIntegrationResourceService = externalIntegrationResourceService;
    }

    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> Handle(GetExternalIntegrationResourceResultListQuery request, CancellationToken cancellationToken)
    {
        return await this.externalIntegrationResourceService.ExecuteAll(cancellationToken);
    }
}
