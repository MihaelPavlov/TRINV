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
        var res = await this.queryRepository.FindAllByAssetId(request.AssetId,
            x => x.Select(transaction => new GetTransactionListByAssetIdQueryModel
            {
                Id = transaction.Id,
                AssetId = transaction.AssetId,
                Name = transaction.Name,
                Quantity = transaction.Quantity,
                PurchasePrice = transaction.PurchasePrice,
                PurchasePricePerUnit = transaction.PurchasePricePerUnit,
                TransactionType = transaction.TransactionType,
                TransactionProfit = transaction.PurchasePrice - transaction.PurchasePricePerUnit - 100

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
    public decimal PurchasePrice { get; set; }
    public decimal PurchasePricePerUnit { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal TransactionProfit { get; set; }
}