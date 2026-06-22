using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interfaces;

// Defines operations related to drugs
public interface IDrugRepository
{
    // Get all drugs
    Task<List<Drug>> GetAllAsync();

    // Get drug by id
    Task<Drug?> GetByIdAsync(int id);

    // Add new drug
    Task AddAsync(Drug drug);

    // Update drug
    Task UpdateAsync(Drug drug);

    // Delete drug
    Task DeleteAsync(int id);
}