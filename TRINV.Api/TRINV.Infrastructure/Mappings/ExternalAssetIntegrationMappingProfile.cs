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
          .PreserveReferences()
          .IncludeAllDerived()
          .ReverseMap()
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
