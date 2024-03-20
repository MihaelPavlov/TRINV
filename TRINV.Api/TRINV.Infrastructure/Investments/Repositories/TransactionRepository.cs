using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TRINV.Application.Investments.Transaction.Repositories;
using TRINV.Domain.Investments.Transaction.Models;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Infrastructure.Common.Repositories;

namespace TRINV.Infrastructure.Investements.Repositories;

internal class TransactionRepository : DataRepository<IInvestmentDbContext, Entities.Investment, Transaction>, ITransactionDomainRepository, ITransactioQueryRepository
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
    {
        var result = await this.All().AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        return this.mapper.Map<Transaction>(result);
    }

    public async Task<IEnumerable<Transaction>> GetAllByAccount(int accountId, CancellationToken cancellationToken)
        => await this.All().Where(x => x.AccountId == accountId).ProjectTo<Transaction>(this.mapper.ConfigurationProvider).ToListAsync(cancellationToken);

    public async Task<IEnumerable<TResult>> FindAllByAssetId<TResult>(string assetId, Func<IQueryable<Transaction>, IQueryable<TResult>> predicate, CancellationToken cancellationToken)
    {
        var query = predicate(
            this.All()
            .Where(x => x.AssetId == assetId)
            .ProjectTo<Transaction>(this.mapper.ConfigurationProvider));

        return await query
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Transaction>> GetAllAssets(string searchExpression, CancellationToken cancellationToken)
    {
        var res = await this.All().Where(x => x.AssetId.Contains(searchExpression)).ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<Transaction>>(res);
    }
}

public class ExpressionConverter<TProjected, TDomain> : ExpressionVisitor
{
    private readonly ParameterExpression _parameter;

    public ExpressionConverter(ParameterExpression parameter)
    {
        _parameter = parameter;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        // Replace the parameter with the one for TDomain
        return _parameter;
    }
}