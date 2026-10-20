
using AutoMapper;
using BibliographyGenerationApp.Contracts;
using BibliographyGenerationApp.Data;
using BibliographyGenerationApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BibliographyGenerationApp.Services;

public class DepositOrderService : IDepositOrderService
{
    private readonly BibliographyDbContext _db;
    private readonly IMapper _mapper;
    public DepositOrderService(BibliographyDbContext db,
        IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<DepositOrderDto>> GetAllAsync()
    {
        var allOrders = await _db.DepositOrders.ToListAsync();
        var allOrdersDto = _mapper.Map<List<DepositOrderDto>>(allOrders);
        return allOrdersDto;
    }

    public async Task<DepositOrderDto?> GetByIdAsync(Guid id)
    {
        var order = await _db.DepositOrders.FirstOrDefaultAsync(o=>o.Id == id);
        if(order == null)
        {
            Console.WriteLine("The object was not found in the database.");
            throw new InvalidOperationException($"Deposit order {id} was not found.");
        }
        else
        {
            return order;
        }
    }

    public async Task<DepositOrderDto> CreateAsync(CreateDepositOrderBook depositOrder)
    {
        if (depositOrder.CreationTime == default)
        {
            depositOrder.CreationTime = DateTime.UtcNow;
        }

        _db.DepositOrders.Add(depositOrder);
        await _db.SaveChangesAsync();
        return depositOrder;
    }

    public async Task<bool> UpdateAsync(DepositOrderDto depositOrder)
    {
        var existing = await _db.DepositOrders
            .FirstOrDefaultAsync(order => order.Id == depositOrder.Id);

        if (existing is null)
        {
            return false;
        }

        existing.OrderNumber = dto.OrderNumber;
        existing.OrderDate = dto.OrderDate;
        existing.DepositorName = dto.DepositorName;
        existing.Status = dto.Status;
        existing.Notes = dto.Notes;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _db.DepositOrders
            .FirstOrDefaultAsync(order => order.Id == id);

        if (existing is null)
        {
            return false;
        }

        _db.DepositOrders.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}
