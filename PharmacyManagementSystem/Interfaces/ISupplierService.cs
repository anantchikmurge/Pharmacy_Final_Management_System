using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interfaces;

// Defines business operations for suppliers
public interface ISupplierService
{
    Task<List<Supplier>> GetAllSuppliersAsync();

    Task<Supplier?> GetSupplierByIdAsync(int id);

    Task AddSupplierAsync(SupplierDto supplierDto);

    Task UpdateSupplierAsync(int id, SupplierDto supplierDto);

    Task DeleteSupplierAsync(int id);
}