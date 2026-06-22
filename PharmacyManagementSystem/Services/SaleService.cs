using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;

    public SaleService(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<List<Sale>> GetAllSalesAsync()
    {
        return await _saleRepository.GetAllAsync();
    }

    public async Task RecordSaleAsync(SaleDto saleDto)
    {
        var sale = new Sale
        {
            OrderReference = saleDto.OrderReference,
            DoctorId = saleDto.DoctorId,
            DrugCode = saleDto.DrugCode,
            QuantitySold = saleDto.QuantitySold,
            SaleAmount = saleDto.SaleAmount,
            SaleDate = saleDto.SaleDate
        };

        await _saleRepository.AddAsync(sale);
    }
}