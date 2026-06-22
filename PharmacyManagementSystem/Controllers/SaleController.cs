using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
private readonly ISaleService _saleService;

public SaleController(ISaleService saleService)
{
    _saleService = saleService;
}

[HttpGet]
public async Task<IActionResult> GetAllSales()
{
    var sales = await _saleService.GetAllSalesAsync();
    return Ok(sales);
}

[HttpPost]
public async Task<IActionResult> CreateSale([FromBody] SaleDto saleDto)
{
    await _saleService.RecordSaleAsync(saleDto);
    return Ok("Sale recorded successfully");
}

}