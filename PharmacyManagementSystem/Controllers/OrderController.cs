using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using System.Security.Claims;

namespace PharmacyManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [Authorize(Roles = "Doctor")]
    [HttpPost]
    public async Task<IActionResult> Create(OrderDto orderDto)
    {
        var doctorEmail = User.FindFirst(ClaimTypes.Name)?.Value;

        if (doctorEmail == null)
            return Unauthorized();

        await _orderService.CreateOrderAsync(orderDto, doctorEmail);

        return Ok("Order created successfully");
    }

    // Admin approves order
    [HttpPut("approve/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ApproveOrder(int id)
    {
        await _orderService.ApproveOrderAsync(id);

        return Ok("Order approved");
    }
}