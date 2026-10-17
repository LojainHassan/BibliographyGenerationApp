namespace BibliographyGenerationApp.Models;

public class DepositOrder:RootBaseModel
{
   
    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public string DepositorName { get; set; } = string.Empty;

    public DepositOrderStatus Status { get; set; }

    public string? Notes { get; set; }

    
    public int Year { get; set; }
    public string Subject { get; set; }

    public string DeweyNumber { get; set; }
    public ICollection<DepositOrderToBook> Books { get; set; } = new List<DepositOrderToBook>();
}
