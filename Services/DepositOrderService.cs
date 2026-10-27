
using AutoMapper;
using BibliographyGenerationApp.Contracts;
using BibliographyGenerationApp.Data;
using BibliographyGenerationApp.DTOs;
using BibliographyGenerationApp.Models;
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
            var orderdto = _mapper.Map<DepositOrderDto>(order);
            return orderdto;
        }
    }


    public async Task<DepositOrderDto> CreateAsync(
        CreateDepositOrderBook depositOrder)
    {
        if (depositOrder.CreationTime == default)
        {
            depositOrder.CreationTime = DateTime.UtcNow;
        }

        var order = _mapper.Map<DepositOrder>(depositOrder);

        _db.DepositOrders.Add(order);

        await _db.SaveChangesAsync();

        var orderDto = _mapper.Map<DepositOrderDto>(order);

        return orderDto;
    }


    public async Task<bool> UpdateAsync(DepositOrderDto depositOrder)
    {
        var existing = await _db.DepositOrders
            .FirstOrDefaultAsync(order => order.Id == depositOrder.Id);

        if (existing is null)
        {
            return false;
        }

        _mapper.Map(depositOrder, existing);

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
