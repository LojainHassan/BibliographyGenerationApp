using BibliographyGenerationApp.DTOs.RootDto;
using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.DTOs;

public class DepositOrderDto: RootDTO
{

    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public string DepositorName { get; set; } = string.Empty;

    public DepositOrderStatus Status { get; set; }

    public string? Notes { get; set; }


    public List<DepositOrderBookDto> Books { get; set; } = new();
}