using TRINV.Domain.Common.Enums;
using TRINV.Domain.Investments.Transaction.Factories.Interfaces;

namespace TRINV.Domain.Investments.Transaction.Factories;

internal class TransactionFactory : ITransactionFactory
{
    private int acountId = default!;
    private string assetId = default!;
    private string name = default!;
    private decimal quantity = default!;
    private decimal totalPrice = default!;
    private decimal pricePerUnit = default!;
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

    public ITransactionFactory WithTotalPrice(decimal totalPrice)
    {
        this.totalPrice = totalPrice;
        return this;
    }

    public ITransactionFactory WithPricePerUnit(decimal pricePerUnit)
    {
        this.pricePerUnit = pricePerUnit;
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
            this.totalPrice,
            this.pricePerUnit,
            this.transactionType,
            DateTime.UtcNow,
            this.isFromOutsideProvider);
    }
}
