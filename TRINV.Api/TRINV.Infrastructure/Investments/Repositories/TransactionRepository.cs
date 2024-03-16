using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq.Expressions;
using TRINV.Application.Investments.Transaction.Queries;
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
     => await this
            .All().ProjectTo<Transaction>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

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

    public async Task<IEnumerable<GetAssetListQueryModel>> GetAllAssets(string searchExpression, CancellationToken cancellationToken)
    {
        return await this.All().Where(x => x.AssetId.Contains(searchExpression)).GroupBy(x => new { AssetId = x.AssetId, Name = x.Name }).Select(x => new GetAssetListQueryModel
        {
            AssetId = x.Key.AssetId,
            Name = x.Key.Name,
            TotalQuantity = x.Sum(x => x.Quantity),
            TotalBalance = x.Sum(x => x.TotalPrice)
        }).ToListAsync(cancellationToken);
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