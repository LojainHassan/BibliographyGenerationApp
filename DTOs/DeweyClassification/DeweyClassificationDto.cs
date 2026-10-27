using BibliographyGenerationApp.DTOs.RootDto;
using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.DTOs.DeweyClassification;

public class DeweyClassificationDto:RootDTO
{
    public string NameAr { get; set; } = default!;
    public string NameEn { get; set; } = default!;
    public string Code { get; set; } = default!;
    public Guid? ParentId { get; set; }
}
