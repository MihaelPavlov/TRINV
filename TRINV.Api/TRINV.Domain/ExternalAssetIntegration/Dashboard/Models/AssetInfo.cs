using TRINV.Domain.Common;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

public class AssetInfo : IAggregateRoot
{
    internal AssetInfo(string assetId, decimal purchasePrice)
    {
        this.AssetId = assetId;
        this.PurchasePrice = purchasePrice;
    }

    public string AssetId { get; private set; }
    public decimal PurchasePrice { get; private set; }
}
