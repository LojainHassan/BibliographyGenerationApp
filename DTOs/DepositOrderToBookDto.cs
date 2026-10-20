namespace BibliographyGenerationApp.DTOs;

public class DepositOrderToBookDto
{
    public int Id { get; set; }

    public int DepositOrderId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Author { get; set; }

    public string? Isbn { get; set; }

    public string? Publisher { get; set; }

    public int? PublicationYear { get; set; }

    public int Quantity { get; set; }
}



