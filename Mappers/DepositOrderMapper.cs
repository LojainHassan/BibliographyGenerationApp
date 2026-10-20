
using BibliographyGenerationApp.DTOs;
using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.Mappers;

public static class DepositOrderMapper
{
    // تحويل Model إلى DTO
    public static DepositOrderDto ToDto(DepositOrder order)
    {
        return new DepositOrderDto
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            OrderDate = order.OrderDate,
            DepositorName = order.DepositorName,
            Status = order.Status,
            Notes = order.Notes,
            CreatedAt = order.CreatedAt,

            Books = order.Books
                .Select(DepositOrderToBookMapper.ToDto)
                .ToList()
        };
    }

    // تحويل DTO إلى Model
    public static DepositOrder ToModel(DepositOrderDto dto)
    {
        return new DepositOrder
        {
            Id = dto.Id,
            OrderNumber = dto.OrderNumber,
            OrderDate = dto.OrderDate,
            DepositorName = dto.DepositorName,
            Status = dto.Status,
            Notes = dto.Notes,
            CreatedAt = dto.CreatedAt,

            Books = dto.Books
                .Select(DepositOrderToBookMapper.ToModel)
                .ToList()
        };
    }
}
