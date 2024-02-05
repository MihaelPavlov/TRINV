using TRINV.Domain.Common.Repositories;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Repositories;

public interface IInvestmentDomainRepository : IDomainRepository<Investment>
{
    Task<Investment?> Find(int id, CancellationToken cancellationToken);
    Task<Investment> Delete(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Investment>> GetAllByAccount(int accountId, CancellationToken cancellationToken);
}
