using MediatR;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.Dashboard.Queries;

public record GetInvestmentPerformanceQuery() : IRequest<OperationResult<IEnumerable<GetInvestmentPerformanceQueryModel>>>;

internal class GetInvestmentPerformanceQueryHandler : IRequestHandler<GetInvestmentPerformanceQuery, OperationResult<IEnumerable<GetInvestmentPerformanceQueryModel>>>
{
    readonly IMediator mediator;
    readonly IDashboardDomainRepository domainRepository;

    public GetInvestmentPerformanceQueryHandler(IMediator mediator, IDashboardDomainRepository domainRepository)
    {
        this.mediator = mediator;
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult<IEnumerable<GetInvestmentPerformanceQueryModel>>> Handle(GetInvestmentPerformanceQuery request, CancellationToken cancellationToken)
    {
        var operationResult = new OperationResult<IEnumerable<GetInvestmentPerformanceQueryModel>>();

        var currentCryptoPrices = await this.mediator.Send(new GetExternalIntegrationResourceResultListByCategoryQuery((int)ExternalResourceCategory.Crypto), cancellationToken);

        //TODO: Need to be user related
        var currentUserInvestments = await this.domainRepository.GetAll(cancellationToken);

        var groupedInvestments = currentUserInvestments
            .GroupBy(i => i.AssetId)
            .Select(x => new
            {
                AssetId = x.Key,
                Name = x.First().Name,
                TotalQuantity = x.Sum(i => i.Quantity),
                TotalValueInFiat = x.Sum(i => i.TotalPrice),
                AverageValuePerUnitInFiat = x.Sum(i => i.TotalPrice) / x.Sum(q => q.Quantity),
            });

        Dictionary<string, decimal> currentPrices = new Dictionary<string, decimal>();

        if (currentCryptoPrices == null || !currentCryptoPrices.Success || currentCryptoPrices.RelatedObject == null)
            return operationResult.ReturnWithErrorMessage(new InfrastructureException());

        currentPrices = currentCryptoPrices.RelatedObject
            .Where(s => groupedInvestments.Any(gi => gi.AssetId == s.AssetId))
            .ToDictionary(s => s.AssetId, p => p.Price);

        var currentUserInvestmentsPerformanceList = groupedInvestments
            .Select(investment =>
            {
                var currentInvestmentPrice = currentPrices.GetValueOrDefault(investment.AssetId, 0m);

                var returnRate = ((currentInvestmentPrice - investment.AverageValuePerUnitInFiat) / investment.AverageValuePerUnitInFiat) * 100;

                return new GetInvestmentPerformanceQueryModel
                {
                    AssetId = investment.AssetId,
                    Name = investment.Name,
                    TotalInitialInvestment = Math.Round(investment.TotalValueInFiat, 2),
                    TotalCurrentInvestment = Math.Round(investment.TotalValueInFiat + (investment.TotalValueInFiat * (returnRate / 100)), 2),
                    Rate = Math.Round(returnRate, 2),
                };
            })
            .OrderByDescending(x => x.Rate)
            .ToList();

        operationResult.RelatedObject = currentUserInvestmentsPerformanceList;

        return operationResult;
    }
}

public class GetInvestmentPerformanceQueryModel
{
    public string AssetId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public decimal TotalInitialInvestment { get; set; }

    public decimal TotalCurrentInvestment { get; set; }

    public decimal Rate { get; set; }
}
