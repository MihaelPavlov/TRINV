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

public class FinancialModelingPrepIntegrationResourceBuilder : IExternalIntegrationResourceBuilder
{
    public int Id => ExternalIntegrationResource.FinancialModelingPrep.Id;
    public ExternalResourceCategory Category => ExternalIntegrationResource.FinancialModelingPrep.Category;

    const string CACHE_KEY = CacheConstants.KEY_FINANCIAL_MODELELING_PERP;

    readonly IMemoryCache cache;
    readonly ILoggerService loggerService;

    public FinancialModelingPrepIntegrationResourceBuilder(IMemoryCache cache, ILoggerService loggerService)
    {
        this.cache = cache;
        this.loggerService = loggerService;
    }

    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> Build(CancellationToken cancellationToken)
    {
        var operationResult = new OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>();
        if (this.cache.TryGetValue(CACHE_KEY, out ExternalResourceCache<ExternalIntegrationResourceResultModel>? result) && result is not null)
        {
            operationResult.RelatedObject = result.GetDictionary().Values;
            return operationResult;
        }

        using (var entry = this.cache.CreateEntry(CACHE_KEY))
        {
            entry.SetSlidingExpiration(TimeSpan.FromMinutes(30));
            var stockOperationResult = await this.GetStocks(cancellationToken);

            if (!stockOperationResult.Success || stockOperationResult.RelatedObject is null)
                return operationResult.ReturnWithErrorMessage(new InfrastructureException("Financial Modeling Prep currently is not working"));

            entry.Value = stockOperationResult.RelatedObject;
            operationResult.RelatedObject = stockOperationResult.RelatedObject.GetDictionary().Values;

            return operationResult;
        }
    }

    private async Task<OperationResult<IExternalResourceCache<ExternalIntegrationResourceResultModel>>> GetStocks(CancellationToken cancellationToken)
    {
        var operatioResult = new OperationResult<IExternalResourceCache<ExternalIntegrationResourceResultModel>>();

        var httpClient = new HttpClient();
        httpClient.Timeout = new TimeSpan(0, 5, 0);
        httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");

        var response = await httpClient.GetAsync("https://financialmodelingprep.com/api/v3/stock/list?apikey=H4p7pqemFJGzwh4b1gOKKMqXxxsd6m0s", cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        int pageSize = 10000;
        int pageNumber = 1;
        var splittedRecords = content.Split("},");
        int stockCount = splittedRecords.Count();
        Dictionary<string, ExternalIntegrationResourceResultModel> allStocks = new Dictionary<string, ExternalIntegrationResourceResultModel>();

        while (stockCount != 0)
        {
            try
            {
                if (stockCount < pageSize)
                {
                    pageSize = stockCount;
                }
                var page = splittedRecords
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToArray();

                var buildString = string.Empty;
                if (pageNumber != 1)
                {
                    buildString += "[";
                }
                buildString += string.Join("},", page);
                buildString += "}]";

                var parsed = JsonDocument.Parse(buildString);
                var result = parsed.Deserialize<Stock[]>();
                if (result is not null)
                {
                    stockCount -= pageSize;
                    allStocks = allStocks.Union(result
                        .Select(x => new ExternalIntegrationResourceResultModel { AssetId = x.Symbol, Price = x.Price ?? 0, Name = x.Name })
                        .ToDictionary(x => x.AssetId, x => x)).GroupBy(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.First().Value);
                    pageNumber++;
                }
            }
            catch (Exception)
            {
                this.loggerService.Log(LogEventLevel.Error, "The process of getting the stocks from the external api failled.");
                return operatioResult.ReturnWithErrorMessage(new InfrastructureException("The process of parsing the stock failled."));
            }
        }

        operatioResult.RelatedObject = new ExternalResourceCache<ExternalIntegrationResourceResultModel>(allStocks);

        return operatioResult;
    }
}

public class Stock
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonPropertyName("exchange")]
    public string Exchange { get; set; } = string.Empty;

    [JsonPropertyName("exchangeShortName")]
    public string ExchangeShortName { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}
