using MediatR;
using TRINV.Domain.Investments.Transaction.Factories.Interfaces;
using TRINV.Domain.Investments.Transaction.Models;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Queries;

public record GetTransactionByIdQuery(int TransactionId) : IRequest<OperationResult<IEnumerable<GetTransactionByIdQueryModel>>>;

internal class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, OperationResult<IEnumerable<GetTransactionByIdQueryModel>>>
{
    readonly ITransactionFactory transactionFactory;
    readonly ITransactionDomainRepository domainRepository;

    public GetTransactionByIdQueryHandler(ITransactionFactory transactionFactory, ITransactionDomainRepository domainRepository)
    {
        this.transactionFactory = transactionFactory;
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult<IEnumerable<GetTransactionByIdQueryModel>>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await this.domainRepository.Find(request.TransactionId)
    }
}

public class GetTransactionByIdQueryModel
{
    public int TransactionId { get; set; }
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal PurchasePricePerUnit { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal TransactionalProfit { get; set; }
}