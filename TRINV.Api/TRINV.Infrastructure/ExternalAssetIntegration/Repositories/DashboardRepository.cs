using TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;
using TRINV.Infrastructure.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;
using TRINV.Application.ExternalAssetIntegration.Repositories;

namespace TRINV.Infrastructure.ExternalAssetIntegration.Repositories;

internal class DashboardRepository : DataRepository<IExternalAssetIntegrationDbContext, Entities.Investment, Investment>, IDashboardDomainRepository, IDashboardQueryRepository
{
    readonly IMapper mapper;

    public DashboardRepository(IExternalAssetIntegrationDbContext db, IMapper mapper)
        : base(db, mapper)
    {
        this.mapper = mapper;
    }

    public Task<Investment> Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Investment?> Find(int id, CancellationToken cancellationToken)
        => await this
         .All().ProjectTo<Investment>(this.mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<IEnumerable<TResult>> FindAllByAssetId<TResult>(string assetId, Func<IQueryable<Investment>, IQueryable<TResult>> predicate, CancellationToken cancellationToken)
    {
        var query = predicate(
                   this.All()
                   .Where(x => x.AssetId == assetId)
                   .ProjectTo<Investment>(this.mapper.ConfigurationProvider));

        return await query
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Investment>> GetAll(CancellationToken cancellationToken)
    {
        return await this.All().ProjectTo<Investment>(this.mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}

