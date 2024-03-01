using MediatR;
using TRINV.Domain.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Queries;

public record GetAssetListQuery(string SearchExpression) : IRequest<OperationResult<IEnumerable<GetAssetListQueryModel>>>;

internal class GetAssetListQueryHandler : IRequestHandler<GetAssetListQuery, OperationResult<IEnumerable<GetAssetListQueryModel>>>
{
    readonly ITransactionDomainRepository domainRepository;

    public GetAssetListQueryHandler(ITransactionDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task<OperationResult<IEnumerable<GetAssetListQueryModel>>> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
    {
        var res = await this.domainRepository.GetAllByAccount(1, cancellationToken);

        //TODO: Think of another way to do it. We are materializing the data to early. But at the moment don't see another option.
        // Think about maybe a service with nessacary methods 
        var result = res.Where(x => x.AssetId.Contains(request.SearchExpression)).GroupBy(x => new { AssetId = x.AssetId, Name = x.Name }).Select(x => new GetAssetListQueryModel
        {
            AssetId = x.Key.AssetId,
            Name = x.Key.Name,
            TotalQuantity = x.Sum(x => x.Quantity),
            TotalPrice = x.Sum(x => x.PurchasePrice)
        }).ToList();

        return new OperationResult<IEnumerable<GetAssetListQueryModel>>(result);
    }
}

public class GetAssetListQueryModel
{
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal TotalQuantity { get; set; }
    public decimal TotalPrice { get; set; }
}
