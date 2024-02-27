using TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories;

internal class InvestmentFactory : IInvestmentFactory
{
    private int acountId = default!;
    private string assetId = default!;
    private decimal quantity = default!;
    private decimal purchasePrice = default!;
    private decimal purchasePricePerUnit = default!;

    public IInvestmentFactory WithAcountId(int acountId)
    {
        this.acountId = acountId;
        return this;
    }

    public IInvestmentFactory WithAssetId(string assetId)
    {
        this.assetId = assetId;
        return this;
    }

    public IInvestmentFactory WithQuantity(decimal quantity)
    {
        this.quantity = quantity;
        return this;
    }
    public IInvestmentFactory WithPurchasePrice(decimal purchasePrice)
    {
        this.purchasePrice = purchasePrice;
        return this;
    }
    public IInvestmentFactory WithPurchasePricePerUnit(decimal purchasePricePerUnit)
    {
        this.purchasePricePerUnit = purchasePricePerUnit;
        return this;
    }

    public Investment Build()
    {
        return new Investment(
            this.acountId,
            this.assetId,
            this.quantity,
            this.purchasePrice,
            this.purchasePricePerUnit);
    }
}
