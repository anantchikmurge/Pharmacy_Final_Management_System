using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interfaces;

// Defines business operations for drugs
public interface IDrugService
{
    // Return all drugs
    Task<List<Drug>> GetAllDrugsAsync();

    // Return single drug
    Task<Drug?> GetDrugByIdAsync(int id);

    // Create a new drug
    Task AddDrugAsync(DrugDto drugDto);

    // Update drug
    Task UpdateDrugAsync(int id, DrugDto drugDto);

    // Delete drug
    Task DeleteDrugAsync(int id);
}