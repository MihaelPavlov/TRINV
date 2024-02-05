using TRINV.Domain.Common;

namespace TRINV.Domain.Investments.Investment.Models
{
    public class Transaction : Entity<int> , IAggregateRoot
    {
        internal Transaction(
            int userId,
            string assetId,
            string name,
            decimal quantity,
            decimal purchasePrice,
            decimal purchasePricePerUnit,
            InvestmentType investmentType,
            DateTime createdOn,
            bool isFromOutsideProvider)
        {


            AccountId = userId;
            AssetId = assetId;
            Name = name;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            PurchasePricePerUnit = purchasePricePerUnit;
            InvestmentType = investmentType;
            CreatedOn = createdOn;
            IsFromOutsideProvider = isFromOutsideProvider;
        }

        public int AccountId { get; private set; }

        public string AssetId { get; private set; }

        public string Name { get; private set; }

        public decimal Quantity { get; private set; }

        public decimal PurchasePrice { get; private set; }

        public decimal PurchasePricePerUnit { get; private set; }

        public InvestmentType InvestmentType { get; private set; }

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
}

public enum InvestmentType
{
    crypto = 0,
    stock = 1,
}
