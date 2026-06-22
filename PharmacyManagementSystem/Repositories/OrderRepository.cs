using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Repositories;

// Handles order related database operations
public class OrderRepository : IOrderRepository
{
    private readonly PharmacyDbContext _context;

    public OrderRepository(PharmacyDbContext context)
    {
        _context = context;
    }

    // Returns all orders
    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.Include(o => o.Items).ToListAsync();
    }

    // Returns order by id
    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders.Include(o => o.Items)
                                    .FirstOrDefaultAsync(o => o.Id == id);
    }

    // Adds a new order
    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    // Updates order status
    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
    // delete order 
    public async Task DeleteAsync(int id)
    {
    var order = await _context.Orders.FindAsync(id);
    if (order != null)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
    }
}