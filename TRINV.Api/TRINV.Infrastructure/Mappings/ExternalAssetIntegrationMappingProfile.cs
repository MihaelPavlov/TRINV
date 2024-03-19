using AutoMapper;
using DbEntities = TRINV.Infrastructure.Entities;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Infrastructure.Mappings;

public class ExternalAssetIntegrationMappingProfile : Profile
{
    public ExternalAssetIntegrationMappingProfile()
    {
        CreateMap<Investment, DbEntities.Investment>()
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => Convert.ToString(src.Quantity)))
          .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => Convert.ToString(src.TotalPrice)))
          .ForMember(dest => dest.PricePerUnit, opt => opt.MapFrom(src => Convert.ToString(src.PricePerUnit)))
          .PreserveReferences()
          .IncludeAllDerived()
          .ReverseMap()
          .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => decimal.Parse(src.Quantity)))
          .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => decimal.Parse(src.TotalPrice)))
          .ForMember(dest => dest.PricePerUnit, opt => opt.MapFrom(src => decimal.Parse(src.PricePerUnit)))
          .PreserveReferences()
          .IncludeAllDerived();

        CreateMap<RequestExternalResource, DbEntities.RequestExternalResource>()
         .PreserveReferences()
         .IncludeAllDerived()
         .ReverseMap()
         .PreserveReferences()
         .IncludeAllDerived();
    }
}
