using AutoMapper;
using MediatR;
using TRINV.Domain.Common.Helpers;
using TRINV.Domain.Common.Mapping;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;

public record GetExternalIntegrationResourceListQuery : IRequest<OperationResult<IEnumerable<GetExternalIntegrationResourceListQueryModel>>>;

internal class GetExternalIntegrationResourceListQueryHandler : IRequestHandler<GetExternalIntegrationResourceListQuery, OperationResult<IEnumerable<GetExternalIntegrationResourceListQueryModel>>>
{
    readonly IMapper mapper;

    public GetExternalIntegrationResourceListQueryHandler(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<OperationResult<IEnumerable<GetExternalIntegrationResourceListQueryModel>>> Handle(GetExternalIntegrationResourceListQuery request, CancellationToken cancellationToken)
    {
        var result = EnumerationHelper.GetAll<ExternalIntegrationResource>();
        var mappedResult = this.mapper.Map<IEnumerable<GetExternalIntegrationResourceListQueryModel>>(result);

        if (mappedResult is null)
            return new OperationResult<IEnumerable<GetExternalIntegrationResourceListQueryModel>>()
                .ReturnWithErrorMessage(new BadRequestException());

        return new OperationResult<IEnumerable<GetExternalIntegrationResourceListQueryModel>>(mappedResult);
    }
}

public class GetExternalIntegrationResourceListQueryModel : IMapFrom<ExternalIntegrationResource>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ExternalResourceCategory Category { get; set; }
}