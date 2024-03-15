using TRINV.Application.Common;
using TRINV.Application.Investments.Transaction.Queries;
using DomainModels = TRINV.Domain.Investments.Transaction.Models;

namespace TRINV.Application.Investments.Transaction.Repositories;

public interface ITransactioQueryRepository : IQueryRepository<DomainModels.Transaction>
{
    Task<IEnumerable<TResult>> FindAllByAssetId<TResult>(string assetId, Func<IQueryable<DomainModels.Transaction>, IQueryable<TResult>> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<GetAssetListQueryModel>> GetAllAssets(string searchExpression, CancellationToken cancellationToken);
}
