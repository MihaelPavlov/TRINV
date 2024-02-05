using Mapster;
using TRINV.Domain.Common.Mapping;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Infrastructure.Investments;

public class InvestmentsMapping : IInitialMapping
{
    readonly IInvestmentFactory investmentFactory;

    public InvestmentsMapping(IInvestmentFactory investmentFactory)
    {
        this.investmentFactory = investmentFactory;
    }

    public void Initialize()
    {
        TypeAdapterConfig<Entities.Investment, Investment>.NewConfig()
        .ConstructUsing(source => this.investmentFactory
            .WithId(source.Id)
            .WithAcountId(source.AccountId)
            .WithAssetId(source.AssetId)
            .WithPurchasePrice(source.PurchasePrice)
            .WithPurchasePricePerUnit(source.PurchasePricePerUnit)
            .WithQuantity(source.Quantity)
            .Build());
    }
}
