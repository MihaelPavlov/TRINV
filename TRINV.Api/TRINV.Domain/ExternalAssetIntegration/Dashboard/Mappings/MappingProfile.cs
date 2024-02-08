using AutoMapper;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Mappings;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<Investment, AssetInfo>()
           .PreserveReferences()
           .IncludeAllDerived()
           .ReverseMap()
           .PreserveReferences()
           .IncludeAllDerived();
    }
}
