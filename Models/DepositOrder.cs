using System.ComponentModel.DataAnnotations.Schema;

namespace BibliographyGenerationApp.Models;

public class DepositOrder:RootBaseModel
{
   
    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public string DepositorName { get; set; } = string.Empty;

    public DepositOrderStatus Status { get; set; }

    public string? Notes { get; set; }
    public int Year { get; set; }
    public string Subject { get; set; } = default!;

    public string DeweyNumber { get; set; } = default!;
    public ICollection<DepositOrderBook> Books { get; set; } = new List<DepositOrderBook>();

    [ForeignKey("DeweyClassificationId")]
    public Guid DeweyClassificationId { get; set; }
    [ForeignKey("DeweyClassificationId")]
    public DeweyClassificationInfo DeweyClassificationInfo { get; set; }
}
