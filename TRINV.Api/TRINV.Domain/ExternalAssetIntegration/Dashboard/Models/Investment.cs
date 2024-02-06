﻿using TRINV.Domain.Common;

namespace TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

public class Investment : Entity<int>, IAggregateRoot
{
    internal Investment(
        int accountId,
        string assetId,
        decimal quantity,
        decimal purchasePrice,
        decimal purchasePricePerUnit)
    {
        this.AccountId = accountId;
        this.AssetId = assetId;
        this.Quantity = quantity;
        this.PurchasePrice = purchasePrice;
        this.PurchasePricePerUnit = purchasePricePerUnit;
    }

    private Investment(string assetId, int accountId,
        decimal quantity,
        decimal purchasePrice,
        decimal purchasePricePerUnit)
    {
        this.AccountId = accountId;
        this.AssetId = assetId;
        this.Quantity = quantity;
        this.PurchasePrice = purchasePrice;
        this.PurchasePricePerUnit = purchasePricePerUnit;
    }

    public int AccountId { get; private set; }

    public string AssetId { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal PurchasePrice { get; private set; }

    public decimal PurchasePricePerUnit { get; private set; }
}
