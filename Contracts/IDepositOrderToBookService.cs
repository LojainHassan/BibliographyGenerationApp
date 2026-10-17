using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.Contracts;

public interface IDepositOrderToBookService
{
    Task<IReadOnlyList<DepositOrderToBook>> GetByDepositOrderIdAsync(int depositOrderId, CancellationToken cancellationToken = default);

    Task<DepositOrderToBook?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<DepositOrderToBook> CreateAsync(DepositOrderToBook line, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(DepositOrderToBook line, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
