using Mapster;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Services;

public class ExternalAssetsService : IExternalAssetsService
{
    readonly IInvestmentDomainRepository investmentDomainRepository;

    public ExternalAssetsService(IInvestmentDomainRepository investmentDomainRepository)
    {
        this.investmentDomainRepository = investmentDomainRepository;
    }

    public async Task<IEnumerable<AssetInfo>> GetExternalAssetsAsync(CancellationToken cancellationToken)
    {
        var res = await this.investmentDomainRepository.GetAllByAccount(1, cancellationToken);
        return res.Adapt<IEnumerable<AssetInfo>>();
    }
}
