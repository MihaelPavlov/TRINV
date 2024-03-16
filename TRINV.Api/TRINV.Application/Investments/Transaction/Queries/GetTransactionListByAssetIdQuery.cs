using MediatR;
using TRINV.Application.Investments.Transaction.Repositories;
using TRINV.Domain.Investments.Transaction.Models;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Queries;

public record GetTransactionListByAssetIdQuery(string AssetId) : IRequest<OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>>;

internal class GetTransactionListByAssetIdQueryHandler : IRequestHandler<GetTransactionListByAssetIdQuery, OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>>
{
    readonly ITransactioQueryRepository queryRepository;

    public GetTransactionListByAssetIdQueryHandler(ITransactioQueryRepository queryRepository)
    {
        this.queryRepository = queryRepository;
    }

    public async Task<OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>> Handle(GetTransactionListByAssetIdQuery request, CancellationToken cancellationToken)
    {
        Random r = new Random();

        var res = await this.queryRepository.FindAllByAssetId(request.AssetId,
            x => x.Select(transaction => new GetTransactionListByAssetIdQueryModel
            {
                Id = transaction.Id,
                AssetId = transaction.AssetId,
                Name = transaction.Name,
                Quantity = transaction.Quantity,
                TotalPrice = transaction.TotalPrice,
                PricePerUnit = transaction.PricePerUnit,
                TransactionType = transaction.TransactionType,
                TransactionProfit = transaction.TotalPrice - transaction.PricePerUnit - 100,
                TransactionProfitPercents = r.Next(-30, 30)

            }), cancellationToken);

        return new OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>(res);
    }
}

public class GetTransactionListByAssetIdQueryModel
{
    public int Id { get; set; }
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal PricePerUnit { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal TransactionProfit { get; set; }
    public double TransactionProfitPercents { get; set; }
}