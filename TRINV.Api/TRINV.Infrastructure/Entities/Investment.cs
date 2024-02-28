using TRINV.Domain.Investments.Transaction.Models;

namespace TRINV.Infrastructure.Entities;

public class Investment
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string AssetId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal PurchasePricePerUnit { get; set; }

    public TransactionType TransactionType { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool IsFromOutsideProvider { get; set; }
}
