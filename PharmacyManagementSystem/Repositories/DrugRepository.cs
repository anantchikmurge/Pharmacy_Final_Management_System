using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Repositories;

// Implements IDrugRepository 
public class DrugRepository : IDrugRepository
{
    // DbContext object used to access database tables
    private readonly PharmacyDbContext _context;

    // Constructor receives DbContext through dependency injection
    public DrugRepository(PharmacyDbContext context)
    {
        _context = context;
    }

    // Returns all drugs from the database
    public async Task<List<Drug>> GetAllAsync()
    {
        return await _context.Drugs.ToListAsync();
    }

    // Returns a single drug by id
    public async Task<Drug?> GetByIdAsync(int id)
    {
        return await _context.Drugs.FindAsync(id);
    }

    // Adds a new drug to database
    public async Task AddAsync(Drug drug)
    {
        await _context.Drugs.AddAsync(drug);
        await _context.SaveChangesAsync();
    }

    // Updates an existing drug
    public async Task UpdateAsync(Drug drug)
    {
        _context.Drugs.Update(drug);
        await _context.SaveChangesAsync();
    }

    // Deletes a drug by id
    public async Task DeleteAsync(int id)
    {
        var drug = await _context.Drugs.FindAsync(id);

        if (drug != null)
        {
            _context.Drugs.Remove(drug);
            await _context.SaveChangesAsync();
        }
    }
}