using AutoMapper;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Services;

public class ExternalAssetsService : IExternalAssetsService
{
    readonly IInvestmentDomainRepository investmentDomainRepository;
    readonly IMapper mapper;

    public ExternalAssetsService(IInvestmentDomainRepository investmentDomainRepository, IMapper mapper)
    {
        this.investmentDomainRepository = investmentDomainRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<AssetInfo>> GetExternalAssetsAsync(CancellationToken cancellationToken)
    {
        var res = await this.investmentDomainRepository.GetAllByAccount(1, cancellationToken);
        return this.mapper.ProjectTo<AssetInfo>(res.AsQueryable());
    }
}
