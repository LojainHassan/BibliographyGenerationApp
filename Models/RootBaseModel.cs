using System.ComponentModel.DataAnnotations;

namespace BibliographyGenerationApp.Models
{
    public class RootBaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
