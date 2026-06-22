using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interfaces;

public interface ISaleRepository
{
    Task<List<Sale>> GetAllAsync();

    Task AddAsync(Sale sale);
}