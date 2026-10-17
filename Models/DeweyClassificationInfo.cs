namespace BibliographyGenerationApp.Models;

public class DeweyClassificationInfo:RootBaseModel
{
    public string NameAr { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string Code { get; set; } = default!;
    public ICollection<DepositOrder> DepositOrders { get; set; } = new List<DepositOrder>();

}
