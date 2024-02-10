using System.Text.Json;
using System.Text.Json.Serialization;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders;

public class CoinCapIntegrationResourceBuilder : IExternalIntegrationResourceBuilder
{
    public int Id => ExternalIntegrationResource.Coincap.Id;
    public ExternalResourceCategory Category => ExternalIntegrationResource.Coincap.Category;

    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> Build(CancellationToken cancellationToken)
    {
        var operationResult = new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>();
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync("https://api.coincap.io/v2/assets", cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var parsed = JsonDocument.Parse(content);
        var result = parsed.Deserialize<DigitalCurrencyResult>();

        if (result is null)
            return operationResult.ReturnWithErrorMessage(new BadRequestException());

        operationResult.RelatedObject = result.Data.Select(x => new ExternalIntegrationResourceResultModel()
        {
            AssetId = x.Symbol,
            Name = x.Name,
            Price = decimal.Parse(x.PriceUsd)
        });

        return operationResult;
    }
}

public class GetDigitalCurrencyModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("rank")]
    public string Rank { get; set; } = string.Empty;

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("supply")]
    public string? Supply { get; set; }

    [JsonPropertyName("maxSupply")]
    public string MaxSupply { get; set; } = string.Empty;

    [JsonPropertyName("marketCapUsd")]
    public string MarketCapUsd { get; set; } = string.Empty;

    [JsonPropertyName("volumeUsd24Hr")]
    public string VolumeUsd24Hr { get; set; } = string.Empty;

    [JsonPropertyName("priceUsd")]
    public string PriceUsd { get; set; } = string.Empty;

    [JsonPropertyName("changePercent24Hr")]
    public string ChangePercent24Hr { get; set; } = string.Empty;
}

internal class DigitalCurrencyResult
{
    [JsonPropertyName("data")]
    public List<GetDigitalCurrencyModel> Data { get; set; } = new();
}

