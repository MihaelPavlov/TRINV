using MediatR;
using System.ComponentModel.DataAnnotations;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.Investments.Transaction.Factories.Interfaces;
using TRINV.Domain.Investments.Transaction.Models;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Commands;

public class UpdateTransactionCommand : IRequest<OperationResult>
{
    [Required]
    public int Id { get; set; }

    [Required]
    public decimal Quantity { get; set; }

    [Required]
    public decimal PurchasePrice { get; set; }

    [Required]
    public decimal PurchasePricePerUnit { get; set; }
}

internal class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, OperationResult>
{
    readonly ITransactionDomainRepository domainRepository;

    public UpdateTransactionCommandHandler(ITransactionDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }
    public async Task<OperationResult> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await this.domainRepository.Find(request.Id, cancellationToken);
        if (transaction is null)
            return new OperationResult().ReturnWithErrorMessage(new NotFoundException($"{nameof(transaction)} with id {request.Id} was not found"));

        transaction
            .UpdateQuantity(request.Quantity)
            .UpdatePurchasePrice(request.PurchasePrice)
            .UpdatePurchasePricePerUnit(request.PurchasePricePerUnit);

        this.domainRepository.Update(transaction);
        await this.domainRepository.SaveChangesAsync(cancellationToken);

        return new OperationResult();
    }
}