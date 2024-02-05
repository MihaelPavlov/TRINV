namespace TRINV.Application.Investments.Services;

public interface IDashboardService
{
    Task<int> GetTotalInvestmentsByAccountAsync(int accountId);
    Task<decimal> GetTotalInvestmentByAccountAsync(int accountId);

    /// <summary>
    /// Use this method to calculate the Rate of Return(ROR) of account.
    /// </summary>
    /// <param name="account"></param>
    /// <returns>A method which return the Rate Of Return (ROR) of specified account.</returns>
    Task<decimal> GetRORByAccountAsync(int accountId);
}
