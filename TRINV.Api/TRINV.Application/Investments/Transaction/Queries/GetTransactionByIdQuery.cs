using MediatR;
using TRINV.Domain.Common.Mapping;
using DomainModels = TRINV.Domain.Investments.Transaction.Models;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;
using TRINV.Domain.Common.Enums;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;

namespace TRINV.Application.Investments.Transaction.Queries;

public record GetTransactionByIdQuery(int Id) : IRequest<OperationResult<GetTransactionByIdQueryModel>>;

internal class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, OperationResult<GetTransactionByIdQueryModel>>
{
    readonly ITransactionDomainRepository domainRepository;
    readonly IMediator mediator;

    public GetTransactionByIdQueryHandler(ITransactionDomainRepository domainRepository, IMediator mediator)
    {
        this.domainRepository = domainRepository;
        this.mediator = mediator;
    }

    public async Task<OperationResult<GetTransactionByIdQueryModel>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
   {
        var result = await this.mediator.Send(new GetExternalIntegrationResourceResultListByCategoryQuery((int)ExternalResourceCategory.Crypto), cancellationToken);

        var operationResult = new OperationResult<GetTransactionByIdQueryModel>();
        var transaction = await this.domainRepository.Find(request.Id, cancellationToken);

        if (transaction is null)
            return operationResult.ReturnWithErrorMessage(new NotFoundException($"Transaction with id {request.Id} was not found"));

        operationResult.RelatedObject = new GetTransactionByIdQueryModel
        {
            Id = transaction.Id,
            AssetId = transaction.AssetId,
            Name = transaction.Name,
            Quantity = transaction.Quantity,
            TotalPrice = transaction.TotalPrice,
            PricePerUnit = transaction.PricePerUnit,
            TransactionType = transaction.TransactionType,
            CreatedOn = transaction.CreatedOn,
            TransactionalProfit = 40 
            // TODO: Calculate the current transaction profit based on the current price of the asset
            // IMPORTANT-> This transactionalProfit should be calculate out of the investments scope. Write new endpoint in ExternalAssetIntegration Dashboard
            // GetInvestmentStatsById -> Because we will return and information for chart
        };

        return operationResult;
    }
}

public class GetTransactionByIdQueryModel : IMapFrom<DomainModels.Transaction>
{
    public int Id { get; set; }
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal PricePerUnit { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal TransactionalProfit { get; set; }
}
