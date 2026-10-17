using BibliographyGenerationApp.Models;

namespace BibliographyGenerationApp.Contracts;

public interface IDepositOrderService
{
    Task<IReadOnlyList<DepositOrder>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<DepositOrder?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<DepositOrder> CreateAsync(DepositOrder depositOrder, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(DepositOrder depositOrder, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
