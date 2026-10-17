using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.Contracts;

public interface IDepositOrderBookService
{
    Task<List<DepositOrderBook>> GetByDepositOrderIdAsync(Guid depositOrderId);

    Task<DepositOrderBook?> GetByIdAsync(Guid id);

    Task<DepositOrderBook> CreateAsync(DepositOrderBook line);

    Task<bool> UpdateAsync(DepositOrderBook line);

    Task<bool> DeleteAsync(Guid id);
}
