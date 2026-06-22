using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Services;

// Handles business logic related to suppliers
public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<List<Supplier>> GetAllSuppliersAsync()
    {
        return await _supplierRepository.GetAllAsync();
    }

    public async Task<Supplier?> GetSupplierByIdAsync(int id)
    {
        return await _supplierRepository.GetByIdAsync(id);
    }

    public async Task AddSupplierAsync(SupplierDto supplierDto)
    {
        var supplier = new Supplier
        {
            SupplierName = supplierDto.SupplierName,
            ContactPerson = supplierDto.ContactPerson,
            Email = supplierDto.Email,
            Phone = supplierDto.Phone,
            Address = supplierDto.Address
        };

        await _supplierRepository.AddAsync(supplier);
    }

    public async Task UpdateSupplierAsync(int id, SupplierDto supplierDto)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);

        if (supplier == null)
            return;

        supplier.SupplierName = supplierDto.SupplierName;
        supplier.ContactPerson = supplierDto.ContactPerson;
        supplier.Email = supplierDto.Email;
        supplier.Phone = supplierDto.Phone;
        supplier.Address = supplierDto.Address;

        await _supplierRepository.UpdateAsync(supplier);
    }

    public async Task DeleteSupplierAsync(int id)
    {
        await _supplierRepository.DeleteAsync(id);
    }
}
