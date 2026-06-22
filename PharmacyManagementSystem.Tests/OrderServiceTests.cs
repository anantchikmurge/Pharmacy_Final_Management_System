using Moq;
using NUnit.Framework;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Tests;

[TestFixture]
public class OrderServiceTests
{
    private Mock<IOrderRepository> _orderRepo;
    private Mock<IEmailService> _emailService;
    private OrderService _service;

    [SetUp]
    public void Setup()
    {
        _orderRepo = new Mock<IOrderRepository>();
        _emailService = new Mock<IEmailService>();
        _service = new OrderService(_orderRepo.Object, _emailService.Object);
    }

    [Test]
    public async Task GetAllOrdersAsync_ReturnsList()
    {
        _orderRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Order>
        {
            new Order { Id = 1, OrderReference = "REF001", DoctorId = "doc1", Status = "Pending", OrderDate = DateTime.UtcNow }
        });

        var result = await _service.GetAllOrdersAsync();

        Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task CreateOrderAsync_AddsOrderAndSendsEmail()
    {
        var dto = new OrderDto { DoctorId = "doc1", Items = new List<OrderItemDto> { new OrderItemDto { DrugId = 1, Quantity = 2 } } };

        await _service.CreateOrderAsync(dto, "doctor@test.com");

        _orderRepo.Verify(r => r.AddAsync(It.Is<Order>(o => o.DoctorId == "doc1" && o.Status == "Pending")), Times.Once);
        _emailService.Verify(e => e.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ApproveOrderAsync_SetsStatusApproved()
    {
        var order = new Order { Id = 1, OrderReference = "REF001", DoctorId = "doc1", Status = "Pending", OrderDate = DateTime.UtcNow };
        _orderRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(order);

        await _service.ApproveOrderAsync(1);

        _orderRepo.Verify(r => r.UpdateAsync(It.Is<Order>(o => o.Status == "Approved")), Times.Once);
    }
}
