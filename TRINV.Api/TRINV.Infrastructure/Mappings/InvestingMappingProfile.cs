using AutoMapper;
using TRINV.Domain.Investments.Transaction.Models;
using DbEntities = TRINV.Infrastructure.Entities;

namespace TRINV.Infrastructure.Mappings;

public class InvestingMappingProfile : Profile
{
    public InvestingMappingProfile()
    {
        CreateMap<Transaction, DbEntities.Investment>()
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
    }
}
