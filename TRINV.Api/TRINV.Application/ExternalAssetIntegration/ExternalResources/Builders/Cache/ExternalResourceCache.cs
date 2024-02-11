namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Cache;

/// <summary>
/// Custom Implementation of <see cref="IStockCache<typeparamref name="T"/>"/>
/// </summary>
public class ExternalResourceCache<T> : IExternalResourceCache<T>
{
    /// <summary>
    ///  Dictionary that stores stock symbols as keys and corresponding Stock objects as values.
    /// </summary>
    readonly Dictionary<string, T> _keyValuePair;

    /// <summary>
    /// The constructor initializes the cache with a provided dictionary of stock symbols and their corresponding Stock objects.
    /// </summary>
    /// <param name="keyValuePair"></param>
    public ExternalResourceCache(Dictionary<string, T> keyValuePair)
    {
        _keyValuePair = keyValuePair;
    }

    /// <inheritdoc/>
    public T? this[string symbol]
    {
        get
        {
            if (_keyValuePair.TryGetValue(symbol, out var value))
                return value;

            return default;
        }
    }

    /// <inheritdoc/>
    public Dictionary<string, T> GetDictionary() => this._keyValuePair;


    /// <inheritdoc/>
    public string[] GetNames() => this._keyValuePair.Select(id => id.Key).ToArray();
}
