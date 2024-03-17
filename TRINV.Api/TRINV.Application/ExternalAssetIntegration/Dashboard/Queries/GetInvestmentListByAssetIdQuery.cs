using MediatR;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Queries;
using TRINV.Application.ExternalAssetIntegration.Repositories;
using TRINV.Domain.Common.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.Dashboard.Queries;

public record GetInvestmentListByAssetIdQuery(string AssetId) : IRequest<OperationResult<IEnumerable<GetInvestmentListByAssetIdQueryModel>>>;

internal class GetInvestmentListByAssetIdQueryHandler : IRequestHandler<GetInvestmentListByAssetIdQuery, OperationResult<IEnumerable<GetInvestmentListByAssetIdQueryModel>>>
{
    readonly IMediator mediator;
    readonly IDashboardQueryRepository queryRepository;

    public GetInvestmentListByAssetIdQueryHandler(IMediator mediator, IDashboardQueryRepository queryRepository)
    {
        this.mediator = mediator;
        this.queryRepository = queryRepository;
    }

    public async Task<OperationResult<IEnumerable<GetInvestmentListByAssetIdQueryModel>>> Handle(GetInvestmentListByAssetIdQuery request, CancellationToken cancellationToken)
    {
        Random r = new Random();

        var result = await this.mediator.Send(new GetExternalIntegrationResourceResultListByCategoryQuery((int)ExternalResourceCategory.Crypto), cancellationToken);

        if (result is null || result.RelatedObject is null || !result.Success)
        {
            return new OperationResult<IEnumerable<GetInvestmentListByAssetIdQueryModel>>().ReturnWithErrorMessage(new BadRequestException());
        }

        var investments = await this.queryRepository.FindAllByAssetId(request.AssetId,
            x => x.Select(transaction => new GetInvestmentListByAssetIdQueryModel
            {
                Id = transaction.Id,
                AssetId = transaction.AssetId,
                Name = transaction.Name,
                Quantity = transaction.Quantity,
                TotalPrice = transaction.TotalPrice,
                PricePerUnit = transaction.PricePerUnit,
                TransactionType = transaction.TransactionType,

            }), cancellationToken);

        foreach (var investment in investments)
        {
            investment.TransactionProfit = Math.Round((investment.Quantity * result.RelatedObject.Where(a => a.AssetId == investment.AssetId).FirstOrDefault()!.Price) - investment.TotalPrice, 2);
            investment.TransactionProfitPercents = Math.Round(((investment.Quantity * result.RelatedObject.Where(a => a.AssetId == investment.AssetId).FirstOrDefault()!.Price) - investment.TotalPrice) / investment.TotalPrice * 100, 2);
        }
        return new OperationResult<IEnumerable<GetInvestmentListByAssetIdQueryModel>>(investments);
    }
}

public class GetInvestmentListByAssetIdQueryModel
{
    public int Id { get; set; }
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal PricePerUnit { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal TransactionProfit { get; set; }
    public decimal TransactionProfitPercents { get; set; }
}
