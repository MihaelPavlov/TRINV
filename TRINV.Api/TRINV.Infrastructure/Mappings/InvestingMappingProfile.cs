using AutoMapper;
using TRINV.Domain.Investments.Transaction.Models;
using DbEntities = TRINV.Infrastructure.Entities;

namespace TRINV.Infrastructure.Mappings;

public class InvestingMappingProfile : Profile
{
    public InvestingMappingProfile()
    {
        CreateMap<Transaction, DbEntities.Investment>()
          .PreserveReferences()
          .IncludeAllDerived()
          .ReverseMap()
          .PreserveReferences()
          .IncludeAllDerived();
    }
}
