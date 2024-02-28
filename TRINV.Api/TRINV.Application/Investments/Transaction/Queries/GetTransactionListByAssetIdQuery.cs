using MediatR;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Queries;

public record GetTransactionListByAssetIdQuery(string AssetId) : IRequest<OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>>;

internal class GetTransactionListByAssetIdQueryHandler : IRequestHandler<GetTransactionListByAssetIdQuery, OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>>
{
    readonly ITransactionDomainRepository domainRepository;

    public GetTransactionListByAssetIdQueryHandler(ITransactionDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>> Handle(GetTransactionListByAssetIdQuery request, CancellationToken cancellationToken)
    {
        var res = await this.domainRepository.FindAllByAssetId(request.AssetId,
            x => x.Select(transaction => new GetTransactionListByAssetIdQueryModel
            {
                Id = transaction.Id,
                AssetId = transaction.AssetId,
                TransactionProfit = transaction.PurchasePrice - transaction.PurchasePricePerUnit - 100

            }), cancellationToken);

        return new OperationResult<IEnumerable<GetTransactionListByAssetIdQueryModel>>(res);
    }
}

public class GetTransactionListByAssetIdQueryModel
{
    public int Id { get; set; }
    public string AssetId { get; set; } = string.Empty;
    public decimal TransactionProfit { get; set; }
}