using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TRINV.Domain.Common;
using TRINV.Domain.Common.Repositories;
using TRINV.Infrastructure.Common.Persistance;

namespace TRINV.Infrastructure.Common.Repositories;

internal abstract class DataRepository<TDbContext, TEntity, TDomain> : IDomainRepository<TDomain>
    where TDbContext : IDbContext
    where TDomain : class, IAggregateRoot
    where TEntity : class
{
    readonly IMapper mapper;
    protected DataRepository(TDbContext db, IMapper mapper)
    {
        this.Data = db; this.mapper = mapper;
    }

    protected TDbContext Data { get; }
    protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

    public async Task Save(
        TDomain entity,
        CancellationToken cancellationToken = default)
    {
        var mappedObject = this.mapper.Map<TEntity>(entity);
        //TODO: Provide better exception 
        if (mappedObject is null)
            throw new ArgumentException("Infrastructure exception: Mapping problem in data repository");
        
        this.Data.Update(mappedObject);
        await this.Data.SaveChangesAsync(cancellationToken);
    }
}
