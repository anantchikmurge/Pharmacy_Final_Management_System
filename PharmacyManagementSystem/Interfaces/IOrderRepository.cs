using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interfaces;

// Defines operations related to orders
public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync();

    Task<Order?> GetByIdAsync(int id);

    Task AddAsync(Order order);

    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);
}