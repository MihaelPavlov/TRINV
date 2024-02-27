﻿using MediatR;
using System.ComponentModel.DataAnnotations;
using TRINV.Domain.Investments.Transaction.Factories.Interfaces;
using TRINV.Domain.Investments.Transaction.Models;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Commands;

public class CreateTransactionCommand : IRequest<OperationResult>
{
    [Required]
    public string AssetId { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Quantity { get; set; }

    [Required]
    public decimal PurchasePrice { get; set; }

    [Required]
    public decimal PurchasePricePerUnit { get; set; }

    [Required]
    public TransactionType TransactionType { get; set; }

    public bool IsFromOutsideProvider { get; set; }
}

internal class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, OperationResult>
{
    readonly ITransactionFactory transactionFactory;
    readonly ITransactionDomainRepository domainRepository;

    public CreateTransactionCommandHandler(ITransactionFactory transactionFactory, ITransactionDomainRepository domainRepository)
    {
        this.transactionFactory = transactionFactory;
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transactionModel = this.transactionFactory
            .WithAccountId(1)
            .WithAssetId(request.AssetId)
            .WithIsFromOutsideProvider(request.IsFromOutsideProvider)
            .WithName(request.Name)
            .WithPurchasePrice(request.PurchasePrice)
            .WithPurchasePricePerUnit(request.PurchasePricePerUnit)
            .WithQuantity(request.Quantity)
            .WithTransactionType(request.TransactionType)
            .Build();

        await this.domainRepository.AddAsync(transactionModel, cancellationToken);
        await this.domainRepository.SaveChangesAsync(cancellationToken);

        return new OperationResult();
    }
}
