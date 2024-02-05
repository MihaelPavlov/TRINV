using DomainModels = TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;
using TRINV.Infrastructure.Common.Repositories;
using TRINV.Infrastructure.Investements;
using Microsoft.EntityFrameworkCore;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using Mapster;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Factories;
using TRINV.Application.ExternalAssetIntegration.Repositories;

namespace TRINV.Infrastructure.ExternalAssetIntegration.Repositories;

internal class InvestmentRepository : DataRepository<IInvestmentDbContext, Entities.Investment, DomainModels.Investment>, IInvestmentDomainRepository, ITestQueryRepository
{
    readonly IInvestmentFactory investmentFactory;
    public InvestmentRepository(IInvestmentDbContext db, IInvestmentFactory investmentFactory)
        : base(db)
    {
        this.investmentFactory = investmentFactory;
    }

    public Task<DomainModels.Investment> Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<DomainModels.Investment?> Find(int id, CancellationToken cancellationToken)
        => (await this
         .All().FirstOrDefaultAsync(c => c.Id == id, cancellationToken)).Adapt<Investment>();

    public async Task<IEnumerable<Investment>> GetAll()
    {
        return (await this.All().ToListAsync()).Adapt<IEnumerable<Investment>>();
    }

    public async Task<IEnumerable<Investment>> GetAllByAccount(int accountId, CancellationToken cancellationToken)
    {
        var res = await this.All().Where(x => x.AccountId == accountId).ToListAsync(cancellationToken);
        //var config = new TypeAdapterConfig();
        //config.NewConfig<TRINV.Infrastructure.Entities.Investment, TRINV.Domain.ExternalAssetIntegration.Dashboard.Models.Investment>()
        //    .ConstructUsing(source => this.investmentFactory
        //    .WithAcountId(source.AccountId)
        //    .WithAssetId(source.AssetId)
        //    .WithPurchasePrice(source.PurchasePrice)
        //    .WithPurchasePricePerUnit(source.PurchasePricePerUnit)
        //    .WithQuantity(source.Quantity)
        //    .Build())
        //    .Map(dest => dest.AccountId, src => src.AccountId)
        //    .Map(dest => dest.AssetId, src => src.AssetId)
        //    .Map(dest => dest.PurchasePrice, src => src.PurchasePrice)
        //    .Map(dest => dest.PurchasePricePerUnit, src => src.PurchasePricePerUnit)
        //    .Map(dest => dest.Quantity, src => src.Quantity)
        //    // ... map other properties as needed ...
        //    ;
        //  TypeAdapterConfig<Entities.Investment, Investment>.NewConfig()
        //.ConstructUsing(source => this.investmentFactory
        //      .WithAcountId(source.AccountId)
        //      .WithAssetId(source.AssetId)
        //      .WithPurchasePrice(source.PurchasePrice)
        //      .WithPurchasePricePerUnit(source.PurchasePricePerUnit)
        //      .WithQuantity(source.Quantity)
        //      .Build());

        // Perform the mapping
        var destinationList =
             res.Adapt<List<Investment>>();
        return destinationList;
    }

}

