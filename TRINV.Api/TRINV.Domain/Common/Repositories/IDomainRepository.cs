namespace TRINV.Domain.Common.Repositories;

public interface IDomainRepository<in TDomain>
    where TDomain : class,IAggregateRoot
{
    Task Save(TDomain entity, CancellationToken cancellationToken = default);
}
