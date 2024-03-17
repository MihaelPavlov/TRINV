using TRINV.Domain.Common;
using TRINV.Domain.Common.Enums;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

public class Investment : Entity<int>, IAggregateRoot
{
    public int AccountId { get; private set; }

    public string AssetId { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public decimal Quantity { get; private set; }

    public decimal TotalPrice { get; private set; }

    public decimal PricePerUnit { get; private set; }

    public TransactionType TransactionType { get; private set; }

    public DateTime CreatedOn { get; private set; }

    public bool IsFromOutsideProvider { get; private set; }

}
