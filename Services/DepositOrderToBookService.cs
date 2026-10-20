
using BibliographyGenerationApp.Contracts;
using BibliographyGenerationApp.Data;
using BibliographyGenerationApp.DTOs;
using BibliographyGenerationApp.Mappers;
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
        var line = await _db.DepositOrderToBooks
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

        var orderExists = await _db.DepositOrders
            .AnyAsync(
                order => order.Id == dto.DepositOrderId,
                cancellationToken);

        if (!orderExists)
        {
            throw new InvalidOperationException(
                $"Deposit order {dto.DepositOrderId} was not found.");
        }

        existing.DepositOrderId = dto.DepositOrderId;
        existing.Title = dto.Title;
        existing.Author = dto.Author;
        existing.Isbn = dto.Isbn;
        existing.Publisher = dto.Publisher;
        existing.PublicationYear = dto.PublicationYear;
        existing.Quantity = dto.Quantity;

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
