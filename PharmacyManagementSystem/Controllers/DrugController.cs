using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace PharmacyManagementSystem.Controllers;

// Handles API requests related to drugs
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,Doctor")]
public class DrugController : ControllerBase
{
    private readonly IDrugService _drugService;

    // Service injected through constructor
    public DrugController(IDrugService drugService)
    {
        _drugService = drugService;
    }

    // GET api/drug
    // Returns all drugs
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var drugs = await _drugService.GetAllDrugsAsync();
        return Ok(drugs);
    }

    // GET api/drug/5
    // Returns drug by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var drug = await _drugService.GetDrugByIdAsync(id);

        if (drug == null)
            return NotFound();

        return Ok(drug);
    }

    // POST api/drug
    // Adds a new drug
    [HttpPost]
    public async Task<IActionResult> Create(DrugDto drugDto)
    {
        await _drugService.AddDrugAsync(drugDto);
        return Ok("Drug added successfully");
    }

    // PUT api/drug/5
    // Updates drug
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, DrugDto drugDto)
    {
        await _drugService.UpdateDrugAsync(id, drugDto);
        return Ok("Drug updated successfully");
    }

    // DELETE api/drug/5
    // Deletes drug
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _drugService.DeleteDrugAsync(id);
        return Ok("Drug deleted successfully");
    }
}
