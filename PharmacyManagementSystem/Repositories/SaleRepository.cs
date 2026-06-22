using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly PharmacyDbContext _context;

    public SaleRepository(PharmacyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Sale>> GetAllAsync()
    {
        return await _context.Sales.ToListAsync();
    }

    public async Task AddAsync(Sale sale)
    {
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
    }
}