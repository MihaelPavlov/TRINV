using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories;

public interface IAssetInfoFactory : IFactory<AssetInfo>
{
    IAssetInfoFactory WithPurchasePrice(decimal purchasePrice);

    IAssetInfoFactory WithAssetId(string assetId);
}


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
            this.assetId,
            this.purchasePrice);
    }
}
