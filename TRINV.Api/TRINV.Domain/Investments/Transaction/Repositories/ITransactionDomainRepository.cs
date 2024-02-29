using System.Linq.Expressions;
using TRINV.Domain.Common.Repositories;

namespace TRINV.Domain.Investments.Transaction.Repositories;

public interface ITransactionDomainRepository : IDomainRepository<Models.Transaction>
{
    Task<Models.Transaction?> Find(int id, CancellationToken cancellationToken);
    Task<Models.Transaction> Delete(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Models.Transaction>> GetAllByAccount(int accountId, CancellationToken cancellationToken);
}
