using TRINV.Domain.Investments.Transaction.Factories.Interfaces;
using TRINV.Domain.Investments.Transaction.Models;

namespace TRINV.Domain.Investments.Transaction.Factories;

internal class TransactionFactory : ITransactionFactory
{
    private int acountId = default!;
    private string assetId = default!;
    private string name = default!;
    private decimal quantity = default!;
    private decimal purchasePrice = default!;
    private decimal purchasePricePerUnit = default!;
    private bool isFromOutsideProvider = default!;
    private TransactionType transactionType = default!;

    public ITransactionFactory WithAccountId(int accountId)
    {
        this.acountId = accountId;
        return this;
    }

    public ITransactionFactory WithAssetId(string assetId)
    {
        this.assetId = assetId;
        return this;
    }

    public ITransactionFactory WithIsFromOutsideProvider(bool isFromOutsideProvider)
    {
        this.isFromOutsideProvider = isFromOutsideProvider;
        return this;
    }

    public ITransactionFactory WithName(string name)
    {
        this.name = name;
        return this;
    }

    public ITransactionFactory WithPurchasePrice(decimal purchasePrice)
    {
        this.purchasePrice = purchasePrice;
        return this;
    }

    public ITransactionFactory WithPurchasePricePerUnit(decimal purchasePricePerUnit)
    {
        this.purchasePricePerUnit = purchasePricePerUnit;
        return this;
    }

    public ITransactionFactory WithQuantity(decimal quantity)
    {
        this.quantity = quantity;
        return this;
    }

    public ITransactionFactory WithTransactionType(TransactionType transactionType)
    {
        this.transactionType = transactionType;
        return this;
    }

    public Models.Transaction Build()
    {
        return new Models.Transaction(
            this.acountId,
            this.assetId,
            this.name,
            this.quantity,
            this.purchasePrice,
            this.purchasePricePerUnit,
            this.transactionType,
            DateTime.UtcNow,
            this.isFromOutsideProvider);
    }
}
