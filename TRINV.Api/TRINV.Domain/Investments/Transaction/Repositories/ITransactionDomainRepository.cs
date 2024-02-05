using TRINV.Domain.Common.Repositories;
using TRINV.Domain.Investments.Investment.Models;

namespace TRINV.Domain.Investments.Investment.Repositories;

public interface ITransactionDomainRepository : IDomainRepository<Transaction>
{
    Task<Transaction?> Find(int id, CancellationToken cancellationToken);
    Task<Transaction> Delete(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Transaction>> GetAllByAccount(int accountId, CancellationToken cancellationToken);
}
