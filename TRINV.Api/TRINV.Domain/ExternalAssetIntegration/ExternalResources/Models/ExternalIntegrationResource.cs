using TRINV.Domain.Common.Helpers;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Enums;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

public class ExternalIntegrationResource : EnumerationHelper
{
    public static ExternalIntegrationResource Coincap = new(1, "Coincap", ExternalResourceCategory.Crpyto);
    public static ExternalIntegrationResource Binance = new(2, "Binance", ExternalResourceCategory.Crpyto);
    public static ExternalIntegrationResource FinancialModelingPrep = new(3, "FinancialModelingPrep", ExternalResourceCategory.Stock);

    public ExternalIntegrationResource(int id, string name, ExternalResourceCategory category) 
        : base(id, name, category)
    {
    }

    public static string GetNameById(int id)
    {
        switch (id)
        {
            case 1:
                return Coincap.Name;
            case 2:
                return Binance.Name;
            case 3:
                return FinancialModelingPrep.Name;
            default:
                throw new ArgumentException($"There is no external resource with id {id}");
        }
    }
}
