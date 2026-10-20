
using BibliographyGenerationApp.DTOs;
using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.Mappers;

public static class DepositOrderToBookMapper
{
    // تحويل Model إلى DTO
    public static DepositOrderToBookDto ToDto(DepositOrderToBook book)
    {
        return new DepositOrderToBookDto
        {
            Id = book.Id,
            DepositOrderId = book.DepositOrderId,
            Title = book.Title,
            Author = book.Author,
            Isbn = book.Isbn,
            Publisher = book.Publisher,
            PublicationYear = book.PublicationYear,
            Quantity = book.Quantity
        };
    }

    // تحويل DTO إلى Model
    public static DepositOrderToBook ToModel(DepositOrderToBookDto dto)
    {
        return new DepositOrderToBook
        {
            Id = dto.Id,
            DepositOrderId = dto.DepositOrderId,
            Title = dto.Title,
            Author = dto.Author,
            Isbn = dto.Isbn,
            Publisher = dto.Publisher,
            PublicationYear = dto.PublicationYear,
            Quantity = dto.Quantity
        };
    }
}
