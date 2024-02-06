using AutoMapper;
using TRINV.Domain.Common;
using TRINV.Domain.Common.Mapping;

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

public class AssetInfoMappingProfile : Profile
{
    public AssetInfoMappingProfile()
    {
        CreateMap<Investment, AssetInfo>()
            .PreserveReferences()
            .IncludeAllDerived()
            .ReverseMap()
            .PreserveReferences()
            .IncludeAllDerived();
    }
}
