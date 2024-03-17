using TRINV.Domain.Common;
using TRINV.Domain.Common.Enums;

namespace TRINV.Domain.Investments.Transaction.Models;

public class Transaction : Entity<int>, IAggregateRoot
{
    internal Transaction(
        int accountId,
        string assetId,
        string name,
        decimal quantity,
        decimal totalPrice,
        decimal pricePerUnit,
        TransactionType transactionType,
        DateTime createdOn,
        bool isFromOutsideProvider)
    {
        AccountId = accountId;
        AssetId = assetId;
        Name = name;
        Quantity = quantity;
        TotalPrice = totalPrice;
        PricePerUnit = pricePerUnit;
        TransactionType = transactionType;
        CreatedOn = createdOn;
        IsFromOutsideProvider = isFromOutsideProvider;
    }

    public int AccountId { get; private set; }

    public string AssetId { get; private set; }

    public string Name { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal TotalPrice { get; private set; }

    public decimal PricePerUnit { get; private set; }

    public TransactionType TransactionType { get; private set; }

    public DateTime CreatedOn { get; private set; }

    public bool IsFromOutsideProvider { get; private set; }

    public Transaction UpdateQuantity(decimal quantity)
    {
        // validate quantity
        Quantity = quantity;

        return this;
    }

    public Transaction UpdateTotalPrice(decimal totalPrice)
    {
        // validate purchase price
        TotalPrice = totalPrice;
        return this;
    }

    public Transaction UpdatePricePerUnit(decimal pricePerUnit)
    {
        // validate purchase price
        PricePerUnit = pricePerUnit;
        return this;
    }
}
