using Mapster;
using Microsoft.EntityFrameworkCore;
using TRINV.Domain.Investments.Investment.Models;
using TRINV.Domain.Investments.Investment.Repositories;
using TRINV.Infrastructure.Common.Repositories;

namespace TRINV.Infrastructure.Investements.Repositories;

internal class TransactionRepository : DataRepository<IInvestmentDbContext, Entities.Investment, Transaction>, ITransactionDomainRepository
{
    public TransactionRepository(IInvestmentDbContext db)
        : base(db)
    { }

    public Task<Transaction> Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Transaction?> Find(int id, CancellationToken cancellationToken)
     => (await this
            .All()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken))?.Adapt<Transaction>();

    public async Task<IEnumerable<Transaction>> GetAllByAccount(int accountId, CancellationToken cancellationToken)
        => (await this.All().Where(x => x.AccountId == accountId).ToListAsync(cancellationToken)).Adapt<IEnumerable<Transaction>>();
}
