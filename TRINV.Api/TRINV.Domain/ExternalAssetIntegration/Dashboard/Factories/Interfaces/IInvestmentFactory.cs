using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories.Interfaces;

public interface IInvestmentFactory : IFactory<Investment>
{
    IInvestmentFactory WithAcountId(int acountId);

    IInvestmentFactory WithAssetId(string assetId);

    IInvestmentFactory WithQuantity(decimal quantity);

    IInvestmentFactory WithPurchasePrice(decimal purchasePrice);

    IInvestmentFactory WithPurchasePricePerUnit(decimal purchasePricePerUnit);
}
