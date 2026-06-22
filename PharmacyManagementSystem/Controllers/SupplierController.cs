using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace PharmacyManagementSystem.Controllers;

// Handles API requests related to suppliers
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    // GET api/supplier
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var suppliers = await _supplierService.GetAllSuppliersAsync();
        return Ok(suppliers);
    }

    // GET api/supplier/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var supplier = await _supplierService.GetSupplierByIdAsync(id);

        if (supplier == null)
            return NotFound();

        return Ok(supplier);
    }

    // POST api/supplier
    [HttpPost]
    public async Task<IActionResult> Create(SupplierDto supplierDto)
    {
        await _supplierService.AddSupplierAsync(supplierDto);
        return Ok("Supplier added successfully");
    }

    // PUT api/supplier/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, SupplierDto supplierDto)
    {
        await _supplierService.UpdateSupplierAsync(id, supplierDto);
        return Ok("Supplier updated successfully");
    }

    // DELETE api/supplier/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _supplierService.DeleteSupplierAsync(id);
        return Ok("Supplier deleted successfully");
    }
}
