using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.DTOs
{
    public class CreateUpdateBookDto
    {

        public string OrderNumber { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public string DepositorName { get; set; } = string.Empty;

        public DepositOrderStatus Status { get; set; }

        public string? Notes { get; set; }

    }
}
