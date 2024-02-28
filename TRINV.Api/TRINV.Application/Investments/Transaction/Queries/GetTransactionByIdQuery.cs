﻿using MediatR;
using TRINV.Domain.Common.Mapping;
using DomainModels = TRINV.Domain.Investments.Transaction.Models;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;
using TRINV.Domain.Investments.Transaction.Models;

namespace TRINV.Application.Investments.Transaction.Queries;

public record GetTransactionByIdQuery(int Id) : IRequest<OperationResult<GetTransactionByIdQueryModel>>;

internal class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, OperationResult<GetTransactionByIdQueryModel>>
{
    readonly ITransactionDomainRepository domainRepository;

    public GetTransactionByIdQueryHandler(ITransactionDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult<GetTransactionByIdQueryModel>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
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
            PurchasePrice = transaction.PurchasePrice,
            PurchasePricePerUnit = transaction.PurchasePricePerUnit,
            TransactionType = transaction.TransactionType,
            CreatedOn = transaction.CreatedOn,
            TransactionalProfit = 40 // TODO: Calculate the current transaction profit based on the current price of the asset
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
    public decimal PurchasePrice { get; set; }
    public decimal PurchasePricePerUnit { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal TransactionalProfit { get; set; }
}