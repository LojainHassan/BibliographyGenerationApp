using BibliographyGenerationApp.DTOs;
using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.Contracts;

public interface IDepositOrderBookService
{
    Task<List<DepositOrderBookDto>> GetByDepositOrderIdAsync(Guid depositOrderId);

    Task<DepositOrderBookDto?> GetByIdAsync(Guid id);

    Task<DepositOrderBookDto> CreateAsync(CreateUpdateBookDto line);

    Task<bool> UpdateAsync(DepositOrderBookDto line);

    Task<bool> DeleteAsync(Guid id);
}
