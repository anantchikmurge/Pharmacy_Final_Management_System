using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllOrdersAsync();

    Task<Order?> GetOrderByIdAsync(int id);

    Task CreateOrderAsync(OrderDto orderDto, string doctorEmail);

    Task ApproveOrderAsync(int orderId);
}