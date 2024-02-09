using AutoMapper;
using MediatR;
using TRINV.Domain.Common.Mapping;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;

public record GetRequestExternalResourceListQuery : IRequest<OperationResult<IEnumerable<GetRequestExternalResourceQueryModel>>>;

internal class GetRequestExternalResourceListQueryHandler : IRequestHandler<GetRequestExternalResourceListQuery, OperationResult<IEnumerable<GetRequestExternalResourceQueryModel>>>
{
    readonly IMapper mapper;
    readonly IRequestExternalResourceDomainRepository domainRepository;

    public GetRequestExternalResourceListQueryHandler(IRequestExternalResourceDomainRepository domainRepository, IMapper mapper)
    {
        this.domainRepository = domainRepository;
        this.mapper = mapper;
    }
    public async Task<OperationResult<IEnumerable<GetRequestExternalResourceQueryModel>>> Handle(GetRequestExternalResourceListQuery request, CancellationToken cancellationToken)
    {
        var requestExternalResources = await this.domainRepository.AllAsync(cancellationToken);

        var operationResult = new OperationResult<IEnumerable<GetRequestExternalResourceQueryModel>>();
        operationResult.RelatedObject = this.mapper.Map<IEnumerable<GetRequestExternalResourceQueryModel>>(requestExternalResources);

        if (operationResult.RelatedObject is null)
            return operationResult.ReturnWithErrorMessage(new BadRequestException());

        return operationResult;
    }
}

public class GetRequestExternalResourceQueryModel :IMapFrom<RequestExternalResource>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public ExternalResourceStatus Status { get; set; }
    public ExternalResourceCategory Category { get; set; }
}
