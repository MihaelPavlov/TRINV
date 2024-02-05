using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Services;

public interface IExternalAssetsService
{
    Task<IEnumerable<AssetInfo>> GetExternalAssetsAsync(CancellationToken cancellationToken);
}
