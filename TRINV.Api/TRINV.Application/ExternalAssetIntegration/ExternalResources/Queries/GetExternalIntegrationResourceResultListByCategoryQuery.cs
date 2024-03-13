using MediatR;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;

public record GetExternalIntegrationResourceResultListByCategoryQuery(int Category) : IRequest<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>>;

internal class GetExternalIntegrationResourceResultListByCategoryQueryHandler : IRequestHandler<GetExternalIntegrationResourceResultListByCategoryQuery, OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>>
{
    readonly IExternalIntegrationResourceService externalIntegrationResourceService;

    public GetExternalIntegrationResourceResultListByCategoryQueryHandler(IExternalIntegrationResourceService externalIntegrationResourceService)
    {
        this.externalIntegrationResourceService = externalIntegrationResourceService;
    }

    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> Handle(GetExternalIntegrationResourceResultListByCategoryQuery request, CancellationToken cancellationToken)
    {
        return await this.externalIntegrationResourceService.ExecuteAllByCategory((ExternalResourceCategory)request.Category, cancellationToken);
    }
}
