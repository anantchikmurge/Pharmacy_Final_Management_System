using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Services;

// Handles business logic related to drugs
public class DrugService : IDrugService
{
    private readonly IDrugRepository _drugRepository;

    // Repository injected through constructor
    public DrugService(IDrugRepository drugRepository)
    {
        _drugRepository = drugRepository;
    }

    // Returns all drugs
    public async Task<List<Drug>> GetAllDrugsAsync()
    {
        return await _drugRepository.GetAllAsync();
    }

    // Returns drug by id
    public async Task<Drug?> GetDrugByIdAsync(int id)
    {
        return await _drugRepository.GetByIdAsync(id);
    }

    // Creates new drug
    public async Task AddDrugAsync(DrugDto drugDto)
    {
        
        var drug = new Drug
        {
            DrugName = drugDto.DrugName,
            DrugCode = drugDto.DrugCode,
            Manufacturer = drugDto.Manufacturer,
            Category = drugDto.Category,
            Price = drugDto.Price,
            QuantityInStock = drugDto.QuantityInStock,
            ExpiryDate = drugDto.ExpiryDate,
            Description = drugDto.Description
        };

        await _drugRepository.AddAsync(drug);
    }

    // Updates drug
    public async Task UpdateDrugAsync(int id, DrugDto drugDto)
    {
        var drug = await _drugRepository.GetByIdAsync(id);

        if (drug == null)
            return;

        drug.DrugName = drugDto.DrugName;
        drug.DrugCode = drugDto.DrugCode;
        drug.Manufacturer = drugDto.Manufacturer;
        drug.Category = drugDto.Category;
        drug.Price = drugDto.Price;
        drug.QuantityInStock = drugDto.QuantityInStock;
        drug.ExpiryDate = drugDto.ExpiryDate;
        drug.Description = drugDto.Description;

        await _drugRepository.UpdateAsync(drug);
    }

    // Deletes drug
    public async Task DeleteDrugAsync(int id)
    {
        await _drugRepository.DeleteAsync(id);
    }
}
