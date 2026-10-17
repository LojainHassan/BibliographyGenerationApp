using BibliographyGenerationApp.Contracts;
using BibliographyGenerationApp.Data;
using BibliographyGenerationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliographyGenerationApp.Services;

public class DepositOrderToBookService : IDepositOrderBookService
{
    private readonly BibliographyDbContext _db;

    public DepositOrderToBookService(BibliographyDbContext db)
    {
        _db = db;
    }

    public async Task<List<DepositOrderBook>> GetByDepositOrderIdAsync(Guid depositOrderId)
    {
        return new List<DepositOrderBook>();
    }

    public Task<DepositOrderBook?> GetByIdAsync(Guid id)
    {
        return _db.DepositOrderToBooks
            .AsNoTracking()
            .FirstOrDefaultAsync(line => line.Id == id);
    }

    public async Task<DepositOrderBook> CreateAsync(DepositOrderBook line)
    {
        throw new InvalidOperationException($"Deposit order {line.DepositOrderId} was not found.");

    }

    public async Task<bool> UpdateAsync(DepositOrderBook line)
    {
        var existing = await _db.DepositOrderToBooks
            .FirstOrDefaultAsync(item => item.Id == line.Id);

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

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _db.DepositOrderToBooks
            .FirstOrDefaultAsync(line => line.Id == id);

        if (existing is null)
        {
            return false;
        }

        _db.DepositOrderToBooks.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}
