using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TRINV.Domain.Investments.Transaction.Models;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Infrastructure.Common.Repositories;

namespace TRINV.Infrastructure.Investements.Repositories;

internal class TransactionRepository : DataRepository<IInvestmentDbContext, Entities.Investment, Transaction>, ITransactionDomainRepository
{
    readonly IMapper mapper;
    public TransactionRepository(IInvestmentDbContext db, IMapper mapper)
        : base(db, mapper)
    { this.mapper = mapper; }

    public Task<Transaction> Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Transaction?> Find(int id, CancellationToken cancellationToken)
     => await this
            .All().ProjectTo<Transaction>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<IEnumerable<Transaction>> GetAllByAccount(int accountId, CancellationToken cancellationToken)
        => await this.All().Where(x => x.AccountId == accountId).ProjectTo<Transaction>(this.mapper.ConfigurationProvider).ToListAsync(cancellationToken);
}
