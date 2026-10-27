using BibliographyGenerationApp.DTOs.DeweyClassification;

namespace BibliographyGenerationApp.Contracts.DeweyClassification;

public interface IDeweyClassificationService
{
    Task<DeweyClassificationDto> CreateDeweyClassification(CreateDeweyClassificationDto deweyClassification);

}
