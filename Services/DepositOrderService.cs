using BibliographyGenerationApp.Contracts;
using BibliographyGenerationApp.Data;
using BibliographyGenerationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliographyGenerationApp.Services;

public class DepositOrderService : IDepositOrderService
{
    private readonly BibliographyDbContext _db;

    public DepositOrderService(BibliographyDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<DepositOrder>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _db.DepositOrders
            .AsNoTracking()
            .Include(order => order.Books)
            .OrderByDescending(order => order.OrderDate)
            .ThenByDescending(order => order.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<DepositOrder?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _db.DepositOrders
            .AsNoTracking()
            .Include(order => order.Books)
            .FirstOrDefaultAsync(order => order.Id == id, cancellationToken);
    }

    public async Task<DepositOrder> CreateAsync(DepositOrder depositOrder, CancellationToken cancellationToken = default)
    {
        if (depositOrder.CreatedAt == default)
        {
            depositOrder.CreatedAt = DateTime.UtcNow;
        }

        _db.DepositOrders.Add(depositOrder);
        await _db.SaveChangesAsync(cancellationToken);
        return depositOrder;
    }

    public async Task<bool> UpdateAsync(DepositOrder depositOrder, CancellationToken cancellationToken = default)
    {
        var existing = await _db.DepositOrders
            .FirstOrDefaultAsync(order => order.Id == depositOrder.Id, cancellationToken);

        if (existing is null)
        {
            return false;
        }

        existing.OrderNumber = depositOrder.OrderNumber;
        existing.OrderDate = depositOrder.OrderDate;
        existing.DepositorName = depositOrder.DepositorName;
        existing.Status = depositOrder.Status;
        existing.Notes = depositOrder.Notes;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var existing = await _db.DepositOrders
            .FirstOrDefaultAsync(order => order.Id == id, cancellationToken);

        if (existing is null)
        {
            return false;
        }

        _db.DepositOrders.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
