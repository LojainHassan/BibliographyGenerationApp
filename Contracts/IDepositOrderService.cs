
using BibliographyGenerationApp.DTOs;

namespace BibliographyGenerationApp.Contracts;

public interface IDepositOrderService
{
    Task<List<DepositOrderDto>> GetAllAsync();

    Task<DepositOrderDto?> GetByIdAsync(Guid id);

    Task<DepositOrderDto> CreateAsync(CreateDepositOrderBook depositOrder);

    Task<bool> UpdateAsync(DepositOrderDto depositOrder);

    Task<bool> DeleteAsync(Guid id);
}
