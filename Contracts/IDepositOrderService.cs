using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.Contracts;

public interface IDepositOrderService
{
    Task<List<DepositOrder>> GetAllAsync();

    Task<DepositOrder?> GetByIdAsync(Guid id);

    Task<DepositOrder> CreateAsync(DepositOrder depositOrder);

    Task<bool> UpdateAsync(DepositOrder depositOrder);

    Task<bool> DeleteAsync(Guid id);
}
