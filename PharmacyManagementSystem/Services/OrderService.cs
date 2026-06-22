using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Services;

// Handles business logic related to orders
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmailService _emailService;

    public OrderService(IOrderRepository orderRepository, IEmailService emailService)
    {
        _orderRepository = orderRepository;
        _emailService = emailService;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    // Doctor places order
    public async Task CreateOrderAsync(OrderDto orderDto, string doctorEmail)
    {
        var order = new Order
        {
            DoctorId = orderDto.DoctorId,
            OrderReference = Guid.NewGuid().ToString(),
            OrderDate = DateTime.UtcNow,
            Status = "Pending",
            Items = new List<OrderItem>()
        };

        if (orderDto.Items != null)
        {
            foreach (var item in orderDto.Items)
            {
                order.Items.Add(new OrderItem
                {
                    DrugId = item.DrugId,
                    Quantity = item.Quantity
                });
            }
        }

        await _orderRepository.AddAsync(order);

        var subject = "Pharmacy Order Confirmation";

        var body = $@"
Hello Doctor,

Your order has been successfully placed.

Order Reference: {order.OrderReference}
Status: {order.Status}

Thank you,
Pharmacy Management System
";

        await _emailService.SendEmailAsync("anantchikmurge03@gmail.com", subject, body);
    }

    // Admin approves order
    public async Task ApproveOrderAsync(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);

        if (order == null)
            return;

        order.Status = "Approved";

        await _orderRepository.UpdateAsync(order);

        var subject = "Order Approved";

        var body = $@"
Hello Doctor,

Your pharmacy order has been approved by the admin.

Order Reference: {order.OrderReference}

Thank you,
Pharmacy Management System
";

        // Ideally fetch doctor email from database
        //var doctorEmail = "anantchikmurge03@gmail.com";

       await _emailService.SendEmailAsync("anantchikmurge03@gmail.com", subject, body);
    }
}