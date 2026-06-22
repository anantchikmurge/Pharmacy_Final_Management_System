using Moq;
using NUnit.Framework;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Tests;

[TestFixture]
public class SupplierServiceTests
{
    private Mock<ISupplierRepository> _supplierRepo;
    private SupplierService _service;

    [SetUp]
    public void Setup()
    {
        _supplierRepo = new Mock<ISupplierRepository>();
        _service = new SupplierService(_supplierRepo.Object);
    }

    [Test]
    public async Task GetAllSuppliersAsync_ReturnsList()
    {
        _supplierRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Supplier>
        {
            new Supplier { Id = 1, SupplierName = "MedSupply", ContactPerson = "John", Email = "john@med.com", Phone = "1234567890", Address = "123 St" }
        });

        var result = await _service.GetAllSuppliersAsync();

        Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task AddSupplierAsync_CallsRepositoryAdd()
    {
        var dto = new SupplierDto { SupplierName = "NewSupplier", ContactPerson = "Bob", Email = "bob@new.com", Phone = "1112223333", Address = "789 Blvd" };

        await _service.AddSupplierAsync(dto);

        _supplierRepo.Verify(r => r.AddAsync(It.Is<Supplier>(s => s.SupplierName == "NewSupplier")), Times.Once);
    }
}
