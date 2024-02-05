
using TRINV.Domain.Investments.Investment.Models;

namespace TRINV.Domain.Investments.Models;

public class Dashboard
{
    private readonly HashSet<Transaction> investments;

    public int NumberOfInvestments { get; private set; }

    public decimal TotalInvestmentAmount { get; private set; }

    public decimal RateOfReturn { get; private set; }

    public void AddInvestment()
            => NumberOfInvestments++;

    public void IncreaseTotalInvestmentAmount(decimal investmentAmount)
        => TotalInvestmentAmount += investmentAmount;

    //public void CalculateRateOfReturn()
    //{
    //    // Calculating ROI ( Return of Investments )
    //    decimal totalInitialInvestment = 0;
    //    decimal totalCurrentValue = 0;

    //    foreach (var investment in investments)
    //    {
    //        var coin = assetViews.FirstOrDefault(c => c.AssetId == investment.AssetId);

    //        if (coin != null)
    //        {
    //            // Calculate the current value of the investment
    //            totalCurrentValue += investment.Quantity * coin.CurrentPrice;

    //            // Calculate the initial investment
    //            totalInitialInvestment += investment.Quantity * investment.PurchasePricePerUnit;
    //        }
    //        // Handle the case where the corresponding coin data is not found
    //        else
    //        {
    //            //_logger.Log(LogEventLevel.Warning, $"Coin data not found for AssetId: {investment.AssetId}");
    //        }
    //    }

    //    RateOfReturn = (totalCurrentValue - totalInitialInvestment) / totalInitialInvestment * 100;
    //}
}
