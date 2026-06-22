using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interfaces;

public interface ISaleService
{
    Task<List<Sale>> GetAllSalesAsync();

    Task RecordSaleAsync(SaleDto saleDto);
}