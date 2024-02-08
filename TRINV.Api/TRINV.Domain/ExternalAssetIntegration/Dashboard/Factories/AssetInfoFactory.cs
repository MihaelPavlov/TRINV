using TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories.Interfaces;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories;

internal class AssetInfoFactory : IAssetInfoFactory
{
    private string assetId = default!;
    private decimal purchasePrice = default!;

    public IAssetInfoFactory WithPurchasePrice(decimal purchasePrice)
    {
        this.purchasePrice = purchasePrice;
        return this;
    }

    public IAssetInfoFactory WithAssetId(string assetId)
    {
        this.assetId = assetId;
        return this;
    }

    public AssetInfo Build()
    {
        // validations

        return new AssetInfo(
            assetId,
            purchasePrice);
    }
}
