using Mapster;
using TRINV.Domain.Common.Mapping;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Mappings;

public class ExternalAssetIntegrationMappings : IInitialMapping
{
    readonly IAssetInfoFactory assetInfoFactory;

    public ExternalAssetIntegrationMappings(IAssetInfoFactory assetInfoFactory)
    {
        this.assetInfoFactory = assetInfoFactory;
    }

    public void Initialize()
    {
        TypeAdapterConfig<Investment, AssetInfo>.NewConfig()
          .ConstructUsing(source => this.assetInfoFactory
            .WithPurchasePrice(source.PurchasePrice)
            .WithAssetId(source.AssetId)
            .Build());
    }
}
