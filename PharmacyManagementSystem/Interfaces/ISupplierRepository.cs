using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interfaces;

// Defines operations related to suppliers
public interface ISupplierRepository
{
    Task<List<Supplier>> GetAllAsync();

    Task<Supplier?> GetByIdAsync(int id);

    Task AddAsync(Supplier supplier);

    Task UpdateAsync(Supplier supplier);

    Task DeleteAsync(int id);
}