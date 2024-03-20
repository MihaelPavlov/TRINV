using MediatR;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Commands;

public record DeleteTransactionCommand(int Id) : IRequest<OperationResult>;

internal class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, OperationResult>
{
    readonly ITransactionDomainRepository domainRepository;

    public DeleteTransactionCommandHandler(ITransactionDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await this.domainRepository.Find(request.Id, cancellationToken);

        if (transaction == null)
            return new OperationResult().ReturnWithErrorMessage(new NotFoundException($"{nameof(transaction)} with id {request.Id} was not found"));

        this.domainRepository.Delete(transaction);
        await this.domainRepository.SaveChangesAsync(cancellationToken);

        return new OperationResult();
    }
}
