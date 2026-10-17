namespace BibliographyGenerationApp.Models;

public class DepositOrder
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public string DepositorName { get; set; } = string.Empty;

    public DepositOrderStatus Status { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<DepositOrderToBook> Books { get; set; } = new List<DepositOrderToBook>();
}
