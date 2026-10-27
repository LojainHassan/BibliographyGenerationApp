namespace BibliographyGenerationApp.DTOs.DeweyClassification
{
    public class CreateDeweyClassificationDto
    {

        public string NameAr { get; set; } = default!;
        public string NameEn { get; set; } = default!;
        public string Code { get; set; } = default!;
        public Guid? ParentId { get; set; }
    }
}
