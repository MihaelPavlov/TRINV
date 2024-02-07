using AutoMapper;
using DomainModels = TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Infrastructure.Entities;

public class Investment
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string AssetId { get; set; }

    public string Name { get; set; }

    public decimal Quantity { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal PurchasePricePerUnit { get; set; }

    public InvestmentType InvestmentType { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool IsFromOutsideProvider { get; set; }
}

// TODO: Investigate it..! This approach is working 

public class InvestmentMappingProfile : Profile
{
    public InvestmentMappingProfile()
    {
        // mapping domain model to database entity
        CreateMap< DomainModels.Investment, Investment>()
            .PreserveReferences()
            .IncludeAllDerived()
            .ReverseMap()
            .PreserveReferences()
            .IncludeAllDerived();
    }
}