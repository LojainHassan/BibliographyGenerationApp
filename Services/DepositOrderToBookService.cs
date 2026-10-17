using BibliographyGenerationApp.Contracts;
using BibliographyGenerationApp.Data;
using BibliographyGenerationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliographyGenerationApp.Services;

public class DepositOrderToBookService : IDepositOrderToBookService
{
    private readonly BibliographyDbContext _db;

    public DepositOrderToBookService(BibliographyDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<DepositOrderToBook>> GetByDepositOrderIdAsync(int depositOrderId, CancellationToken cancellationToken = default)
    {
        return await _db.DepositOrderToBooks
            .AsNoTracking()
            .Where(line => line.DepositOrderId == depositOrderId)
            .OrderBy(line => line.Title)
            .ToListAsync(cancellationToken);
    }

    public Task<DepositOrderToBook?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _db.DepositOrderToBooks
            .AsNoTracking()
            .FirstOrDefaultAsync(line => line.Id == id, cancellationToken);
    }

    public async Task<DepositOrderToBook> CreateAsync(DepositOrderToBook line, CancellationToken cancellationToken = default)
    {
        var orderExists = await _db.DepositOrders
            .AnyAsync(order => order.Id == line.DepositOrderId, cancellationToken);

        if (!orderExists)
        {
            throw new InvalidOperationException($"Deposit order {line.DepositOrderId} was not found.");
        }

        _db.DepositOrderToBooks.Add(line);
        await _db.SaveChangesAsync(cancellationToken);
        return line;
    }

    public async Task<bool> UpdateAsync(DepositOrderToBook line, CancellationToken cancellationToken = default)
    {
        var existing = await _db.DepositOrderToBooks
            .FirstOrDefaultAsync(item => item.Id == line.Id, cancellationToken);

        if (existing is null)
        {
            return false;
        }

        existing.DepositOrderId = line.DepositOrderId;
        existing.Title = line.Title;
        existing.Author = line.Author;
        existing.Isbn = line.Isbn;
        existing.Publisher = line.Publisher;
        existing.PublicationYear = line.PublicationYear;
        existing.Quantity = line.Quantity;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var existing = await _db.DepositOrderToBooks
            .FirstOrDefaultAsync(line => line.Id == id, cancellationToken);

        if (existing is null)
        {
            return false;
        }

        _db.DepositOrderToBooks.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
