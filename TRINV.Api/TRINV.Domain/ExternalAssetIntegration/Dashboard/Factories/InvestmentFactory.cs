using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories;

public interface IInvestmentFactory : IFactory<Investment>
{
    IInvestmentFactory WithAcountId(int acountId);

    IInvestmentFactory WithAssetId(string assetId);

    IInvestmentFactory WithQuantity(decimal quantity);

    IInvestmentFactory WithPurchasePrice(decimal purchasePrice);

    IInvestmentFactory WithPurchasePricePerUnit(decimal purchasePricePerUnit);

    IInvestmentFactory WithId(int id);
}

internal class InvestmentFactory : IInvestmentFactory
{
    private int acountId = default!;
    private string assetId = default!;
    private decimal quantity = default!;
    private decimal purchasePrice = default!;
    private decimal purchasePricePerUnit = default!;
    private int id = default!;

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
    public IInvestmentFactory WithId(int id)
    {
        this.id = id;
        return this;
    }

    public Investment Build()
    {
        if (this.id != default)
        {
            return new Investment(
            this.id,
            this.acountId,
            this.assetId,
            this.quantity,
            this.purchasePrice,
            this.purchasePricePerUnit);
        }
        return new Investment(
            this.acountId,
            this.assetId,
            this.quantity,
            this.purchasePrice,
            this.purchasePricePerUnit);
    }
}
