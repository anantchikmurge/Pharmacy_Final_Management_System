using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Repositories;

// Handles supplier related database operations
public class SupplierRepository : ISupplierRepository
{
    private readonly PharmacyDbContext _context;

    public SupplierRepository(PharmacyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Supplier>> GetAllAsync()
    {
        return await _context.Suppliers.ToListAsync();
    }

    public async Task<Supplier?> GetByIdAsync(int id)
    {
        return await _context.Suppliers.FindAsync(id);
    }

    public async Task AddAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);

        if (supplier != null)
        {
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }
}