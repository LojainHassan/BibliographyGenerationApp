using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.DTOs;

public class DepositOrderDto
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public string DepositorName { get; set; } = string.Empty;

    public DepositOrderStatus Status { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<DepositOrderToBookDto> Books { get; set; } = new();
}