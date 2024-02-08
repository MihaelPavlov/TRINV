using TRINV.Domain.Common;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories.Interfaces;

public interface IAssetInfoFactory : IFactory<AssetInfo>
{
    IAssetInfoFactory WithPurchasePrice(decimal purchasePrice);

    IAssetInfoFactory WithAssetId(string assetId);
}
