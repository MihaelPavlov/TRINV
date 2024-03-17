using MediatR;
using System.ComponentModel.DataAnnotations;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Commands;

public class UpdateTransactionCommand : IRequest<OperationResult<string>>
{
    [Required]
    public int Id { get; set; }

    [Required]
    public decimal Quantity { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }

    [Required]
    public decimal PricePerUnit { get; set; }
}

internal class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, OperationResult<string>>
{
    readonly ITransactionDomainRepository domainRepository;

    public UpdateTransactionCommandHandler(ITransactionDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }
    public async Task<OperationResult<string>> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await this.domainRepository.Find(request.Id, cancellationToken);
        if (transaction is null)
            return new OperationResult<string>().ReturnWithErrorMessage(new NotFoundException($"{nameof(transaction)} with id {request.Id} was not found"));

        transaction
            .UpdateQuantity(request.Quantity)
            .UpdateTotalPrice(request.TotalPrice)
            .UpdatePricePerUnit(request.PricePerUnit);

        this.domainRepository.Update(transaction);
        await this.domainRepository.SaveChangesAsync(cancellationToken);

        return new OperationResult<string>(transaction.AssetId);
    }
}