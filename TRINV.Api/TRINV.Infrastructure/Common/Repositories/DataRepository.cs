using Mapster;
using TRINV.Domain.Common;
using TRINV.Domain.Common.Repositories;
using TRINV.Infrastructure.Common.Persistance;

namespace TRINV.Infrastructure.Common.Repositories;

internal abstract class DataRepository<TDbContext, TEntity, TDomain> : IDomainRepository<TDomain>
    where TDbContext : IDbContext
    where TDomain : class, IAggregateRoot
    where TEntity : class
{
    protected DataRepository(TDbContext db) => this.Data = db;

    protected TDbContext Data { get; }

    protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

    public async Task Save(
        TDomain entity,
        CancellationToken cancellationToken = default)
    {

        this.Data.Update(entity.Adapt<TEntity>());

        await this.Data.SaveChangesAsync(cancellationToken);
    }
}
