using Moq;
using NUnit.Framework;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Tests;

[TestFixture]
public class SaleServiceTests
{
    private Mock<ISaleRepository> _saleRepo;
    private SaleService _service;

    [SetUp]
    public void Setup()
    {
        _saleRepo = new Mock<ISaleRepository>();
        _service = new SaleService(_saleRepo.Object);
    }

    [Test]
    public async Task GetAllSalesAsync_ReturnsList()
    {
        _saleRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Sale>
        {
            new Sale { Id = 1, OrderReference = "REF001", DoctorId = "doc1", DrugCode = "P001", QuantitySold = 2, SaleAmount = 20, SaleDate = DateTime.UtcNow }
        });

        var result = await _service.GetAllSalesAsync();

        Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task RecordSaleAsync_CallsRepositoryAdd()
    {
        var dto = new SaleDto { OrderReference = "REF002", DoctorId = "doc2", DrugCode = "A001", QuantitySold = 5, SaleAmount = 50, SaleDate = DateTime.UtcNow };

        await _service.RecordSaleAsync(dto);

        _saleRepo.Verify(r => r.AddAsync(It.Is<Sale>(s => s.OrderReference == "REF002")), Times.Once);
    }
}
