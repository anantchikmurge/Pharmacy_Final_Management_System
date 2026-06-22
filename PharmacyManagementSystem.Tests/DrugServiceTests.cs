using Moq;
using NUnit.Framework;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Tests;

[TestFixture]
public class DrugServiceTests
{
    private Mock<IDrugRepository> _drugRepo;
    private DrugService _service;

    [SetUp]
    public void Setup()
    {
        _drugRepo = new Mock<IDrugRepository>();
        _service = new DrugService(_drugRepo.Object);
    }

    [Test]
    public async Task GetAllDrugsAsync_ReturnsList()
    {
        _drugRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Drug>
        {
            new Drug { Id = 1, DrugName = "Paracetamol", DrugCode = "P001", Manufacturer = "ABC", Category = "Painkiller", ExpiryDate = DateTime.UtcNow.AddYears(1) }
        });

        var result = await _service.GetAllDrugsAsync();

        Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task AddDrugAsync_CallsRepositoryAdd()
    {
        var dto = new DrugDto { DrugName = "Aspirin", DrugCode = "A001", Manufacturer = "PharmaX", Category = "Painkiller", Price = 10, QuantityInStock = 100, ExpiryDate = DateTime.UtcNow.AddYears(1) };

        await _service.AddDrugAsync(dto);

        _drugRepo.Verify(r => r.AddAsync(It.Is<Drug>(d => d.DrugName == "Aspirin")), Times.Once);
    }

    [Test]
    public async Task DeleteDrugAsync_CallsRepositoryDelete()
    {
        await _service.DeleteDrugAsync(1);

        _drugRepo.Verify(r => r.DeleteAsync(1), Times.Once);
    }
}
