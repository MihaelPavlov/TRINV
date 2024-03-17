using TRINV.Application.Common;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Application.ExternalAssetIntegration.Repositories;

public interface IDashboardQueryRepository : IQueryRepository<Investment>
{
    Task<IEnumerable<TResult>> FindAllByAssetId<TResult>(string assetId, Func<IQueryable<Investment>, IQueryable<TResult>> predicate, CancellationToken cancellationToken);
}
