namespace TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Cache;

/// <summary>
/// The interface serve as a cache for storing and retrieving external resource information. 
/// </summary>
public interface IExternalResourceCache<T>
{
    /// <summary>
    /// The indexer (this[string symbol]) allows for quick retrieval of a external resource object based on its symbol.
    /// </summary>
    /// <param name="symbol">Symbol representing the key of the external resource.</param>
    /// <returns>A <see cref="T"/></returns>
    T? this[string symbol] { get; }

    /// <summary>
    /// Use this method to get all external resource names.
    /// </summary>
    /// <returns>Collection of all external resource names.</returns>
    string[] GetNames();

    /// <summary>
    /// This method specifically returns a key-id pair represents a external resource symbol and its corresponding object.
    /// </summary>
    /// <returns>A key-id pair</returns>
    Dictionary<string, T> GetDictionary();
}
