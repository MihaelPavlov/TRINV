using MediatR;
using TRINV.Application.ExternalAssetIntegration.Repositories;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Services;

namespace TRINV.Application.ExternalAssetIntegration.Queries;

public class TestQuery : IRequest<IEnumerable<AssetInfo>>
{
}

internal class TestQueryHandler : IRequestHandler<TestQuery, IEnumerable<AssetInfo>>
{
    readonly IExternalAssetsService externalAssetsService;
    readonly ITestQueryRepository testQueryRepository;
    readonly IInvestmentDomainRepository investmentDomainRepository;
    public TestQueryHandler(IExternalAssetsService externalAssetsService, ITestQueryRepository testQueryRepository, IInvestmentDomainRepository investmentDomainRepository)
    {
        this.externalAssetsService = externalAssetsService;
        this.testQueryRepository = testQueryRepository;
        this.investmentDomainRepository = investmentDomainRepository;
    }

    public async Task<IEnumerable<AssetInfo>> Handle(TestQuery request, CancellationToken cancellationToken)
    {
        var test = await this.testQueryRepository.GetAll();
        var tes =await  this.investmentDomainRepository.GetAllByAccount(1,cancellationToken);
        return await this.externalAssetsService.GetExternalAssetsAsync(CancellationToken.None);
    }
}