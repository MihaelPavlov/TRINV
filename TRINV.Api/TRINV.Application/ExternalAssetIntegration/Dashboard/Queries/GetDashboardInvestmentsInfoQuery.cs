using MediatR;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.Dashboard.Queries;

public record GetDashboardInvestmentsInfoQuery(int AccountId) : IRequest<OperationResult<GetDashboardInvestmentsInfoQueryModel>>;

internal class GetDashboardInvestmentsInfoQueryHandler : IRequestHandler<GetDashboardInvestmentsInfoQuery, OperationResult<GetDashboardInvestmentsInfoQueryModel>>
{
    readonly IInvestmentDomainRepository investmentDomainRepository;
    readonly IExternalIntegrationResourceService externalIntegrationResourceService;

    public GetDashboardInvestmentsInfoQueryHandler(IInvestmentDomainRepository investmentDomainRepository, IExternalIntegrationResourceService externalIntegrationResourceService)
    {
        this.investmentDomainRepository = investmentDomainRepository;
        this.externalIntegrationResourceService = externalIntegrationResourceService;
    }

    public async Task<OperationResult<GetDashboardInvestmentsInfoQueryModel>> Handle(GetDashboardInvestmentsInfoQuery request, CancellationToken cancellationToken)
    {
        var investments = await this.investmentDomainRepository.GetAllByAccount(request.AccountId, cancellationToken);
        // var account = accountRepo.Find(request.AccountId) account information 

        var operationResult = new OperationResult<GetDashboardInvestmentsInfoQueryModel>();

        if (!investments.Any())
            return operationResult;

        // Calculating ROI ( Return of Investments )
        decimal totalInitialInvestment = 0;
        decimal totalCurrentValue = 0;

        var cryptoCoins = await this.externalIntegrationResourceService
            .ExecuteAllByCategory(ExternalResourceCategory.Crypto, cancellationToken); // Change ExternalResourceCategory.Crypto with the account type of the account variable

        if (cryptoCoins.Success == false || cryptoCoins is null || cryptoCoins.RelatedObject is null)
            return operationResult.ReturnWithErrorMessage(new InfrastructureException());

        foreach (var investment in investments)
        {
            var asset = cryptoCoins.RelatedObject.FirstOrDefault(c => c.AssetId == investment.AssetId);

            if (asset != null)
            {
                // Calculate the current value of the investment
                totalCurrentValue += investment.Quantity * asset.Price;

                // Calculate the initial investment
                totalInitialInvestment += investment.Quantity * investment.PurchasePricePerUnit;
            }
            //// Handle the case where the corresponding coin data is not found
            //else
            //{
            //    _logger.Log(LogEventLevel.Warning, $"Coin data not found for AssetId: {investment.AssetId}");
            //}
        }

        // Calculate the total percent return using the formula
        decimal totalPercentReturn = (totalCurrentValue - totalInitialInvestment) / totalInitialInvestment * 100;

        operationResult.RelatedObject = new GetDashboardInvestmentsInfoQueryModel(
            investments.Sum(x => x.PurchasePrice),
            investments.Count(),
            totalPercentReturn);

        return operationResult;
    }
}

public record GetDashboardInvestmentsInfoQueryModel(
    decimal TotalInvestmentAmount,
    int TotalInvestments,
    decimal RateOfReturn);
