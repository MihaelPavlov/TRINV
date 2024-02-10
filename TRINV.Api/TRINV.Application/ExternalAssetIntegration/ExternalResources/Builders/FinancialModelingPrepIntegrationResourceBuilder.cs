using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
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

    readonly IMemoryCache _cache;
    readonly ILoggerService _loggerService;

    public FinancialModelingPrepIntegrationResourceBuilder(IMemoryCache cache, ILoggerService loggerService)
    {
        this._cache = cache;
        this._loggerService = loggerService;
    }

    public async Task<OperationResult<IEnumerable<ExternalIntegrationResourceResultModel>>> IExternalIntegrationResourceBuilder.Build()
    {
        var cacheKey = CacheConstants.KEY_STOCK;

        if (this._cache.TryGetValue(cacheKey, out StockCache? result) && result is not null)
            return new OperationResult<IStockCache>(result);

        using (var entry = this._cache.CreateEntry(cacheKey))
        {
            entry.SetSlidingExpiration(TimeSpan.FromHours(10));
            var operationResult = await this.GetStocks(cancellationToken);

            if (!operationResult.Success)
                return operationResult;

            entry.Value = operationResult.RelatedObject;
            return operationResult;
        }
    }

    private async Task<OperationResult<IStockCache>> GetStocks(CancellationToken cancellationToken)
    {
        var operatioResult = new OperationResult<IStockCache>();

        var httpClient = new HttpClient();
        httpClient.Timeout = new TimeSpan(0, 5, 0);
        httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");

        var response = await httpClient.GetAsync("https://financialmodelingprep.com/api/v3/stock/list?apikey=H4p7pqemFJGzwh4b1gOKKMqXxxsd6m0s", cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        int pageSize = 10000;
        int pageNumber = 1;
        var splittedRecords = content.Split("},");
        int stockCount = splittedRecords.Count();
        Dictionary<string, Stock> allStocks = new Dictionary<string, Stock>();

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
                    allStocks = allStocks.Union(result.ToDictionary(x => x.Symbol, x => x)).GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.First().Value);
                    pageNumber++;
                }
            }
            catch (Exception ex)
            {
                this._loggerService.Log(LogEventLevel.Error, "The process of getting the stocks from the external api failled.");
                return operatioResult.ReturnWithErrorMessage(new InfrastructureException("The process of parsing the stock failled."));
            }
        }

        operatioResult.RelatedObject = new StockCache(allStocks);

        return operatioResult;
    }
}

public static class CacheConstants
{
    public const string KEY_STOCK = "Stocks_Key";
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

/// <summary>
/// Custom Implementation of <see cref="IStockCache"/>
/// </summary>
public class StockCache : IStockCache
{
    /// <summary>
    ///  Dictionary that stores stock symbols as keys and corresponding Stock objects as values.
    /// </summary>
    readonly Dictionary<string, Stock> _keyValuePair;

    /// <summary>
    /// The constructor initializes the cache with a provided dictionary of stock symbols and their corresponding Stock objects.
    /// </summary>
    /// <param name="keyValuePair"></param>
    public StockCache(Dictionary<string, Stock> keyValuePair)
    {
        _keyValuePair = keyValuePair;
    }

    /// <inheritdoc/>
    public Stock? this[string symbol]
    {
        get
        {
            if (_keyValuePair.TryGetValue(symbol, out var value))
                return value;

            return null;
        }
    }

    /// <inheritdoc/>
    public IEnumerable<Stock> GetAllByType(string type) => this._keyValuePair
        .Where(x => x.Value.Type == type)
        .Select(x => x.Value)
        .ToList();

    /// <inheritdoc/>
    public Dictionary<string, Stock> GetDictionary() => this._keyValuePair;


    /// <inheritdoc/>
    public string[] GetNames() => this._keyValuePair.Select(id => id.Value.Name).ToArray();
}


/// <summary>
/// The interface serve as a cache for storing and retrieving stock information. 
/// </summary>
public interface IStockCache
{
    /// <summary>
    /// The indexer (this[string symbol]) allows for quick retrieval of a Stock object based on its symbol.
    /// </summary>
    /// <param name="symbol">Symbol representing the key of the stock.</param>
    /// <returns>A <see cref="Stock"/></returns>
    Stock? this[string symbol] { get; }

    /// <summary>
    /// Use this method to get all stock names.
    /// </summary>
    /// <returns>Collection of all stock names.</returns>
    string[] GetNames();

    /// <summary>
    /// Use this method to get stock list with specific type.
    /// </summary>
    /// <returns>A stock list.</returns>
    IEnumerable<Stock> GetAllByType(string type);

    /// <summary>
    /// This method specifically returns a  key-id pair represents a stock symbol and its corresponding object.
    /// </summary>
    /// <returns>A key-id pair</returns>
    Dictionary<string, Stock> GetDictionary();

}
