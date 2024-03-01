namespace TRINV.Domain.Common.Repositories;

public interface IDomainRepository<TDomain>
    where TDomain : class, IAggregateRoot
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task AddAsync(TDomain entity, CancellationToken cancellationToken = default);
    void Update(TDomain entity);
    void Delete(TDomain entity);
}
