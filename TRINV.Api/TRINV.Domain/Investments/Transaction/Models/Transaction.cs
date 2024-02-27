using TRINV.Domain.Common;

namespace TRINV.Domain.Investments.Transaction.Models;

public class Transaction : Entity<int>, IAggregateRoot
{
    internal Transaction(
        int accountId,
        string assetId,
        string name,
        decimal quantity,
        decimal purchasePrice,
        decimal purchasePricePerUnit,
        TransactionType transactionType,
        DateTime createdOn,
        bool isFromOutsideProvider)
    {
        AccountId = accountId;
        AssetId = assetId;
        Name = name;
        Quantity = quantity;
        PurchasePrice = purchasePrice;
        PurchasePricePerUnit = purchasePricePerUnit;
        TransactionType = transactionType;
        CreatedOn = createdOn;
        IsFromOutsideProvider = isFromOutsideProvider;
    }

    public int AccountId { get; private set; }

    public string AssetId { get; private set; }

    public string Name { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal PurchasePrice { get; private set; }

    public decimal PurchasePricePerUnit { get; private set; }

    public TransactionType TransactionType { get; private set; }

    public DateTime CreatedOn { get; private set; }

    public bool IsFromOutsideProvider { get; private set; }

    public Transaction UpdateQuantity(decimal quantity)
    {
        // validate quantity
        Quantity = quantity;

        return this;
    }

    public Transaction UpdatePurchasePrice(decimal purchasePrice)
    {
        // validate purchase price
        PurchasePrice = purchasePrice;
        return this;
    }

    public Transaction UpdatePurchasePricePerUnit(decimal purchasePricePerUnit)
    {
        // validate purchase price
        PurchasePricePerUnit = purchasePricePerUnit;
        return this;
    }
}

public enum TransactionType
{
    Bought = 0,
    Sold = 1,
}
