namespace TRINV.Infrastructure.Entities;

public class Investment
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string AssetId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Quantity { get; set; } = string.Empty;

    public string TotalPrice { get; set; } = string.Empty;

    public string PricePerUnit { get; set; } = string.Empty;

    public int TransactionType { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool IsFromOutsideProvider { get; set; }
}
