using AutoMapper;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Services;

public class ExternalAssetsService : IExternalAssetsService
{
    readonly IDashboardDomainRepository investmentDomainRepository;
    readonly IMapper mapper;

    public ExternalAssetsService(IDashboardDomainRepository investmentDomainRepository, IMapper mapper)
    {
        this.investmentDomainRepository = investmentDomainRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<AssetInfo>> GetExternalAssetsAsync(CancellationToken cancellationToken)
    {
        var res = await this.investmentDomainRepository.GetAll(cancellationToken);
        return this.mapper.ProjectTo<AssetInfo>(res.AsQueryable());
    }
}
