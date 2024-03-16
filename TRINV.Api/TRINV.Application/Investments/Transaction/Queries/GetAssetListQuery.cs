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

        return new OperationResult<IEnumerable<GetAssetListQueryModel>>(result);
    }
}

public class GetAssetListQueryModel
{
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal TotalQuantity { get; set; }
    public decimal TotalBalance { get; set; }
}
