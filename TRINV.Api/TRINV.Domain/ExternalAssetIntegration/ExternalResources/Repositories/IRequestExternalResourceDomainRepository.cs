using System.Linq.Expressions;
using TRINV.Domain.Common.Repositories;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;

public interface IRequestExternalResourceDomainRepository : IDomainRepository<RequestExternalResource>
{
    Task<RequestExternalResource?> FindAsync(Expression<Func<RequestExternalResource, bool>> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<RequestExternalResource>> GetAllByUserAsync(int useId, CancellationToken cancellationToken);
    Task<IEnumerable<RequestExternalResource>> AllAsync(CancellationToken cancellationToken);
}
