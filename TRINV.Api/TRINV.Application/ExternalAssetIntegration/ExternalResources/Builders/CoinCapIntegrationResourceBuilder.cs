using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Text.Json.Serialization;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Cache;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Shared.Business.Exceptions;
using TRINV.Shared.Business.Extension;
using TRINV.Shared.Business.Logger;
using TRINV.Shared.Business.Utilities;

namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders;

public class CoinCapIntegrationResourceBuilder : IExternalIntegrationResourceBuilder
{
    public int Id => ExternalIntegrationResource.Coincap.Id;
    public ExternalResourceCategory Category => ExternalIntegrationResource.Coincap.Category;

    const string CACHE_KEY = CacheConstants.KEY_COIN_CAP;

    readonly IMemoryCache _cache;
    readonly ILoggerService _loggerService;

    public CoinCapIntegrationResourceBuilder(IMemoryCache cache, ILoggerService loggerService)
    {
        this._cache = cache;
        _loggerService = loggerService;
    }

    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> Build(CancellationToken cancellationToken)
    {
        var operationResult = new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>();

        if (this._cache.TryGetValue(CACHE_KEY, out ExternalResourceCache<ExternalIntegrationResourceResultModel>? result) && result is not null)
        {
            operationResult.RelatedObject = result.GetDictionary().Values;
            return operationResult;
        }
        using (var entry = this._cache.CreateEntry(CACHE_KEY))
        {
            entry.SetSlidingExpiration(TimeSpan.FromMinutes(30));

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://api.coincap.io/v2/assets", cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var parsed = JsonDocument.Parse(content);
            var parsedResult = parsed.Deserialize<DigitalCurrencyResult>();

            if (parsedResult is null)
                return operationResult.ReturnWithErrorMessage(new BadRequestException());

            operationResult.RelatedObject = parsedResult.Data.Select(x => new ExternalIntegrationResourceResultModel()
            {
                AssetId = x.Symbol,
                Name = x.Name,
                Price = decimal.Parse(x.PriceUsd)
            });

            entry.Value = new ExternalResourceCache<ExternalIntegrationResourceResultModel>(operationResult.RelatedObject.ToDictionary(x => x.AssetId, x => x));
            return operationResult;
        }
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

