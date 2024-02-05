namespace TRINV.Infrastructure.Entities;

public class Investment
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string AssetId { get; set; }

    public string Name { get; set; }

    public decimal Quantity { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal PurchasePricePerUnit { get; set; }

    public InvestmentType InvestmentType { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool IsFromOutsideProvider { get; set; }
}
