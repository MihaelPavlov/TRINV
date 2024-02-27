using TRINV.Domain.Common;
using TRINV.Domain.Investments.Transaction.Models;

namespace TRINV.Domain.Investments.Transaction.Factories.Interfaces;

public interface ITransactionFactory : IFactory<Models.Transaction>
{
    ITransactionFactory WithAccountId(int accountId);
    ITransactionFactory WithAssetId(string assetId);
    ITransactionFactory WithName(string name);
    ITransactionFactory WithQuantity(decimal quantity);
    ITransactionFactory WithPurchasePrice(decimal purchasePrice);
    ITransactionFactory WithPurchasePricePerUnit(decimal purchasePricePerUnit);
    ITransactionFactory WithTransactionType(TransactionType transactionType);
    ITransactionFactory WithIsFromOutsideProvider(bool isFromOutsideProvider);
}
