using MediatR;
using TRINV.Application.Investments.Transaction.Repositories;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.Investments.Transaction.Queries;

public record GetAssetListQuery(string? SearchExpression) : IRequest<OperationResult<IEnumerable<GetAssetListQueryModel>>>;

internal class GetAssetListQueryHandler : IRequestHandler<GetAssetListQuery, OperationResult<IEnumerable<GetAssetListQueryModel>>>
{
    readonly ITransactioQueryRepository queryRepository;

    public GetAssetListQueryHandler(ITransactioQueryRepository queryRepository)
    {
        this.queryRepository = queryRepository;
    }

    public async Task<OperationResult<IEnumerable<GetAssetListQueryModel>>> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
    {
        var result = await this.queryRepository.GetAllAssets(request.SearchExpression ?? string.Empty, cancellationToken);

        var groupedAssets = result.GroupBy(x => new { AssetId = x.AssetId, Name = x.Name }).Select(x => new GetAssetListQueryModel
        {
            AssetId = x.Key.AssetId,
            Name = x.Key.Name,
            TotalQuantity = x.Sum(x => x.Quantity),
            TotalBalance = x.Sum(x => x.TotalPrice)
        }).ToList();

        return new OperationResult<IEnumerable<GetAssetListQueryModel>>(groupedAssets);
    }
}

public class GetAssetListQueryModel
{
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal TotalQuantity { get; set; }
    public decimal TotalBalance { get; set; }
}
